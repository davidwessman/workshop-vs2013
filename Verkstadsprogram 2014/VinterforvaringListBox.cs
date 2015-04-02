using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verkstadsprogram_2014.Models;
using Verkstadsprogram_2014.Views;

namespace Verkstadsprogram_2014
{
    public partial class VinterforvaringListBox : UserControl
    {
        Vinterforvaring vinterforvaring;
        DateTime date;
        DateTime idag = DateTime.Today;
        Hamtning hamtning;
        Postnummer postnummer;
        public event EventHandler Uppdatera;
        public bool onlyActive;
        public VinterforvaringListBox()
        {
            InitializeComponent();
        }
        public void showVinterforvaring(Vinterforvaring vinterforvaring)
        {
            this.vinterforvaring = vinterforvaring;
            if (this.vinterforvaring != null)
            {                
                this.date = vinterforvaring.datum;
                this.textBoxDate.Text = veckodag(date) + " " + date.ToString("dd'/'MM'/'yy");
                this.listBoxVinter.DataSource = vinterforvaring.hamtningar;                
                this.listBoxPostnr.DataSource = vinterforvaring.postnummer;
            }            
        }       
        private string veckodag(DateTime dag)
        {
            var culture = new System.Globalization.CultureInfo("sv-SE");
            return FirstLetterToUpper(culture.DateTimeFormat.GetDayName(dag.DayOfWeek));
        }
        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
        private void listBoxVinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            hamtning = listBoxVinter.SelectedItem as Hamtning;
        }
        private void listBoxVinter_KeyDown(object sender, KeyEventArgs e)
        {
            if(listBoxVinter.SelectedIndex > -1)
            {
                bool change = false;
                hamtning = listBoxVinter.SelectedItem as Hamtning;
                DateTime datum = hamtning.Datum;                
                if(e.KeyCode == Keys.Back)
                {
                    hamtning.bestamd = false;
                    change = true;
                    hamtning.Update();
                }    
                
                if (this.Uppdatera != null && change)
                {
                    this.vinterforvaring.Update();
                    Uppdatera(this, new EventArgs());
                }
                    

            }
        }
        public void loadDate(DateTime date)
        {
            if (this.vinterforvaring != null)
                Save();
            this.date = date;
            Clear();
            textBoxDate.Text = veckodag(date) + " " + date.ToString("dd'/'MM'/'yy");
            this.vinterforvaring = Vinterforvaring.getWithDate(date);            
            bool exist = (vinterforvaring != null);
            if (!exist)
            {
                buttonAdd.Visible = true;
                buttonAdd.Enabled = true;
                if (onlyActive)
                    this.Visible = false;
                else
                    this.Visible = true;
            }
            else
            {
                this.Visible = true;
                buttonAdd.Visible = false;                
                listBoxVinter.DataSource = vinterforvaring.hamtningar;
                listBoxPostnr.DataSource = vinterforvaring.postnummer;
                
            }
            Enable(exist);
            if (date.CompareTo(idag) < 0)
                buttonAdd.Enabled = false;
        }
        private void Enable(bool check)
        {
            listBoxVinter.Enabled = check;
            listBoxPostnr.Enabled = check;
            textBoxSearch.Enabled = check;
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(date != null && date != Variables.notChosen && date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                vinterforvaring = new Vinterforvaring(date);
                vinterforvaring.Add();
                buttonAdd.Visible = false;
                Enable(true);
            }

        }
        private void Search_Postnummer(object sender, EventArgs e)
        {       
            string text = textBoxSearch.Text;            
            if (!String.IsNullOrEmpty(text))
            {
                listBoxSearch.DataSource = Postnummer.search(text as string);
                if (listBoxSearch.Items.Count > 0)
                    listBoxSearch.Visible = true;
            }
            else
            {
                listBoxSearch.Visible = false;
                listBoxSearch.DataSource = null;
            }           
        }
        private void Search_Postnummer_Keydown(object sender, KeyEventArgs e)
        {
            bool change = false;
            if (e.KeyCode == Keys.Enter && listBoxSearch.SelectedIndex > -1)
            {
                postnummer = listBoxSearch.SelectedItem as Postnummer;
                vinterforvaring.AddPostnummer(postnummer);
                textBoxSearch.Clear();
                listBoxSearch.DataSource = null;                
                change = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                listBoxSearch.DataSource = null;
                listBoxSearch.Visible = false;
            }
            if (this.Uppdatera != null && change)
            {
                this.vinterforvaring.Update();                
                Uppdatera(this, new EventArgs());                
            }
            
        }
        private void Clear()
        {
            this.listBoxVinter.DataSource = null;
            this.listBoxPostnr.DataSource = null;            
            this.textBoxSearch.Clear();
            this.listBoxSearch.DataSource = null;
        }
        private void listBoxPostnr_KeyDown(object sender, KeyEventArgs e)
        {
            bool change = false;
            if (e.KeyCode == Keys.Back && listBoxPostnr.SelectedIndex > -1)
            {
                postnummer = listBoxPostnr.SelectedItem as Postnummer;
                vinterforvaring.RemovePostnummer(postnummer);                
                listBoxSearch.DataSource = null;
                listBoxSearch.Visible = false;
                change = true;               
            }
            if (e.KeyCode == Keys.Enter && listBoxSearch.SelectedIndex > -1)
            {
                postnummer = listBoxSearch.SelectedItem as Postnummer;
                vinterforvaring.AddPostnummer(postnummer);
                textBoxSearch.Clear();
                listBoxSearch.DataSource = null;
                change = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                listBoxSearch.DataSource = null;
                listBoxSearch.Visible = false;
            }
            if (this.Uppdatera != null && change)
            {
                this.vinterforvaring.Update();                  
                Uppdatera(this, new EventArgs());
                
            }
        }

        private void listBoxVinter_DoubleClick(object sender, EventArgs e)
        {
            if(listBoxVinter.SelectedIndex > -1)
            {
                HamtningsForm form = new HamtningsForm(listBoxVinter.SelectedItem as Hamtning);
                form.Show();
            }
        }
        public void Save()
        {
            if(this.vinterforvaring != null)
            vinterforvaring.Update();
        }
    }
}
