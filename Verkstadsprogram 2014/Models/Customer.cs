using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions; // för MessageBox
using Verkstadsprogram_2014.Models;

namespace Verkstadsprogram_2014
{
    public class Customer : IEquatable<Customer>
    {
        #region Attribut
        [System.ComponentModel.DisplayName("Förnamn")]
        public string firstNamn { get; set; }
        [System.ComponentModel.DisplayName("Efternamn")]
        public string lastNamn { get; set; }
        [System.ComponentModel.DisplayName("Telefonnr.")]
        public string phone { get; set; }
        [System.ComponentModel.DisplayName("Kundnr")]
        public string customerID { get; set; }
        [System.ComponentModel.DisplayName("Adress")]
        public Adress leveransadress { get; set; }
        public Adress fakturaadress { get; set; }
        [System.ComponentModel.DisplayName("Epost")]
        public string epost { get; set; }
        [System.ComponentModel.DisplayName("Tillagd")]
        public DateTime inlagd { get; set; }        
        [System.ComponentModel.DisplayName("Aktuell")]
        public bool aktuell { get; set; }
        public List<Maskin> maskiner { get; set; }       
        public bool foretag { get; set; }
        [System.ComponentModel.DisplayName("Org.nr.")]
        public string orgNr { get; set; }
        [System.ComponentModel.DisplayName("Företagsnamn")]
        public string foretagsnamn { get; set;}
        
        #endregion

        #region Konstruktorer
        public Customer(string namnet, string efternamn, string phone, string epost,string leveransadress, string fakturaadress, bool foretag, string orgNr, string foretagsnamn)
        {
            this.firstNamn = namnet;
            this.lastNamn = efternamn;
            this.phone = phone;
            this.leveransadress = new Adress(leveransadress);
            this.fakturaadress = new Adress(fakturaadress);          
            this.epost = epost;
            this.inlagd = DateTime.Now;
            this.customerID = Customer.nextCustomerID();            
            this.aktuell = false;
            this.maskiner = new List<Maskin>();
            this.foretag = foretag;
            this.orgNr = orgNr;
            this.foretagsnamn = foretagsnamn;                        
        }
        public Customer(string namnet, string efternamn, string phone, string epost, string adress1,string adress2, string postnr, string postort, bool foretag,string orgNr, string foretagsNamn)
        {
            this.firstNamn = namnet;
            this.lastNamn = efternamn;
            this.phone = phone;
            this.leveransadress = new Adress(adress1,adress2,postnr,postort);
            this.fakturaadress = new Adress(adress1,adress2, postnr, postort);
            this.epost = epost;
            this.inlagd = DateTime.Now;
            this.customerID = Customer.nextCustomerID();
            this.aktuell = false;
            this.maskiner = new List<Maskin>();
            this.foretag = foretag;
            this.orgNr = orgNr;
            this.foretagsnamn = foretagsnamn;  
        }
        public Customer(string customerID, string namnet, string efternamn, string phone, string epost, string leveransadress, string fakturaadress, DateTime inlagd, bool aktuell, bool foretag, string orgNr, string foretagsnamn)
        {
            this.customerID = customerID;
            this.firstNamn = namnet;
            this.lastNamn = efternamn;
            this.phone = phone;
            this.leveransadress = new Adress(leveransadress);
            this.fakturaadress = new Adress(fakturaadress); 
            this.epost = epost;
            this.inlagd = inlagd;            
            this.aktuell = false;
            this.maskiner = new List<Maskin>();
            this.foretag = foretag;
            this.orgNr = orgNr;
            this.foretagsnamn = foretagsnamn;
        }
        public Customer()
        {
            this.customerID = Customer.nextCustomerID();
            this.firstNamn = String.Empty;
            this.lastNamn = String.Empty;
            this.phone = String.Empty;
            this.epost = String.Empty;
            this.leveransadress = new Adress();
            this.fakturaadress = new Adress();            
            this.inlagd = DateTime.Now;            
            this.maskiner = new List<Maskin>();            
            this.foretag = false;
            this.orgNr = String.Empty;
            this.foretagsnamn = String.Empty;
        }
        #endregion
        public string LeveransAdress1
        {
            get { return leveransadress.adress1; }
            set { leveransadress = new Adress(value,leveransadress.adress2,leveransadress.postnummer,leveransadress.postort); }
        }
        public string LeveransAdress2
        {
            get { return leveransadress.adress2; }
            set { leveransadress = new Adress(leveransadress.adress1,value, leveransadress.postnummer, leveransadress.postort); }
        }
        public string LeveransPostnr
        {
            get { return leveransadress.postnummer; }
            set { leveransadress = new Adress(leveransadress.adress1,leveransadress.adress2, value, leveransadress.postort); }
        }
        public string LeveransPostort
        {
            get { return leveransadress.postort; }
            set { leveransadress = new Adress(leveransadress.adress1,leveransadress.adress2, leveransadress.postnummer, value); }
        }
        public string FakturaAdress1
        {
            get { return fakturaadress.adress1; }
            set { fakturaadress = new Adress(value,fakturaadress.adress2,fakturaadress.postnummer, fakturaadress.postort); }
        }
        public string FakturaAdress2
        {
            get { return fakturaadress.adress2; }
            set { fakturaadress = new Adress(fakturaadress.adress1,value, fakturaadress.postnummer, fakturaadress.postort); }
        }
        public string FakturaPostnr
        {
            get { return fakturaadress.postnummer; }
            set { fakturaadress = new Adress(leveransadress.adress1,leveransadress.adress2, value, fakturaadress.postort); }
        }
        public string FakturaPostort
        {
            get { return fakturaadress.postort; }
            set { fakturaadress = new Adress(leveransadress.adress1, leveransadress.adress2, fakturaadress.postnummer, value); }
        }
        public Postnummer PostnummerLeverans
        {
            get { return Postnummer.Find(LeveransPostnr); }
        }
        public Postnummer PostnummerFaktura
        {
            get { return Postnummer.Find(FakturaPostnr); }
        }

        #region Metoder
        public bool Add()
        {
            bool add = false;
            if(Databas.searchCustomerID(this.customerID) == null)
            {                
                Databas.addCustomer(this);
                add = true;
                Variables.mode.plusKundnummer();
            }
            return add;
        }
        public void Update()
        {                        
            Databas.updateCustomer(this);
            foreach(Maskin a in maskiner)
            {
                a.Update();
            }
        }
        public void Load()
        {
            this.maskiner = Maskiner();
        }
        public void Remove()
        {
            this.Load();
            if(maskiner != null && maskiner.Count > 0)
                foreach(Maskin a in maskiner)
                {
                    a.Remove();
                }
            List<Hamtning> hamtningar = Databas.getHamtningCustomer(this.customerID);
            if (hamtningar != null && hamtningar.Count > 0)
                foreach (Hamtning a in hamtningar)
                {
                    a.Remove();
                }
            Databas.removeCustomer(this);
        }
        public bool hasMachine(Maskin maskin)
        {
            bool check = false;
            if(maskin != null)
            {
                foreach (Maskin search in this.maskiner)
                {
                    if (maskin.Equals(search))
                    {
                        check = true;                        
                    }
                }
            }
            
            return check;
        }
        public Maskin AddMachine(Maskin maskin)
        {            
            if(maskin != null && !hasMachine(maskin))
            {
                maskin.customerID = this.customerID;
                maskin.maskinID = this.customerID + "-" + (this.maskiner.Count+1).ToString().PadLeft(2, '0');
                this.maskiner.Add(maskin);
                maskin.Add();                
                this.Update();
                
                return maskin;
            }
            return null;                            
        }
        private List<Maskin> Maskiner()
        {
            return Databas.getCustomersMachines(this.customerID);
        }
        private List<Hamtning> Hamtningar()
        {
            return Databas.getHamtningCustomer(this.customerID);
        }
        public static string PostnummerFix(string postnr)
        {
            if (!String.IsNullOrEmpty(postnr))
            {
                if (postnr.Trim().Length == 5)
                {
                    string[] test = Regex.Split(postnr, string.Empty);
                    bool changed = false;
                    foreach (string s in test)
                    {
                        if (s == " ")
                            changed = true;
                    }
                    if (!changed)
                    {
                        postnr = String.Empty;
                        postnr += test[1];
                        postnr += test[2];
                        postnr += test[3];
                        postnr += " ";
                        postnr += test[4];
                        postnr += test[5];
                    }
                }
                else if (postnr.Trim().Length == 4)
                {
                    string[] test = Regex.Split(postnr, string.Empty);
                    bool changed = false;
                    foreach (string s in test)
                    {
                        if (s == " ")
                            changed = true;
                    }
                    if (!changed)
                    {
                        postnr = String.Empty;
                        postnr += test[1];
                        postnr += test[2];
                        postnr += test[3];
                        postnr += " ";
                        postnr += test[4];
                    }
                }
            }
            return postnr;
        }
        public static BindingList<Customer> getCustomers(bool aktuell) 
        {
            return Databas.getCustomers(aktuell);
        }
        public static Customer Find(string customerID)
        {
           return (Databas.searchCustomer(customerID)).FirstOrDefault<Customer>();
        }        
        public static List<Customer> Search(string text)        {

            List<Customer> search = Databas.searchCustomer(text);
            if (search.Count == 0)
            {
                string[] splitt = Regex.Split(text, " ", RegexOptions.IgnoreCase);
                foreach (String a in splitt)
                {
                    if (!String.IsNullOrEmpty(a))
                    {
                        List<Customer> check = Databas.searchCustomer(a);
                        foreach (Customer b in check)
                        {
                            if (!search.Contains(b))
                                search.Add(b);
                        }
                    }
                }
            }           
            return search;
        }
       
         public static string nextCustomerID()
        {
            return DateTime.Now.ToString("yy") + "-" + Variables.mode.kundnummer.ToString().PadLeft(3, '0');
        }
        #endregion
        //Använda som displaymember istället för att overrida ToString()
        public string Display
         {
             get
             {
                 return (customerID + " - " + firstNamn + " " + lastNamn);
             }
         }
        public override string ToString()
        {
            return (customerID + " - " + firstNamn + " " + lastNamn);
        }
        public bool Equals(Customer other)
        {
            return (other != null &&
                    other.leveransadress.Equals(this.leveransadress) &&
                    other.fakturaadress.Equals(this.fakturaadress) &&                    
                    other.epost.Equals(this.epost) &&
                    other.firstNamn.Equals(this.firstNamn) &&
                    other.lastNamn.Equals(this.lastNamn) &&
                    other.phone.Equals(this.phone) &&
                    other.foretag == this.foretag &&
                    other.orgNr.Equals(this.orgNr) &&
                    other.foretagsnamn.Equals(this.foretagsnamn));
        }
        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            if(customer != null)
            {
                return Equals(customer);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            // Which is preferred?

            //return base.GetHashCode();

            return this.customerID.GetHashCode();
        }
    }
    public struct Adress
    {
        public string adress1;
        public string adress2;
        public string postnummer;
        public string postort;        
        public Adress(string adress)
        {
            string[] splitt = adress.Split('€');
            
            if(splitt.Length == 4)
            {
                this.adress1 = splitt[0];
                this.adress2 = splitt[1];
                this.postnummer = splitt[2];
                this.postort = splitt[3];
                if((String.IsNullOrEmpty(this.adress1) && String.IsNullOrEmpty(this.adress2)) || String.IsNullOrEmpty(this.postnummer) || String.IsNullOrEmpty(this.postort))
                {
                    this.adress1 = String.Empty;
                    this.adress2 = String.Empty;
                    this.postnummer = String.Empty;
                    this.postort = String.Empty;
                }
            }
            else
            {
                this.adress1 = String.Empty;
                this.adress2 = String.Empty;
                this.postnummer = String.Empty;
                this.postort = String.Empty;
            }
        }
        public Adress(string adress1,string adress2,string postnummer,string postort)
        {
            this.adress1 = adress1;
            this.adress2 = adress2;
            this.postnummer = Customer.PostnummerFix(postnummer);
            this.postort = postort;
        }        
        public string Save()
        {
            return this.adress1 + "€" + "€" + this.postnummer + "€" + this.postort;
        }
        public override string ToString()
        {
            return adress1 +" "+adress2+ ", " + postnummer + ", " + postort;
        }
    }
}
