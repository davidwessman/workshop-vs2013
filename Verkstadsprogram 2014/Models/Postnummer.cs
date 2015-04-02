using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verkstadsprogram_2014.Models
{
    public class Postnummer
    {
        public int ID { get; set; }
        [System.ComponentModel.DisplayName("Ort")]
        public string ort { get; set; }
        [System.ComponentModel.DisplayName("Postnummer")]
        public string postnummer { get; set; }
        public Postnummer(int ID, string postnummer, string ort)
        {
            this.ID = ID;
            this.ort = ort;
            this.postnummer = Customer.PostnummerFix(postnummer);
        }        
        public Postnummer(string postnummer, string ort)
        {            
            this.ort = ort;
            this.postnummer = Customer.PostnummerFix(postnummer);
            this.ID = 99;
        }
        public Postnummer()
        {
            this.postnummer = String.Empty;
            this.ort = String.Empty;
            this.ID = 99;
        }
        public void Add()
        {
            if (!checkExist() && !String.IsNullOrWhiteSpace(ort) && !String.IsNullOrWhiteSpace(postnummer))
            {
                int i = Databas.addPostnummer(this);
                if (i > 0)
                    this.ID = i;
            }
        }
        public void Update()
        {
            if(ID != 99 && ID != 0)
                Databas.updatePostnummer(this);
        }
        public void Remove()
        {
            Databas.removePostnummer(this);
        }
        public static String OrtWhere(string postnummer)
        {
            return Databas.getPostnummer(postnummer).ort;
        }
        public static Postnummer Find(string postnummer)
        {
            return Databas.getPostnummer(postnummer);
        }
        public static List<Postnummer> searchOrt(string ort)
        {
            return Databas.searchOrt(ort);
        }
        public static List<Postnummer> searchPostnummer(string postnummer)
        {
            return Databas.searchPostnummer(postnummer);
        }
        public static List<Postnummer> search(string text)
        {
            List<Postnummer> check = new List<Postnummer>();
            check = Databas.searchPostnummer(text);
            if (check.Count == 0)
                check = Databas.searchOrt(text);
            if (check.Count == 0)
            {
                text = Customer.PostnummerFix(text);
                check = Databas.searchPostnummer(text);
            }
            return check;
        }
        public static List<Postnummer> getAll()
        {
            return Databas.getAllPostnummer();
        }
        private bool checkExist()
        {
            bool check = Equals(Databas.SearchPostnummer(this.postnummer, this.ort));
            return check;
        }
        public bool Equals(Postnummer obj)
        {
            return (obj != null && obj.ort.Equals(this.ort) && obj.postnummer.Equals(this.postnummer));
        }
        public override string ToString()
        {
            return this.postnummer + ", " + this.ort;
        }
        public override bool Equals(object obj)
        {
            Postnummer check = obj as Postnummer;
            return this.Equals(check);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
