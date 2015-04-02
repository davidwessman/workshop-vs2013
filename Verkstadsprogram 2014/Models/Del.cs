using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verkstadsprogram_2014
{
    public class Del
    {
        public Reservdel reservdel { get; set; }
        public decimal antal { get; set; }
        


        public Del(Reservdel reservdel,decimal antal)
        {
            this.reservdel = reservdel;
            this.antal = antal;
        }
        public Del()
        {
            this.reservdel = new Reservdel();
            this.antal = antal;
        }
        public static List<Del> reservdelar(string delarna)
        {
            List<Del> result = new List<Del>();
            if (!String.IsNullOrEmpty(delarna))
            {
                string[] delar = delarna.Split(';');
                foreach (String a in delar)
                {
                    if (!String.IsNullOrEmpty(a))
                    {
                        string[] del = a.Split('€');
                        Reservdel delen = Reservdel.Find(del[1]);
                        if (delen != null)
                        {
                            Del reservdel = new Del(Reservdel.Find(del[1]), Convert.ToDecimal(del[0]));
                            if (!result.Contains(reservdel))
                                result.Add(reservdel);
                        }
                    }
                }                
            }
            return result;
        }
        public static string ReservdelarSpara(List<Del> delarna)
        {
            string result = String.Empty;
            foreach(Del a in delarna)
            {
                result += a.antal + "€" + a.reservdel.artikelNr + ";";
            }
            return result;
        }
        public override string ToString()
        {
            return this.antal + " - " + this.reservdel.artikelNr + " - "+this.reservdel.name;
        }
        public override bool Equals(object obj)
        {
            Del delen = obj as Del;
            return Equals(delen);
        }
        public bool Equals(Del delen)
        {
            return (delen != null && delen.antal.Equals(this.antal) && delen.reservdel.Equals(this.reservdel));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
