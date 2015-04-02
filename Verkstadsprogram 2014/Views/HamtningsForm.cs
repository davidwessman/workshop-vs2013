using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verkstadsprogram_2014.Models;

namespace Verkstadsprogram_2014.Views
{
    public partial class HamtningsForm : Form
    {
        Hamtning hamtning;
        Customer customer;
        List<Maskin> maskiner = new List<Maskin>();
        Maskin maskin;
        Modell model;
        List<Modell> models;        
        Vinterforvaring vinterforvaring;
        bool newHamtning;
        public HamtningsForm(Customer customer)
        {
            InitializeComponent();
            LoadForm();
            hamtning = new Hamtning();
            this.customer = customer;
            hamtning.customer = this.customer;
            this.customer = customer;
            customer.Load();           
            
            listBoxMaskiner.DataSource = customer.maskiner;            
            radioButtonNew.Checked = (customer.maskiner.Count == 0);
            textBoxPostnummer.Text = customer.LeveransPostnr;
            newHamtning = true;
            hamtningDateTimePicker.Value = VinterforvaringForm.avoidWeekend(hamtningDateTimePicker.Value);
        }
        public HamtningsForm(Hamtning hamtning)
        {
            InitializeComponent();
            LoadForm();
            this.hamtning = hamtning;
            this.customer = hamtning.customer;            
            customer.Load();            
            listBoxMaskiner.DataSource = customer.maskiner;
            newHamtning = false;
            buttonRemove.Visible = true;
            showHamtning();
            textBoxPostnummer.Text = customer.LeveransPostnr;
            buttonNewHamtning.Visible = true;
            hamtningDateTimePicker.Value = VinterforvaringForm.avoidWeekend(hamtningDateTimePicker.Value);
            if (hamtning.maskin != null && listBoxMaskiner.Items.Count > 0)
            {
                string maskinen = hamtning.maskin.ToString();
                int index = listBoxMaskiner.FindString(maskinen);
                if (index > -1 && index < listBoxMaskiner.Items.Count)
                    listBoxMaskiner.SetSelected(index, true);
            }
            
        }

        private void showHamtning()
        {
            listBoxBrand.Text = hamtning.brand;
            listBoxSort.Text = hamtning.type;
            listBoxModell.Text = hamtning.modell;
            checkBoxVinterforvaring.Checked = hamtning.vinterforvaring;
            checkBoxBestamd.Checked = hamtning.bestamd;
            richTextBoxKommentar.Text = hamtning.kommentar;
            checkBoxHamtad.Checked = hamtning.hamtad;
            if (hamtning.bestamd)
                hamtningDateTimePicker.Value = hamtning.hamtning;
            if(hamtning.customer != null)
            {
                customer.Load();
                listBoxMaskiner.DataSource = customer.maskiner;
            }

        }
        public HamtningsForm(Customer customer, Maskin maskin)
        {
            InitializeComponent();
            LoadForm();
            this.customer = customer;
            this.maskin = maskin;
            hamtning = new Hamtning(customer, String.Empty, Variables.notChosen, maskin,false);            
        }
        private void LoadForm()
        {
            listBoxBrand.DataSource = Variables.brandLista;
            listBoxSort.DataSource = Variables.typeList;
            listBoxBrand.ClearSelected();
            listBoxSort.ClearSelected();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveHamtning();            
            if(hamtning.bestamd)
            {                              
                vinterforvaring = Vinterforvaring.getWithDate(hamtning.Datum);                
                if (vinterforvaring == null)
                {
                    if (hamtning.Datum.CompareTo(DateTime.Today) >= 0)
                    {
                        DialogResult result1 = MessageBox.Show("Det finns ingen planerad hämtning för " + hamtning.Datum.ToString("dd'/'MM'/'yyyy") + ".\nVill du lägga till det?",
                        "Lägg till hämtning",
                        MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            vinterforvaring = new Vinterforvaring(hamtning.Datum);
                            vinterforvaring.Add();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Det finns ingen planerad hämtning för " + hamtning.Datum.ToString("dd'/'MM'/'yyyy") + " och dagen har redan varit.\nHämtningen flyttades inte.");                        
                    }                    
                }
            }
            if (newHamtning)
            {
                hamtning.Add();                
            }
            else
            {
                hamtning.Update();                
            }
            if(vinterforvaring != null)
                vinterforvaring.Update();    
            
        }
        private void SaveHamtning()
        {            
            hamtning.brand = listBoxBrand.Text;
            hamtning.type = listBoxSort.Text;
            hamtning.modell = listBoxModell.Text;            
            hamtning.setPinCode(textBoxPinkod.Text);
            hamtning.kommentar = richTextBoxKommentar.Text;

            if (!String.IsNullOrEmpty(textBoxModell.Text))
            {
                hamtning.modell = textBoxModell.Text;
                model = new Modell(hamtning.modell, hamtning.brand, hamtning.type);
                listBoxModell.SelectedIndex = -1;
                model.Update();
            }
            else if (listBoxModell.SelectedIndex > -1)
            {
                model = listBoxModell.SelectedItem as Modell;
                hamtning.modell = model.name;
            }

            if (listBoxMaskiner.SelectedIndex > -1)
                hamtning.maskin = listBoxMaskiner.SelectedItem as Maskin;
            hamtning.vinterforvaring = checkBoxVinterforvaring.Checked;
            hamtning.bestamd = checkBoxBestamd.Checked;
            hamtning.hamtad = checkBoxHamtad.Checked;
            if (hamtning.bestamd)
            {
                if (!hamtning.hamtad && hamtningDateTimePicker.Value.CompareTo(DateTime.Today) < 0)
                {
                    MessageBox.Show("Denna maskin är inte hämtad men hämtningsdagen har redan varit.\nSäg till David att detta behöver hanteras.");
                }
                if (hamtningDateTimePicker.Value.DayOfWeek == DayOfWeek.Saturday || hamtningDateTimePicker.Value.DayOfWeek == DayOfWeek.Sunday)
                {                    
                    hamtningDateTimePicker.Value = nextWeekday(hamtningDateTimePicker.Value);                    
                }
                hamtning.Datum = hamtningDateTimePicker.Value;
            }
                
        }
        private void listBoxMaskiner_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = sender as ListBox;
            if(list.SelectedIndex > -1)
            {
                maskin = (Maskin)list.SelectedItem;
                ShowMachine();
            }
            else
            {
                clearForm();
            }

        }
        private void ShowMachine()
        {
            listBoxBrand.Text = maskin.brand;
            listBoxSort.Text = maskin.type;
            listBoxModell.Text = maskin.modell;
        }
        private void buttonPincode_Click(object sender, EventArgs e)
        {            
            LoginForm form = null;
            if(maskin != null)
                form = new LoginForm(maskin);
            else if(hamtning != null)
                form = new LoginForm(hamtning);
            if(form != null)
                form.Show();        
        }
        private void listBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSort.SelectedIndex > -1 && listBoxBrand.SelectedIndex > -1)
            {
                models = Modell.FindModels(listBoxBrand.Text, listBoxSort.Text);
                listBoxModell.DataSource = models;
                listBoxModell.SelectedIndex = -1;
            }
            else
            {
                models = null;
                listBoxModell.DataSource = models;
            }            
        }
        private void radioButtonNew_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonNew.Checked)
            {
                listBoxMaskiner.ClearSelected();                
            }
            else
            {
                if(listBoxMaskiner.SelectedIndex == -1 && listBoxMaskiner.Items.Count > 0)
                {
                    listBoxMaskiner.SetSelected(0, true);
                }
            }
        }
        private void clearForm()
        {
            
            listBoxBrand.ClearSelected();
            listBoxSort.ClearSelected();
            listBoxModell.ClearSelected();
            textBoxModell.Clear();
            textBoxPinkod.Clear();
            textBoxPostnummer.Clear();
            checkBoxBestamd.Checked = false;
            checkBoxHamtad.Checked = false;
            hamtningDateTimePicker.Value = DateTime.Now;
            richTextBoxKommentar.Clear();
        }
        private void textBoxPostnummer_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxPostnummer.Text;
            if(!String.IsNullOrEmpty(text))
            {
                listBoxSearch.Visible = true;
                listBoxSearch.DataSource = Vinterforvaring.getWithPostnr(text);
            }
            else
            {
                listBoxSearch.Visible = false;
            }
        }
        private void PostnummerSearch_PostnummerSelected(object sender, KeyEventArgs e)
        {
            if(listBoxSearch.SelectedIndex > -1 && e.KeyCode == Keys.Enter)
            {
                vinterforvaring = listBoxSearch.SelectedItem as Vinterforvaring;                
                checkBoxBestamd.Checked = true;
                hamtningDateTimePicker.Value = vinterforvaring.datum;
                listBoxSearch.DataSource = null;
                listBoxSearch.Visible = false;
            }            
        }
        private void buttonNewHamtning_Click(object sender, EventArgs e)
        {
            hamtning = new Hamtning();            
            hamtning.customer = this.customer;
            newHamtning = true;
            clearForm();
        }        
        private DateTime nextWeekday(DateTime date)
        {
            TimeSpan ts = new TimeSpan(date.Hour, date.Minute, date.Second);
            DateTime result = (date - ts);
            
            if(result.DayOfWeek == DayOfWeek.Saturday)
                result.AddDays(2);
            if (result.DayOfWeek == DayOfWeek.Sunday)
                result.AddDays(1);
            
            return result;
        }
        private void hamtningDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            hamtningDateTimePicker.Value = VinterforvaringForm.avoidWeekend(hamtningDateTimePicker.Value); 
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            Printing form = new Printing();
            form.Show();
            form.loadCustomer(customer);
            form.loadHamtning(hamtning);
            form.loadPrinting();
            
        }
        private void buttonHämtad_Click(object sender, EventArgs e)
        {
            if (hamtning.hamtad)
            {
                DialogResult result1 = MessageBox.Show("Denna hämtningen har redan markerats som 'hämtad'.\nTryck 'Ja' för att ändå lägga in ett nytt uppdrag utifrån hämtningen.\nTryck 'Nej', för att öppna fönster och kontrollera om uppdrag lagts till.\nTryck 'Avbryt' för att avbryta.",
                "Hämtad?",
                MessageBoxButtons.YesNoCancel);
                if (result1 == DialogResult.Yes)
                {
                    CustomerView form = new CustomerView(hamtning);
                    form.Show();
                    this.Close();
                }
                else if(result1 == DialogResult.No)
                {
                    DetailedView form = new DetailedView(customer);
                    form.Show();
                    this.Close();
                }                
            }
            else
            {
                CustomerView form = new CustomerView(hamtning);
                form.Show();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if(hamtning != null && !newHamtning)
            {
                DialogResult result1 = MessageBox.Show("Vill du radera " + hamtning.ToString() + "?",
                "Ta bort",
                MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    hamtning.Remove();
                    MessageBox.Show("Hämtningen togs bort.");
                    this.Close();
                    
                }
            }
        }        
    }
}
