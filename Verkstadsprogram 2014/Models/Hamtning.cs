using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verkstadsprogram_2014.Models;

namespace Verkstadsprogram_2014
{
    public class Hamtning
    {
        #region Attribut
        public int ID { get; set; }
        [System.ComponentModel.DisplayName("Inlagd")]
        public DateTime inlagd { get; set; }
        [System.ComponentModel.DisplayName("Hämtning")]
        public DateTime hamtning { get; set; }
        [System.ComponentModel.DisplayName("Kund")]
        public Customer customer { get; set; }
        [System.ComponentModel.DisplayName("Märke")]
        public string brand { get; set; }
        [System.ComponentModel.DisplayName("Sort")]
        public string type { get; set; }
        [System.ComponentModel.DisplayName("Modell")]
        public string modell { get; set; }       
        [System.ComponentModel.DisplayName("Pinkod")]
        private string pincode { get; set; }
        [System.ComponentModel.DisplayName("Kommentar")]
        public string kommentar { get; set; }
        [System.ComponentModel.DisplayName("Maskin")]
        public Maskin maskin { get; set; }
        [System.ComponentModel.DisplayName("Hämtad")]
        public bool hamtad { get; set; }                
        public bool vinterforvaring { get; set; }
        public bool bestamd { get; set; }
        #endregion
        #region Konstruktorer
        public Hamtning(int ID, string customerID, string brand, string type, string modell, string pincode, string kommentar, DateTime inlagd, DateTime hamtning, string maskinID,bool hamtad,bool vinterforvaring,bool bestamd)
        {
            this.ID = ID;
            this.customer = Customer.Find(customerID);
            this.brand = brand;
            this.type = type;
            this.modell = modell;            
            this.pincode = pincode;
            this.kommentar = kommentar;
            this.inlagd = inlagd;            
            this.hamtning = removeHours(hamtning);
            this.bestamd = bestamd;
            this.maskin = Maskin.Find(maskinID);            
            this.hamtad = hamtad;                                    
            this.vinterforvaring = vinterforvaring;
        }
        public Hamtning(Customer customer, string brand, string type, string modell, string pincode, string kommentar, DateTime hamtning,Maskin maskin,bool vinterforvaring,bool bestamd)
        {
            this.customer = customer;
            this.brand = brand;
            this.type = type;
            this.modell = modell;            
            this.pincode = pincode;
            this.kommentar = kommentar;
            this.inlagd = inlagd;
            this.hamtning = removeHours(hamtning);
            this.maskin = maskin;
            this.hamtad = false;           
            this.vinterforvaring = vinterforvaring;
            this.bestamd = bestamd;
        }
        public Hamtning(Customer customer, string kommentar,DateTime hamtning, Maskin maskin,bool vinterforvaring)
        {
            this.customer = customer;
            this.brand = maskin.brand;
            this.type = maskin.type;
            this.modell = maskin.modell;            
            this.pincode = maskin.getPinCode(true);
            this.kommentar = kommentar;
            this.inlagd = DateTime.Now;            
            this.hamtning = removeHours(hamtning);
            this.maskin = maskin;
            this.hamtad = false;            
        }
        public Hamtning()
        {
            this.customer = null;
            this.brand = String.Empty;
            this.type = String.Empty;
            this.modell = String.Empty;            
            this.pincode = String.Empty;
            this.kommentar = String.Empty;
            this.inlagd = DateTime.Today;
            this.hamtning = Hamtning.removeHours(Variables.notChosen);
            this.maskin = null;
            this.hamtad = false;
            this.bestamd = false;
        }
        #endregion
        public Postnummer Postnummer
        {
            get 
            {
                if (customer != null)
                    return customer.PostnummerLeverans;
                else
                    return null;
            }
        }
        public string PostnummerString
        {
            get
            {
                if (customer != null)
                    return customer.LeveransPostnr;
                else
                    return String.Empty;
            }
        }
        #region Metoder
        public void Add()
        {
            int i = Databas.addHamtning(this);
            if (i > 0)
                this.ID = i;
        }
        public void Update()
        {
            Databas.updateHamtning(this);
        }
        public void Remove()
        {
            Databas.removeHamtning(this);
        }
        public DateTime Datum
        {
            get {
                return this.hamtning;
            }
            set {                
            this.hamtning = removeHours(value);
            }
        }
        public Maskin getMaskin()
        {
            if(maskin == null)
            {
                maskin = new Maskin(brand,type,String.Empty,modell,String.Empty,String.Empty,String.Empty,pincode,customer,String.Empty);
            }
            return maskin;
        }   
        public static Hamtning FindID(int ID)
        {
            return Databas.searchHamtning(ID);
        }
        public static Hamtning Find(string ID)
        {
            return Databas.searchHamtning(ID);
        }
        public static List<Hamtning> Aktuella(bool aktuell)
        {
           return Databas.getAktuellHamtning(aktuell);
        }
        public static List<Hamtning> Get(bool ejBestamda,bool ejHamtade,bool hamtade, bool alla)
        {
            return Databas.getHamtning(ejBestamda,ejHamtade,hamtade,alla);
        }               
        public static List<Hamtning> forDate(DateTime date)
        {
            TimeSpan ts = new TimeSpan(date.Hour, date.Minute, date.Second);
            return Databas.getHamtningForDate(date-ts);
        }        
        public static List<Hamtning> forPostnummer(string postnummer)
        {
            return Databas.getHamtningPostnummer(postnummer);
        }
        public string getPinCode(bool access)
        {
            string a = String.Empty;
            if (access)
                a = this.pincode;

            return a;
        }
        public void setPinCode(string pin)
        {
            if(!String.IsNullOrEmpty(pin))
                this.pincode = pin;
        }        
        public bool Move(bool forward)
        {
            
            DateTime datum = this.Datum;
            int move = (forward) ? 1 : -1;
            Vinterforvaring vinter = Vinterforvaring.getWithDate(datum.AddDays(move));            
            
            if (vinter == null)
            {
                if (datum.AddDays(move).CompareTo(DateTime.Today) >= 0)
                {
                    DialogResult result1 = MessageBox.Show("Det finns ingen planerad hämtning för " + datum.AddDays(move).ToString("dd'/'MM'/'yyyy") + ".\nVill du lägga till det?",
                    "Lägg till hämtning",
                    MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        vinter = new Vinterforvaring(datum.AddDays(move));
                        vinter.Add();
                    }
                }
                else
                {
                    MessageBox.Show("Det finns ingen planerad hämtning för " + datum.AddDays(move).ToString("dd'/'MM'/'yyyy") + " och dagen har redan varit.\nHämtningen flyttades inte.");
                    return false;
                }
            }
            if(vinter != null)
            {                
                this.Datum = datum.AddDays(move);
                if (this.Datum.DayOfWeek == DayOfWeek.Sunday)
                    this.Datum = datum.AddDays(move * 2);
                this.Update();
                return true;
            }
            return false;
        }
        #endregion
        public bool Equals(Hamtning obj)
        {
            return (obj != null && obj.customer.Equals(this.customer) && obj.brand == this.brand && obj.type == this.type && obj.modell == this.modell);
        }
        public override string ToString()
        {
            string postnummer = (Postnummer != null) ? Postnummer.ToString() : String.Empty;
            return customer.firstNamn + " " + customer.lastNamn + " - " + type + " - " + postnummer;
        }
        public static DateTime removeHours(DateTime check)
        {
            TimeSpan ts = new TimeSpan(check.Hour, check.Minute, check.Second);
            return check - ts;
        }
        public override bool Equals(object obj)
        {
            Hamtning hamtning = obj as Hamtning;
            if(hamtning != null)
                return Equals(hamtning);
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
