using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verkstadsprogram_2014
{
    public class Modell
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string sort { get; set; }
        public List<String> productNbrs { get; set; }
        public List<Reservdel> reservdelar { get; set; }
        public List<String> motorNbrs { get; set; }

        public Modell(string name, string brand, string sort)
        {
            this.ID = Int32.MinValue;
            this.name = name;
            this.brand = brand;
            this.sort = sort;            
            this.productNbrs = new List<String>();
            this.reservdelar = new List<Reservdel>();
            this.motorNbrs = new List<String>();
        }
        public Modell(int ID,string name, string brand, string sort,string productNbrs,string reservdelar,string motorNbrs)
        {
            this.ID = ID;
            this.name = name;
            this.brand = brand;
            this.sort = sort;
            this.productNbrs = new List<String>();
            string[] splitted = productNbrs.Split(';');
            foreach (String a in splitted)
            {
                this.AddProductNbr(a);
            }
            this.reservdelar = new List<Reservdel>();
            splitted = reservdelar.Split(';');            
            foreach(String a in splitted)
            {
                if(!String.IsNullOrEmpty(a.Trim()))
                {                    
                    Reservdel delen = Reservdel.FindID(Convert.ToInt32(a));
                    this.AddReservdel(delen);                    
                }                
            }
            this.motorNbrs = new List<String>();
            splitted = motorNbrs.Split(';');
            foreach (String a in splitted)
            {
                this.AddMotorNbr(a);
            }
        }        
        public void Update()
        {
            string productNbr = String.Empty;
            string reservdel = String.Empty;
            string motorNbr = String.Empty;
            foreach (String a in productNbrs)
            {
                productNbr += a + ";";
            }
            foreach (Reservdel a in reservdelar)
            {                
                reservdel += a.ID.ToString() + ";";
            }
            foreach (String a in motorNbrs)
            {
                motorNbr += a + ";";
            }
            if (!checkExist())
            {
                this.ID = Databas.addModel(this, productNbr, reservdel, motorNbr);                
            }
            else
            {
                Databas.updateModel(this, productNbr, reservdel, motorNbr);
            }            
        }
        public void Remove()
        {
            Databas.removeModel(this);
        }
        public void AddProductNbr(string number)
        {            
            if (!String.IsNullOrEmpty(number) && !productNbrs.Contains(number))
                productNbrs.Add(number);            
        }
        public void AddMotorNbr(string number)
        {
            if (!String.IsNullOrEmpty(number) && !motorNbrs.Contains(number))
                motorNbrs.Add(number);
        }
        public void AddReservdel(Reservdel delen)
        {            
            if(delen != null && !hasPart(delen))
            {                
                this.reservdelar.Add(delen);
            }
        
        }
        public bool checkExist()
        {
            Modell check = Databas.searchModel(this.name, this.brand, this.sort);
            return this.Equals(check);
        }
        private bool hasPart(Reservdel delen)
        {
            bool exists = false;
            foreach(Reservdel a in this.reservdelar)
            {
                if (a.Equals(delen))
                    exists = true;
            }
            return exists;
        }
       
        public static List<Modell> FindModels(string brand, string sort)
        {
            return Databas.getModels(brand, sort);
        }        
        public void Destroy()
        {
            Databas.removeModel(this);
        }
        public override string ToString()
        {
            if (this != null)
                return this.name;
            else return "";
        }
        public bool Equals(Modell compare)
        {
            return (compare != null && this.brand == compare.brand && this.sort == compare.sort && this.name == compare.name);
        }
        public override bool Equals(object obj)
        {
            Modell model = obj as Modell;
            return Equals(model);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
