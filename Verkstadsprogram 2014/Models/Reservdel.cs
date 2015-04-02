using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verkstadsprogram_2014
{
    public class Reservdel
    {
        public string artikelNr { get; set; }
        public int ID { get; set; }
        public string barcode { get; set; }
        public string name { get; set; }
        public bool orderDel { get; set; }


        public Reservdel(int ID,string artikelnr, string barcode, string name,bool orderDel)
        {
            this.artikelNr = artikelnr;
            this.ID = ID;
            this.barcode = barcode;
            this.name = name;
            this.orderDel = orderDel;            
        }
        public Reservdel()
        {
            this.artikelNr = "";
            this.ID = Int32.MinValue;
            this.barcode = "";
            this.name = "";
            this.orderDel = false;            
        } 
        public Reservdel(string name)
        {
            this.artikelNr = "";
            this.ID = Int32.MinValue;
            this.barcode = "";
            this.name = name;
            this.orderDel = false;            
        }
        public void Update()
        {
            Reservdel search = Find(this.artikelNr);            
            if (search != null)
            {                
                Databas.updateReservdel(this);                
            }
                
            else
            {             
                Databas.addReservdel(this);
            }
        }
        public static List<Reservdel> Search(string text)
        {
            return Databas.searchReservdel(text);
        }
        public static List<Reservdel> GetAll()
        {
            return Databas.getReservdelar();
        }
        public static Reservdel Find(string text)
        {
            Reservdel find = null;            
            List<Reservdel> search = Search(text);           
            if(search.Count > 0)
            {
                find = search.FirstOrDefault<Reservdel>();
            }
            return find;
        }
        public static Reservdel FindID(int ID)
        {
            Reservdel find = Databas.searchReservdel(ID);
            return find;            
        }        
        public static List<Reservdel> getAllOrder()
        {
            List<Reservdel> result = null;
            result = Databas.allOrder();
            return result;
        }
        public override string ToString()
        {
            return this.artikelNr + " - " + this.name;
        }
        public bool Equals(Reservdel delen)
        {
            return (delen != null && delen.artikelNr.Equals(this.artikelNr) && delen.barcode.Equals(this.barcode) && delen.name.Equals(this.name));
        }
        public override bool Equals(object obj)
        {
            Reservdel delen = obj as Reservdel;
            return Equals(delen);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
