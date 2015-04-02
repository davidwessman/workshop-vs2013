using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verkstadsprogram_2014.Models
{    
    
    public class Mode
    {
        public string mode { get; set; }
        public int kundnummer { get; set; }
        public string text { get; set; }

        public Mode(string mode, int kundnummer,string text)
        {
            this.mode = mode;
            this.kundnummer = kundnummer;
            this.text = text;
        }
        public Mode()
        {
            this.mode = String.Empty;
            this.kundnummer = 0;
            this.text = String.Empty;
        }
        public static Mode Load()
        {
            string search =  Databas.loadMode();
            Mode find = Databas.findMode(search);
            if(find == null)
            {
                find = new Mode("production", 1, "Produktion");
                find.Add();
            }
            return find;
        }
        public void ChangeMode()
        {
            Mode oldMode = Variables.mode;
            Databas.setMode(this);
            Variables.mode = this;
            if(this.kundnummer < oldMode.kundnummer)
            {
                DialogResult result1 = MessageBox.Show("Kundnummer för det nya läget är mindre än för det gamla, vill du behålla det gamla kundnummret?",
                "Kundnummerkonflikt",
                MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    this.kundnummer = oldMode.kundnummer;
                    this.Update();
                }
            }

        }
        public void Add()
        {
            Databas.addMode(this);
        }
        public void Update()
        {
            Databas.updateMode(this);
        }
        public void Remove()
        {
            Databas.removeMode(this);
        }
        public void plusKundnummer()
        {
            this.kundnummer++;
            this.Update();
        }
        public static List<Mode> getModes()
        {
            return Databas.getModes();
        }
        public override string ToString()
        {
            return text + " - " + mode;
        }
    }
}
