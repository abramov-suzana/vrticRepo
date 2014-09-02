using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
namespace vrtic
{
    /// <summary>
    /// Klasa koja ce se brinuti za rad s bazom
    /// </summary>
    class Baza
    {
        /// <summary>
        /// Prijavljeni zaposlenik koji se sprema
        /// </summary>
        public static Zaposlenik prijavljeniZaposlenik =  new Zaposlenik();
        SQLiteConnection konekcija = new SQLiteConnection(@"Data Source=djecjivrtic.db");
        public SQLiteCommand naredba { get; set; }
        
        /// <summary>
        /// Uspostavljanje veze s bazom
        /// </summary>
        public Baza()
        {
        
        }
        /// <summary>
        /// Vraca izvjestaje u obliku liste<liste<stringova> -> Kad povuces listu
        /// dobijes sve zapise [Datum,Ime,Prezime;izvjestaj]
        ///                    [Datum2,Ime2,Prezime2,Izvjestaj2]
        /// Pa da ne moram radit novi objekt postavio sam da su {Datum,Ime,Prezime,Izvjestaj] strinogi i to je sve lista
        /// Kako se to pokazuje u datagridViewu onda to automatski poslat na njega
        /// ------------------------------Primjer Desni klik na ime metode vratiIzvjestaje() -> Find all references (sredina,dolje) i onda se otvori gdje se to sve koristi pa pogledajte tamo nastavak opisa
        /// </summary>
        /// <returns></returns>
        public List<List<string>> vratiIzvjestaje()
        {
            konekcija.Open();
            List<List<string>> povratniPodaci = new List<List<string>>();
            List<string> podaci = new List<string>();
            naredba = new SQLiteCommand("select a.Datum, b.ImeDjeteta, b.PrezimeDjeteta, a.Izvjestaj from Evidencija a join Dijete b on b.OIB=a.OIBDjeteta;",konekcija);
            SQLiteDataReader citac = naredba.ExecuteReader();
            //citac.read() cita redom prema indexima koje vraca sql upit citac[0] ce odgovarat a.DAtum iz upita i slicno, citac[1] za b.imeDjeteta
            while (citac.Read())
            {
                podaci.Add(citac[0].ToString());
                podaci.Add(citac[1].ToString());
                podaci.Add(citac[2].ToString());
                podaci.Add(citac[3].ToString());
                povratniPodaci.Add(podaci);
                podaci = new List<string>();
            }
            konekcija.Close();
            return povratniPodaci;
        }
        /// <summary>
        /// Pokupi svu djecu i usporedi rođendane s danasnjim danom
        /// </summary>
        /// <returns></returns>
        public string vratiRodendane()
        {
            string osobe = "";
            konekcija.Open();
            naredba = new SQLiteCommand("SELECT * from Dijete",konekcija);
            SQLiteDataReader citac = naredba.ExecuteReader();
            while (citac.Read())
            {
                // SqLiteDataReader osim po indexu (citac[0] moze i po imenu stupca baze pretrazivati clanove citac['DatumRodenja']
                DateTime datumbaza = Convert.ToDateTime(citac["DatumRodenja"].ToString());
                if (datumbaza.Month == DateTime.Now.Month && datumbaza.Day == DateTime.Now.Day)
                {
                    osobe += " " + citac["ImeDjeteta"].ToString() + " " + citac["PrezimeDjeteta"].ToString() + ","; 
                }
            }
            
            konekcija.Close();
            return osobe;
        }
        /// <summary>
        ///  Mjenjanje tarifa 1. cijena se odnosi na cijenu redovnu, a 2. na cijenu koja je kao dodatni boravak ili kako to vec zovete
        ///  INSERT i UPDATE radimo s parametriziranim upitima
        ///  ---------------UPDATE Tarifa set CijenaTarife=@CIJENA1, DatumPromjene=@DATUM where IDTarifa = 1;UPDATE Tarifa set CijenaTarife=@CIJENA2, DatumPromjene=@DATUM2 where IDTarifa = 2;"
        /// To znaci sljedece -- > parametar se određuje s @IMEPARAMETRA (mislim da ne mora velikim slovom)
        /// kasnije se parametru pridruzuje vrijednost s naredba.Parameters.Add(new SQLiteParameter("CIJENA1", cijena));
        /// 1. dio je naziv parametra, a 2. je vrijednost koja ce se upisati umjesto njega
        /// Tako vrijednosti ne pisemo direktno u upit -> prednosti: Nema zafrkancije s navodnicima a i onda datume prevodi kako treba u bazu (jer se inace s datumima treba rucno mjenjat format koji nije isti za c# i sqlite)
        /// Ljepse izgleda :)
        /// </summary>
        /// <param name="cijena2"></param>
        /// <param name="cijena"></param>
        /// <returns></returns>
        public int promjeniTarife(string cijena2,string cijena)
        {
            konekcija.Open();
            naredba = new SQLiteCommand("UPDATE Tarifa set CijenaTarife=@CIJENA1, DatumPromjene=@DATUM where IDTarifa = 1;UPDATE Tarifa set CijenaTarife=@CIJENA2, DatumPromjene=@DATUM2 where IDTarifa = 2;"
                                         ,konekcija);
            naredba.Parameters.Add(new SQLiteParameter("CIJENA1", cijena));
            naredba.Parameters.Add(new SQLiteParameter("DATUM", DateTime.Now));
            naredba.Parameters.Add(new SQLiteParameter("CIJENA2", cijena2));
            naredba.Parameters.Add(new SQLiteParameter("DATUM2", DateTime.Now));
            int povratna = naredba.ExecuteNonQuery();
            konekcija.Close();
            return povratna;
        }
        /// <summary>
        /// Sluzi za racunanje cijene koju osoba mora platiti
        /// </summary>
        /// <param name="OIB"></param>
        /// <returns></returns>
        public List<PodaciRacuna> izvuciPodatkeDjeteta(string OIB)
        {
            //Prvo povlacimo podatke djeteta (ime prezime i slicno, prema oibu djeteta koje smo izabrali
            List<float> listaCijena = new List<float>();
            // Odmah preuzmimamo vazeci cjenik koji ce kasnije trebati 
            listaCijena = this.vratiCijene();
            List<PodaciRacuna> podaci = new List<PodaciRacuna>();
            PodaciRacuna podatak = new PodaciRacuna();
            string Ime="";
            string Prezime="";
            konekcija.Open();
            naredba =  new SQLiteCommand(String.Format("SELECT * FROM Dijete where OIB like {0}",OIB),konekcija);
            SQLiteDataReader citac = naredba.ExecuteReader();
            while (citac.Read())
            {
                Ime = citac["ImeDjeteta"].ToString();
                Prezime = citac["PrezimeDjeteta"].ToString();
            }
            // Za to isto dijete preuzmi sve stavke iz njegove evidencije
            naredba = new SQLiteCommand(String.Format("SELECT * FROM Evidencija where OIBDjeteta like {0}", OIB), konekcija);
            citac = naredba.ExecuteReader();
            while (citac.Read())
            {
                // Provjeri dal se radi o istom mjesecu -> mjesecu za kojeg se zeli naplatiti
              DateTime vrijeme  =  DateTime.Parse(citac["Datum"].ToString());
              if (vrijeme.Month == DateTime.Now.Month)
              {
                  // Za svaki put kad je prisutan preuzmi vrijeme koje je bio tamo
                  if (citac["Prisutan"].ToString() == "1")
                  {
                      podatak.Ime = Ime;
                      podatak.Prezime = Prezime;
                      podatak.SatiPrekovremeni = citac["TarifaProduzeni"].ToString();
                      podatak.SatiRedovni = citac["TraifaRedovni"].ToString();
                      podatak.Datum = vrijeme;
                      // na osnovu cjenika i sati koje je dijete bilo izracunaj cijenu 
                      podatak.cijena = float.Parse(podatak.SatiRedovni) * listaCijena[0]+float.Parse(podatak.SatiPrekovremeni)*listaCijena[1];
                      podaci.Add(podatak);
                      podatak = new PodaciRacuna();
                  }
                
              }
               
            }


            konekcija.Close();
            return podaci;
        }
        // vraca vazece tarife
        private List<float> vratiCijene()
        {
            List<float> listaCijena = new List<float>();
            konekcija.Open();
            naredba = new SQLiteCommand("Select * from Tarifa",konekcija);
            SQLiteDataReader citac = naredba.ExecuteReader();
            while (citac.Read())
            {
                listaCijena.Add(float.Parse(citac["CijenaTarife"].ToString()));
            }
            konekcija.Close();
            return listaCijena;
        }
        /// <summary>
        /// Unos evidencije za određeno dijete na određeni dan
        /// Isto tako rabimo parametrizirane upite
        /// Parametrizirani upiti sprecavaju sql injection ( to ce mozda pitat) 
        ///                         SQLInjection je sigurnosni rizik pri kojem upit se more kompromitirat.  http://www.cis.hr/files/dokumenti/CIS-DOC-2011-09-025.pdf stranica 7 za vise detalja
        ///                            Ukratko: Ako imate upit upit = “SELECT KorisnickoIme FROM Korisnici 
        ///WHERE KorisnickoIme = '“ + user + “'
        //AND Lozinka = '“ + pass + “'“
        /// Onda na user i pass mozete upisati neke druge dijelove sql koda koji bi mozda ispisali neke podatke ili vas lako pustili u sustav
        /// Ako i dalje nije jasno pitajte me ili google za sql injection
        /// </summary>
        /// <param name="datum"></param>
        /// <param name="OIB"></param>
        /// <param name="prisutan"></param>
        /// <param name="redovni"></param>
        /// <param name="produzeni"></param>
        /// <param name="izvjestaj"></param>
        /// <returns></returns>
        public int unesiEvidenciju(String datum, string OIB, bool prisutan, float redovni, float produzeni,string izvjestaj)
        {
            if(evidentiran(datum,OIB)==false)
            {
            konekcija.Open();
            naredba = new SQLiteCommand("INSERT INTO Evidencija Values(@DATUM,@OIB,@PRISUTAN,@REDOVNI,@IZVJESTAJ,@PRODUZENI)", konekcija);
            DateTime date = Convert.ToDateTime(datum);
            naredba.Parameters.Add(new SQLiteParameter("DATUM",date));
            naredba.Parameters.Add(new SQLiteParameter("OIB", OIB));
            int prisutana;
            if (prisutan)
                prisutana = 1;
            else prisutana = 0;
            naredba.Parameters.Add(new SQLiteParameter("PRISUTAN", prisutana));
            naredba.Parameters.Add(new SQLiteParameter("REDOVNI", redovni));
            naredba.Parameters.Add(new SQLiteParameter("PRODUZENI", produzeni));
            naredba.Parameters.Add(new SQLiteParameter("IZVJESTAJ", izvjestaj));
            int uspjeh = naredba.ExecuteNonQuery();
            konekcija.Close();
            return uspjeh;
            }
            else
                return 0;
        }
        /// <summary>
        /// Funkcija koja govori jel dijete vec upisano na taj dan (da ga ne upisiva dvaput)
        /// </summary>
        /// <param name="datum"></param>
        /// <param name="oib"></param>
        /// <returns></returns>
        private bool evidentiran(String datum, string oib)
        {
            bool evidencija = false;
            konekcija.Open();
            DateTime date = Convert.ToDateTime(datum);
            string d = date.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        //      MessageBox.Show(d);
            naredba = new SQLiteCommand(String.Format("SELECT Datum from Evidencija where(OIBDjeteta like {0})", oib), konekcija);
         
        
            SQLiteDataReader citac = naredba.ExecuteReader();
            while (citac.Read())
            {
                date = Convert.ToDateTime(citac[0].ToString());
                string provjera = date.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); 
                if (provjera.Equals(d))
                {
                    evidencija = true;
                }
            }
               
            
            konekcija.Close();
            return evidencija;
        }
        /// <summary>
        /// Vraca djecu po grupama (tako da svaki odgajatelj vidi samo djecu iz svoje grupe)
        /// </summary>
        /// <returns></returns>
        public List<Dijete> vratiDjecuPoGrupama()
        {
            if (konekcija.State == System.Data.ConnectionState.Open)
                konekcija.Close();
            konekcija.Open();
            //odgajatelj-3 racunovdoja=2 admin = 1
            if (prijavljeniZaposlenik.TipZaposlenika == 3)
            {
                naredba = new SQLiteCommand(String.Format("SELECT BrojGrupe FROM GRUPA where OIBZaposlenika like {0}", prijavljeniZaposlenik.OIB), konekcija);
                SQLiteDataReader citac1 = naredba.ExecuteReader();
                string brojGrupe = "";
                while (citac1.Read())
                {
                    brojGrupe = citac1["BrojGrupe"].ToString();

                }
                naredba = new SQLiteCommand(String.Format("SELECT * FROM Dijete Where BrojGrupeDjeteta like {0}", brojGrupe), konekcija);
            }
                //ostali
            else
            {
                naredba = new SQLiteCommand("SELECT * FROM Dijete",konekcija);
            }
            SQLiteDataReader citac = naredba.ExecuteReader();
            List<Dijete> lista = new List<Dijete>();
            Dijete dijete = new Dijete();
            while (citac.Read())
            {
                dijete.ImeDjeteta = citac["ImeDjeteta"].ToString();
                dijete.PrezimeDjeteta = citac["PrezimeDjeteta"].ToString();
                dijete.OIB = citac["OIB"].ToString();
                dijete.ImeOca = citac["ImeOca"].ToString();
                dijete.PrezimeOca = citac["PrezimeOca"].ToString();
                dijete.ImeMajke = citac["ImeMajke"].ToString();
                dijete.PrezimeMajke = citac["PrezimeMajke"].ToString();
                dijete.KontaktBroj = citac["KontaktBroj"].ToString();
                dijete.DatumRodenja = Convert.ToDateTime(citac["DatumRodenja"].ToString());
                dijete.BrojGrupe = int.Parse(citac["BrojGrupeDjeteta"].ToString());
                dijete.Adresa = citac["Adresa"].ToString();
                lista.Add(dijete);
                dijete = new Dijete();
            }
            return lista;
        }

        /// <summary>
        /// Funkcija koja ce dodavati objekte unutar tablice
        /// Ovo sam napravio tako da imate sve unose na jednom mjestu
        ///     Kako se sve nasljedjuje od klase object onda sve sto bude poslano njoj ce se primit ( npr. klasa Zaposlenik, Dijete i slicno), dok naziv tablice mi omogucuje da vidim u koju tablicu trebam dodat
        ///     zasto int vraca ?
        ///     Objasnjenje je vrlo jednostavno -> ExecuteNonQuery() metoda vraca int na nacin da taj int predstavlja broj mjesta na kojima je nesto promjenjeno u abzi
        ///     Dakle prilikom unosa novog djetea taj int mora biti 1 -> unio se jedan zapis u tablicu dijete
        ///     Isto tako moze raditi za update prilikom cega ukoliko dodje do promjena na vise tablica povratna vrijednost ce biti veca (broj tablica nad kojima su napravljene promjene)
        ///     Slicno objasnjenje imate na IntelliSensu kad pisete ExecuteNonQuery
        ///     Uglavnom provjera je da taj int nije 0 ili da je =>1 da znamo da se nesto upisalo
        /// </summary>
        /// <param name="obj">Objekt koji ce biti dodan</param>
        public int Dodaj(Object obj, String nazivTablice)
        {
            if (konekcija.State == System.Data.ConnectionState.Open)
                konekcija.Close();
            int vracenaVrijednost = 0;
            switch(nazivTablice)
            {
                case "Dijete":
                    {
                        Dijete dijete = obj as Dijete;
                        if (dijete == null)
                            return 9999;
                        konekcija.Open();
                        naredba = new SQLiteCommand("INSERT INTO Dijete VALUES(@OIB,@IME,@PREZIME,@IMEO,@PREZIMEO,@IMEM,@PREZIMEM,@ADRESA,@KONTAKT,@DATUM,@BROJGRUPE,@STATUS)", konekcija);
                        naredba.Parameters.Add(new SQLiteParameter("OIB",dijete.OIB));
                        naredba.Parameters.Add(new SQLiteParameter("IME",dijete.ImeDjeteta));
                        naredba.Parameters.Add(new SQLiteParameter("PREZIME",dijete.PrezimeDjeteta));
                        naredba.Parameters.Add(new SQLiteParameter("IMEO",dijete.ImeOca));
                        naredba.Parameters.Add(new SQLiteParameter("PREZIMEO",dijete.PrezimeOca));
                        naredba.Parameters.Add(new SQLiteParameter("IMEM",dijete.ImeMajke));
                        naredba.Parameters.Add(new SQLiteParameter("PREZIMEM",dijete.PrezimeMajke));
                        naredba.Parameters.Add(new SQLiteParameter("ADRESA",dijete.Adresa));
                        naredba.Parameters.Add(new SQLiteParameter("KONTAKT",dijete.KontaktBroj));
                        naredba.Parameters.Add(new SQLiteParameter("DATUM",dijete.DatumRodenja));
                        naredba.Parameters.Add(new SQLiteParameter("BROJGRUPE",dijete.BrojGrupe));
                        naredba.Parameters.Add(new SQLiteParameter("STATUS",1));

                         vracenaVrijednost = naredba.ExecuteNonQuery();
                        konekcija.Close();
                        
                        break;
                    }
                case "Zaposlenik":
                    {
                        konekcija.Open();
                        Zaposlenik zaposlenik = obj as Zaposlenik;
                        naredba = new SQLiteCommand("INSERT INTO Zaposlenik VALUES(@OIB,@IME,@PREZIME,@TIP,@ADRESA,@BROJ,@KORISNICKOIME,@LOZINKA)",konekcija);
                        naredba.Parameters.Add(new SQLiteParameter("OIB", zaposlenik.OIB));
                        naredba.Parameters.Add(new SQLiteParameter("IME", zaposlenik.ImeZaposlenika));
                        naredba.Parameters.Add(new SQLiteParameter("PREZIME", zaposlenik.PrezimeZaposlenika));
                        naredba.Parameters.Add(new SQLiteParameter("TIP", zaposlenik.TipZaposlenika));
                        naredba.Parameters.Add(new SQLiteParameter("ADRESA", zaposlenik.Adresa));
                        naredba.Parameters.Add(new SQLiteParameter("BROJ", zaposlenik.KontaktBrojs));
                        naredba.Parameters.Add(new SQLiteParameter("KORISNICKOIME", zaposlenik.KorisnickoIme));
                        naredba.Parameters.Add(new SQLiteParameter("LOZINKA", zaposlenik.Lozinka));
                        vracenaVrijednost = naredba.ExecuteNonQuery();
                        if (zaposlenik.TipZaposlenika == 3)
                        {
                            naredba = new SQLiteCommand(String.Format("INSERT INTO Grupa(OIBZaposlenika) values({0})", zaposlenik.OIB), konekcija);
                            naredba.ExecuteNonQuery();
                        }
                            konekcija.Close();
                        break;
                    }

                
            }
            return vracenaVrijednost;
        }
        /// <summary>
        /// Mjenja podatke u tablicama
        /// Ista prica kao za unos, cisto da se sve nalazi na istom mjestu 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="NazivTablice"></param>
        /// <returns></returns>
        public int Izmjeni(Object obj, string NazivTablice)
        {
            if (konekcija.State == System.Data.ConnectionState.Open)
                konekcija.Close();
            int vracenaVrijednost=0;
            switch (NazivTablice)
            {
                case "Dijete":
                    {
                        Dijete dijete =  obj as Dijete;
                        if(obj!=null)
                        {
                        konekcija.Open();
                        naredba= new SQLiteCommand(String.Format("UPDATE Dijete SET ImeDjeteta = @IME, PrezimeDjeteta = @PREZIME, ImeOca= @IMEO,PrezimeOca=@PREZIMEO, ImeMajke=@IMEM, PrezimeMajke=@PREZIMEM, Adresa = @ADRESA,KontaktBroj = @KONTAKT,DatumRodenja=@DATUM, BrojGrupeDjeteta= @BROJGRUPE, Status= @STATUS WHERE OIB like {0}",dijete.OIB),konekcija);
                        naredba.Parameters.Add(new SQLiteParameter("OIB", dijete.OIB));
                        naredba.Parameters.Add(new SQLiteParameter("IME", dijete.ImeDjeteta));
                        naredba.Parameters.Add(new SQLiteParameter("PREZIME", dijete.PrezimeDjeteta));
                        naredba.Parameters.Add(new SQLiteParameter("IMEO", dijete.ImeOca));
                        naredba.Parameters.Add(new SQLiteParameter("PREZIMEO", dijete.PrezimeOca));
                        naredba.Parameters.Add(new SQLiteParameter("IMEM", dijete.ImeMajke));
                        naredba.Parameters.Add(new SQLiteParameter("PREZIMEM", dijete.PrezimeMajke));
                        naredba.Parameters.Add(new SQLiteParameter("ADRESA", dijete.Adresa));
                        naredba.Parameters.Add(new SQLiteParameter("KONTAKT", dijete.KontaktBroj));
                        naredba.Parameters.Add(new SQLiteParameter("DATUM", dijete.DatumRodenja));
                        naredba.Parameters.Add(new SQLiteParameter("BROJGRUPE", dijete.BrojGrupe));
                        naredba.Parameters.Add(new SQLiteParameter("STATUS", dijete.Status));

                         vracenaVrijednost = naredba.ExecuteNonQuery();
                            konekcija.Close();
                        }
                        break;
                    }
                case "Zaposlenik":
                {
                    Zaposlenik zaposlenik = obj as Zaposlenik;
                    konekcija.Open();
                    naredba = new SQLiteCommand(String.Format("UPDATE Zaposlenik SET ImeZaposlenika = @IME, PrezimeZaposlenika = @PREZIME, TipZaposlenika=@TIP, Adresa=@ADRESA, KontaktBroj =@BROJ, KorisnickoIme = @KORISNICKOIME, Lozinka=@LOZINKA WHERE OIB LIKE {0}", zaposlenik.OIB), konekcija);
                    naredba.Parameters.Add(new SQLiteParameter("IME", zaposlenik.ImeZaposlenika));
                    naredba.Parameters.Add(new SQLiteParameter("PREZIME", zaposlenik.PrezimeZaposlenika));
                    naredba.Parameters.Add(new SQLiteParameter("TIP", zaposlenik.TipZaposlenika));
                    naredba.Parameters.Add(new SQLiteParameter("ADRESA", zaposlenik.Adresa));
                    naredba.Parameters.Add(new SQLiteParameter("BROJ", zaposlenik.KontaktBrojs));
                    naredba.Parameters.Add(new SQLiteParameter("KORISNICKOIME", zaposlenik.KorisnickoIme));
                    naredba.Parameters.Add(new SQLiteParameter("LOZINKA", zaposlenik.Lozinka));
                    vracenaVrijednost = naredba.ExecuteNonQuery();
                    konekcija.Close();
                    break;
                }
            }
            return vracenaVrijednost;
        }
        /// <summary>
        /// Vraca sve podatke iz zadane tablice,
        /// Losije izvedeno -> promjenit cu da vraca sve podatke prema tablici -> Lista aposlenika, djece i sl (switch naziva tablice treba napraviti)
        /// </summary>
        /// <param name="nazivTablice"></param>
        /// <returns></returns>
        public Object vratiSve(string nazivTablice,int nacin)// nacin 0 -> status djeteta 0 -> dakle nije upisan a vodi se u bazi. 1-> vec upisan
        {
            //Dijete dijete =  obj as Dijete;
            //List<Dijete> listaDijece  = Baza.VratiSve("Dijete",0) as List<Dijete>;
            if (konekcija.State == System.Data.ConnectionState.Open)
                konekcija.Close();
            konekcija.Open();
            SQLiteDataReader citac;
            switch(nazivTablice){
            case "Dijete":
                {
                    if (nacin == 1)
                    {
                        SQLiteCommand naredba = new SQLiteCommand(String.Format("SELECT * FROM {0} where Status =1", nazivTablice), konekcija);
                         citac= naredba.ExecuteReader();
                    }
                    else
                    {
                        SQLiteCommand naredba = new SQLiteCommand(String.Format("SELECT * FROM {0} where Status=0", nazivTablice), konekcija);
                         citac = naredba.ExecuteReader();
                    }
                    List<Dijete> lista = new List<Dijete>();
                    Dijete dijete = new Dijete();
                    while (citac.Read())
                    {
                        dijete.ImeDjeteta = citac["ImeDjeteta"].ToString();
                        dijete.PrezimeDjeteta = citac["PrezimeDjeteta"].ToString();
                        dijete.OIB = citac["OIB"].ToString();
                        dijete.ImeOca = citac["ImeOca"].ToString();
                        dijete.PrezimeOca = citac["PrezimeOca"].ToString();
                        dijete.ImeMajke = citac["ImeMajke"].ToString();
                        dijete.PrezimeMajke = citac["PrezimeMajke"].ToString();
                        dijete.KontaktBroj = citac["KontaktBroj"].ToString();
                        dijete.DatumRodenja = Convert.ToDateTime(citac["DatumRodenja"].ToString());
                        dijete.BrojGrupe = int.Parse(citac["BrojGrupeDjeteta"].ToString());
                        dijete.Adresa = citac["Adresa"].ToString();
                        dijete.Status = citac["Status"].ToString();
                        lista.Add(dijete);
                        dijete = new Dijete();
                    }
                    return lista;
                }
            case "Zaposlenik":{
                SQLiteCommand naredba = new SQLiteCommand(String.Format("SELECT * FROM {0}", nazivTablice), konekcija);
                 citac = naredba.ExecuteReader();
                List<Zaposlenik> lista = new List<Zaposlenik>();
                Zaposlenik zaposlenik = new Zaposlenik();

                while (citac.Read())
                {
                    zaposlenik.ImeZaposlenika = citac["ImeZaposlenika"].ToString();
                    zaposlenik.PrezimeZaposlenika = citac["PrezimeZaposlenika"].ToString();
                    zaposlenik.TipZaposlenika = int.Parse(citac["TipZaposlenika"].ToString());
                    zaposlenik.Adresa = citac["Adresa"].ToString();
                    zaposlenik.KontaktBrojs = citac["KontaktBroj"].ToString();
                    zaposlenik.OIB = citac["OIB"].ToString();
                    zaposlenik.KorisnickoIme = citac["KorisnickoIme"].ToString();
                    zaposlenik.Lozinka = citac["Lozinka"].ToString();
                    lista.Add(zaposlenik);
                    zaposlenik = new Zaposlenik();
                }
                return lista;
            }
            }

            return null;
            
        }
        /// <summary>
        /// Vraća popis svih grupa
        /// Sve grupe koje postoje za djecu u vrticu
        /// </summary>
        /// <returns></returns>
        public List<int> vratiSveGrupe()
        {
            if (konekcija.State == System.Data.ConnectionState.Open)
                konekcija.Close();
            List<int> povratneVrijednosti = new List<int>();
            konekcija.Open();
            SQLiteCommand naredba = new SQLiteCommand("SELECT * FROM Grupa",konekcija);
            SQLiteDataReader citac = naredba.ExecuteReader();
            while (citac.Read())
            {
                povratneVrijednosti.Add(int.Parse(citac[0].ToString()));
            }
            konekcija.Close();
            return povratneVrijednosti;
        }
        /// <summary>
        /// Vraća sve tipove zaposlenika
        /// Predstavljeni su brojevima-> u dokumentaciji navedite koji broj se odnosi na kojeg zaposlenika
        /// </summary>
        /// <returns></returns>
        public List<int> vratiSveTipove()
        {
            if (konekcija.State == System.Data.ConnectionState.Open)
                konekcija.Close();
            List<int> listaTipova = new List<int>();
            konekcija.Open();
            naredba = new SQLiteCommand("SELECT * FROM TipZaposlenika", konekcija);
            SQLiteDataReader citac = naredba.ExecuteReader();
            while (citac.Read())
            {
                listaTipova.Add(int.Parse(citac[0].ToString()));
            }
            konekcija.Close();
            return listaTipova;
        }
        /// <summary>
        /// Vraća jedan član određene tablice 
        /// Primjer posaljete vrijednost oiba i naziv tablice i prema tom se vraca zaposlenik ili dijete ->
        ///     vraca object koji kasnije prebacis u objekt tipa koji ti treba
        /// </summary>
        /// <param name="nazivTablice"></param>
        /// <param name="identifikator"></param>
        /// <returns></returns>
        public object vratiJednog(string nazivTablice, string identifikator)
        {
            if (konekcija.State == System.Data.ConnectionState.Open)
                konekcija.Close();
            konekcija.Open();
            switch (nazivTablice)
            {
                case "Dijete":
                    {                                                             
                         naredba = new SQLiteCommand(String.Format("SELECT * FROM {0} WHERE OIB LIKE {1}", nazivTablice, identifikator), konekcija);
                         SQLiteDataReader citac = naredba.ExecuteReader();
                         Dijete dijete = new Dijete();
                         while (citac.Read())
                         {
                             dijete.ImeDjeteta = citac["ImeDjeteta"].ToString();
                             dijete.PrezimeDjeteta = citac["PrezimeDjeteta"].ToString();
                             dijete.OIB = citac["OIB"].ToString();
                             dijete.ImeOca = citac["ImeOca"].ToString();
                             dijete.PrezimeOca = citac["PrezimeOca"].ToString();
                             dijete.ImeMajke = citac["ImeMajke"].ToString();
                             dijete.PrezimeMajke = citac["PrezimeMajke"].ToString();
                             dijete.KontaktBroj = citac["KontaktBroj"].ToString();
                           
                             dijete.DatumRodenja =(DateTime)citac["DatumRodenja"];
                             dijete.BrojGrupe = int.Parse(citac["BrojGrupeDjeteta"].ToString());
                             dijete.Adresa = citac["Adresa"].ToString();
                             dijete.Status = citac["Status"].ToString();
                             
                         }
                         return dijete;
                      // Dijete dijete =  Baza.VratiJednog("Dijete",xxxx) as Dijete;
                    }
                case "Zaposlenik":
                    {
                         naredba = new SQLiteCommand(String.Format("SELECT * FROM {0} WHERE OIB LIKE {1}", nazivTablice, identifikator), konekcija);
                         Zaposlenik zaposlenik = new Zaposlenik();
                         SQLiteDataReader citac = naredba.ExecuteReader();
                         while (citac.Read())
                         {
                             zaposlenik.ImeZaposlenika = citac["ImeZaposlenika"].ToString();
                             zaposlenik.PrezimeZaposlenika = citac["PrezimeZaposlenika"].ToString();
                             zaposlenik.TipZaposlenika = int.Parse(citac["TipZaposlenika"].ToString());
                             zaposlenik.Adresa = citac["Adresa"].ToString();
                             zaposlenik.KontaktBrojs = citac["KontaktBroj"].ToString();
                             zaposlenik.OIB = citac["OIB"].ToString();
                             zaposlenik.KorisnickoIme = citac["KorisnickoIme"].ToString();
                             zaposlenik.Lozinka = citac["Lozinka"].ToString();
                             
                         }
                         return zaposlenik;
                    
                    }
                  
            }


            return null;
         
        }
        /// <summary>
        /// Vraća tarifu s imenom tarife
        /// Pritom se vrijednosti spremaju u rijecnik -> Dictionary tip podatka
        ///     Sastoji se od kljca i vrijednosti 
        ///     -> kljuc naziv tarife
        ///     ->vrijednost cijena
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string,float>> vratiTarife()
        {
            if (konekcija.State == System.Data.ConnectionState.Open)
                konekcija.Close();
            List<Dictionary<string,float>> tarife = new List<Dictionary<string,float>>();
            konekcija.Open();
            naredba = new SQLiteCommand("SELECT * FROM Tarifa");
            SQLiteDataReader citac = naredba.ExecuteReader();
            while (citac.Read())
            {
                Dictionary<string, float> imeVrijednost = new Dictionary<string, float>();
                imeVrijednost.Add(citac["NazivTarife"].ToString(), citac.GetFloat(2));//i[0], i[1] -> na drugom mjestu se nalazi cijena Dictionary["ObicnaTarifa"].value  => cijena
                tarife.Add(imeVrijednost);
            }
            konekcija.Close();
            return tarife;
        }
        /// <summary>
        /// Prijava na sustav
        /// podatke cuva u statickoj klasi prijavljenog zaposlenika tako da su mu podaci svugdje dostupni 
        /// </summary>
        /// <param name="korisnickoIme"></param>
        /// <param name="Lozinka"></param>
        /// <returns></returns>
        public bool prijava(string korisnickoIme, string Lozinka)
        {
            bool prijava = false;
            string oib="";
            konekcija.Open();

            List<Zaposlenik> lista = new List<Zaposlenik>();
            lista = vratiSve("Zaposlenik",1) as List<Zaposlenik>;
           foreach(Zaposlenik i in lista)
            {
                if (i.KorisnickoIme.Equals(korisnickoIme) && i.Lozinka.Equals(Lozinka))
                {
                    prijava = true;
                    oib = i.OIB;
                    break;
                }
            }
            if (prijava)
            {
                prijavljeniZaposlenik = this.vratiJednog("Zaposlenik", oib) as Zaposlenik;
               
            }
           
            konekcija.Close();
            return prijava;
        }
    }
}
