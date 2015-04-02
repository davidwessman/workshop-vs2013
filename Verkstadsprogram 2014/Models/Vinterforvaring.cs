using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // messagebox
using System.Threading.Tasks;
using System.Windows.Forms;
using Verkstadsprogram_2014.Models;

namespace Verkstadsprogram_2014
{    
    public class Vinterforvaring
    {

        public int ID;
        [System.ComponentModel.DisplayName("Datum")]
        public DateTime datum { get; set; }
        public List<Hamtning> hamtningar { get; set; }
        public List<Postnummer> postnummer { get; set; }
        public bool done { get; set; }
        public Vinterforvaring()
        {
            DateTime datum = DateTime.Today;
            TimeSpan ts = new TimeSpan(datum.Hour, datum.Minute, datum.Second);
            this.datum = datum - ts;            
            this.hamtningar = new List<Hamtning>();
            this.postnummer = new List<Postnummer>();
            this.done = false;
        }       
        public Vinterforvaring(DateTime datum)
        {            
            TimeSpan ts = new TimeSpan(datum.Hour, datum.Minute, datum.Second);
            this.datum = datum - ts;
            this.hamtningar = Hamtning.forDate(datum);            
            this.postnummer = new List<Postnummer>();
            foreach(Hamtning a in hamtningar)
            {               
                if(a.Postnummer != null && !postnummer.Contains(a.Postnummer))
                {
                    postnummer.Add(a.Postnummer);
                }
            }
            this.done = false;
        }
        public Vinterforvaring(int ID,DateTime datum, bool done,string postnummer)
        {
            this.ID = ID;
            TimeSpan ts = new TimeSpan(datum.Hour, datum.Minute, datum.Second);
            this.datum = datum - ts;            
            this.hamtningar = Hamtning.forDate(datum);            
            this.postnummer = LoadPostnummer(postnummer);                      
            this.done = done;            
        }
        public void Add()
        {            
            if(!checkExist())
                this.ID = Databas.addVinterforvaring(this);                      
            
        }
        public void Update()      
        {   
            if(checkExist())
                Databas.updateVinterforvaring(this);
        }
        public void Remove()
        {
            foreach(Hamtning a in hamtningar)
            {
                a.bestamd = false;
                a.Update();
            }
            Databas.removeVinterforvaring(this);            
        }        
        public void AddPostnummer(Postnummer newPostnr)
        {
            if(!postnummer.Contains(newPostnr))
            {
                postnummer.Add(newPostnr);                
            }
            this.Update();
        }
        public void RemovePostnummer(Postnummer post)
        {
            if (postnummer.Contains(post))
            {
                postnummer.Remove(post);                
            }
                
            this.Update();
        }
        public List<Postnummer> LoadPostnummer(string text)
        {
            List<Postnummer> post = new List<Postnummer>();
            foreach (Hamtning a in hamtningar)
            {
                if (!post.Contains(a.Postnummer))
                {
                    post.Add(a.Postnummer);
                }
            }
            string[] splitt = text.Split(';');
            foreach (String a in splitt)
            {
                Postnummer posten = Postnummer.Find(a);
                if (!post.Contains(posten))
                    post.Add(posten);
            }
            return post;
        }
        public string SavePostnummer()
        {
            string postnummer = String.Empty;
            foreach (Hamtning a in this.hamtningar)
            {
                if (a != null && !postnummer.Contains(a.PostnummerString))
                    postnummer += a.PostnummerString+ ";";
            }
            foreach (Postnummer a in this.postnummer)
            {
                if (a != null && !postnummer.Contains(a.postnummer))
                    postnummer += a.postnummer + ";";
            }
            return postnummer;
        }
        public static Vinterforvaring getWithDate(DateTime date)
        {            
            return Databas.getVinterforvaringDate(date);         
        }
        public static List<Vinterforvaring> getWithPostnr(string postnummer)
        {
            List<Vinterforvaring> check = null;
            check = Databas.getVinterforvaringPostnr(postnummer);
            return check;
        }
        public static List<Vinterforvaring> getActive()
        {
            return Databas.getActiveVinterforvaring();
        }
        public override string ToString()
        {
            string print = datum.ToString("dd'/'MM'/'yy");
            if(postnummer != null && postnummer.Count > 0)
                foreach(Postnummer a in postnummer)
                {
                    if(a != null)
                        print += " - " + a.postnummer;   
                }
            return print;
        }
        public override bool Equals(object obj)
        {
            if(obj != null)
            {
                Vinterforvaring vinter = obj as Vinterforvaring;
                return Equals(vinter);
            }
            return false;
        }
        public bool Equals(Vinterforvaring vinter)
        {
            return (vinter != null && vinter.datum.Equals(this.datum));
        }
        public bool checkExist()
        {
            return (Vinterforvaring.getWithDate(this.datum) != null);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
