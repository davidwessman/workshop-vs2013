using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Verkstadsprogram_2014.Views;

namespace Verkstadsprogram_2014
{
    public partial class VinterforvaringForm : Form
    {
        BindingList<Hamtning> hamtningar = new BindingList<Hamtning>();
        BindingListView<Hamtning> view;
        DateTime date1;
        DateTime date2;
        DateTime date3;
        bool onlyActive;
        Hamtning hamtning;                
        
        public VinterforvaringForm()
        {
            InitializeComponent();
            dateE.Value = avoidWeekend(DateTime.Today);
            refreshIt();            
            dataHamtningar.Columns["inlagd"].Visible = false;
            dataHamtningar.Columns["hamtning"].Visible = false;
            dataHamtningar.Columns["ID"].Visible = false;
            dataHamtningar.Columns["PostnummerString"].Visible = false;
            dataHamtningar.Columns["kommentar"].Visible = false;
            dataHamtningar.Columns["maskin"].Visible = false;
            dataHamtningar.Columns["vinterforvaring"].Visible = false;            
            dataHamtningar.Columns["Datum"].Visible = false;
        }

        void searchCustomer1_CustomerFound(object sender, EventArgs e)
        {
            Customer customer = searchCustomer1.customer;            
                HamtningsForm form = new HamtningsForm(customer);
                form.Show(this);
            
        }        
       
        private void dateE_ValueChanged(object sender, EventArgs e)
        {
            date1 = avoidWeekend(dateE.Value);
            date2 = avoidWeekend(date1.AddDays(1));
            date3 = avoidWeekend(date2.AddDays(1));            
            refreshIt();            
        }
        public static DateTime avoidWeekend(DateTime date)
        {
            DateTime check;
            check = (date.DayOfWeek == DayOfWeek.Saturday) ? date.AddDays(2) : date;
            check = (check.DayOfWeek == DayOfWeek.Sunday) ? check.AddDays(1) : check;
            return check;

        }
        private void LoadDates()
        {
            vinterforvaring1.onlyActive = onlyActive;
            vinterforvaring2.onlyActive = onlyActive;
            vinterforvaring3.onlyActive = onlyActive;

            if (onlyActive && date1 != null && date2 != null && date3 != null)
            {
                while (date1.CompareTo(dateE.Value.AddDays(30)) < 0 && Vinterforvaring.getWithDate(date1) == null)
                {
                    date1 = avoidWeekend(date1.AddDays(1));
                }
                date2 = avoidWeekend(date1.AddDays(1));
                while (date2.CompareTo(dateE.Value.AddDays(31)) < 0 && Vinterforvaring.getWithDate(date2) == null)
                {
                    date2 = avoidWeekend(date2.AddDays(1));
                }
                date3 = avoidWeekend(date2.AddDays(1));
                while (date3.CompareTo(dateE.Value.AddDays(32)) < 0 && Vinterforvaring.getWithDate(date3) == null)
                {
                    date3 = avoidWeekend(date3.AddDays(1));
                }
            }
            if (date1 != null && date2 != null && date3 != null)
            {
                vinterforvaring1.loadDate(date1);
                vinterforvaring2.loadDate(date2);
                vinterforvaring3.loadDate(date3);
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
        private void vinterforvaring_Uppdatera(object sender, EventArgs e)
        {
            refreshIt();
        }

        private void VinterforvaringForm_Activated(object sender, EventArgs e)
        {
            refreshIt();
        }
        private void textBoxPostnummer_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxPostnummer.Text;
            if (!String.IsNullOrEmpty(text))
            {
                listBoxSearch.Visible = true;
                listBoxSearch.DataSource = Vinterforvaring.getWithPostnr(text);
            }
            else
            {
                listBoxSearch.Visible = false;
            }
        }
        private void listBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(listBoxSearch.SelectedIndex > -1 && e.KeyCode == Keys.Enter)
            {                
                Vinterforvaring vinter = listBoxSearch.SelectedItem as Vinterforvaring;
                if (dataHamtningar.CurrentCell != null && view != null && view.Count > 0)
                {
                    if (dataHamtningar.CurrentCell.RowIndex > -1 && dataHamtningar.CurrentCell.RowIndex < dataHamtningar.RowCount)
                    {
                        ObjectView<Hamtning> hamtningen = view[dataHamtningar.CurrentCell.RowIndex];
                        hamtning = hamtningen.Object;
                        if (hamtning != null)
                        {
                            hamtning.Datum = vinter.datum;
                            hamtning.bestamd = true;
                            vinter.hamtningar.Add(hamtning);
                            hamtning.Update();
                            vinter.Update();
                        }
                    }
                }
                refreshIt();
            }
        }
        private void VinterforvaringForm_Deactivate(object sender, EventArgs e)
        {
            
        }           
        private void refreshIt()
        {
            LoadDates();
            hamtningar.Clear();
            foreach (Hamtning a in Hamtning.Get(filterNotBestamd.Checked,FilterNotHamtad.Checked,FilterHamtad.Checked,FilterAll.Checked))
            {
                hamtningar.Add(a);
            }
            view = new BindingListView<Hamtning>(hamtningar);
            dataHamtningar.DataSource = view;            
        }
        private void checkOnlyActive_CheckedChanged(object sender, EventArgs e)
        {
            onlyActive = checkOnlyActive.Checked;
            LoadDates();
        }

        private void dataHamtningar_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataHamtningar.CurrentCell != null && view != null && view.Count > 0)
            {
                if (dataHamtningar.CurrentCell.RowIndex > -1 && dataHamtningar.CurrentCell.RowIndex < dataHamtningar.RowCount)
                {
                    ObjectView<Hamtning> hamtningen = view[dataHamtningar.CurrentCell.RowIndex];
                    hamtning = hamtningen.Object;
                    if (hamtning != null)
                    {
                        textBoxPostnummer.Text = hamtning.PostnummerString;
                    }
                }
            }
            else
            {
                textBoxPostnummer.Clear();
            }
        }

        private void VinterforvaringForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            vinterforvaring1.Save();
            vinterforvaring2.Save();
            vinterforvaring3.Save();
        }

        private void dataHamtningar_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode.Equals(Keys.ControlKey) && dataHamtningar.CurrentCell != null && view != null && view.Count > 0)
            {
                
                if (dataHamtningar.CurrentCell.RowIndex > -1 && dataHamtningar.CurrentCell.RowIndex < dataHamtningar.RowCount)
                {
                    ObjectView<Hamtning> hamtningen = view[dataHamtningar.CurrentCell.RowIndex];
                    hamtning = hamtningen.Object;
                    if (hamtning != null)
                    {
                        HamtningsForm form = new HamtningsForm(hamtning);
                        form.Show();
                    }
                  
                }
            }
        }
        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            refreshIt();
        }

        private void dataHamtningar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
