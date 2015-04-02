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

namespace Verkstadsprogram_2014
{
    public partial class CustomerForm : UserControl
    {
        public Customer customer;        
        bool customerChange;
        Postnummer postnummer;
        bool loaded = false;
        bool newCustomer = false;
        public event EventHandler CustomerUpdated;
        public event EventHandler CustomerRemoved;

        public CustomerForm()
        {
            InitializeComponent();
            loaded = false;
        }
        public void clear()
        {
            tbName.Text = String.Empty;
            tbLastName.Text = String.Empty;            
            tbEpost.Text = String.Empty;
            tbCustomerID.Text = String.Empty;
            tbInlagd.Text = String.Empty;
            PostnrLeverans.Text = String.Empty;
            PostortLeverans.Text = String.Empty;
            tbTelefon.Text = String.Empty;
            textBoxForetagsNamn.Text = String.Empty;
            textBoxOrg.Text = String.Empty;
            radioButtonForetag.Checked = false;
            radioButtonPrivate.Checked = true;
            postnummer = null;
        }
        public void showCustomer(Customer customer)
        {
            checkCustomerChanged();
            if (customer != null)
            {
                newCustomer = false;
                loaded = false;
                this.customer = customer;
                customer.Load();                                
                tbName.Text = customer.firstNamn;
                tbLastName.Text = customer.lastNamn;
                AdressLeverans.Text = customer.LeveransAdress1;
                textBoxLeveransAdress2.Text = customer.LeveransAdress2;
                AdressFaktura.Text = customer.FakturaAdress1;
                textBoxFakturaAdress2.Text = customer.FakturaAdress2;
                PostnrLeverans.Text = customer.LeveransPostnr;
                PostnummerFaktura.Text = customer.FakturaPostnr;
                PostortLeverans.Text = customer.LeveransPostort;
                PostortFaktura.Text = customer.FakturaPostort;
                tbEpost.Text = customer.epost;
                tbCustomerID.Text = customer.customerID;
                tbInlagd.Text = customer.inlagd.ToString("dd'/'MM'/'yyyy");
                tbTelefon.Text = customer.phone;
                textBoxForetagsNamn.Text = customer.foretagsnamn;
                textBoxOrg.Text = customer.orgNr;
                radioButtonForetag.Checked = customer.foretag;
                radioButtonPrivate.Checked = !customer.foretag;
                Customer_Change(false);
                visibleNew(true);
                loaded = true;
                buttonRemove.Visible = true;
            }
        }
        public void notSaved()
        {
            Customer_Change(true);
        }       
        public void addNew(Customer customer)
        {
            checkCustomerChanged();
            newCustomer = true;
            if (customer == null)
                this.customer = new Customer();
            else
                this.customer = customer;
            visibleNew(false);
            loaded = true;
            buttonRemove.Visible = false;
        }
        private void visibleNew(bool check)
        {
            labelKundnr.Visible = check;
            tbCustomerID.Visible = check;
            labelInlagd.Visible = check;
            tbInlagd.Visible = check;
        }
        private void saveCustomer()
        {
            if (newCustomer)
            {
                Adress leveransadress = new Adress(AdressLeverans.Text,textBoxLeveransAdress2.Text, PostnrLeverans.Text, PostortLeverans.Text);
                Adress fakturaadress = new Adress(AdressFaktura.Text,textBoxFakturaAdress2.Text,PostnummerFaktura.Text, PostortFaktura.Text);
                customer = new Customer(tbName.Text, tbLastName.Text, tbTelefon.Text,tbEpost.Text, leveransadress.Save(),fakturaadress.Save(),radioButtonForetag.Checked,textBoxOrg.Text,textBoxForetagsNamn.Text);
            }
            else
            {                
                customer.lastNamn = tbLastName.Text;
                customer.phone = tbTelefon.Text;
                customer.leveransadress = new Adress(AdressLeverans.Text,textBoxLeveransAdress2.Text, PostnrLeverans.Text, PostortLeverans.Text);
                customer.fakturaadress = new Adress(AdressFaktura.Text,textBoxFakturaAdress2.Text, PostnummerFaktura.Text, PostortFaktura.Text);
                customer.firstNamn = tbName.Text;
                customer.epost = tbEpost.Text;
                postnummer = Postnummer.Find(customer.LeveransPostnr);
                if (postnummer == null)
                {
                    postnummer = new Postnummer(customer.LeveransPostnr, customer.LeveransPostort);
                    postnummer.Add();
                }
                postnummer = Postnummer.Find(customer.FakturaPostnr);
                if (postnummer == null)
                {
                    postnummer = new Postnummer(customer.FakturaPostnr, customer.FakturaPostort);
                    postnummer.Add();
                }

                customer.foretag = radioButtonForetag.Checked;
                customer.orgNr = textBoxOrg.Text;
                customer.foretagsnamn = textBoxForetagsNamn.Text;
            }
            listBoxPostnummer.Visible = false;
        }
        private void buttonUpdateKund_Click(object sender, EventArgs e)
        {
            saveCustomer();
            Customer_Change(false);
            if(this.CustomerUpdated != null)
                this.CustomerUpdated(customer, new EventArgs());
        }        
        private void Customer_Changed(object sender, EventArgs e)
        {
            //Binda ändringar i kundformulär till.
            Customer_Change(true);
        }
        private void Customer_Change(bool check)
        {
            //Metod att kalla på vid ändring av kundformulär. Behövs för de fält som redan har en metod bunden till t.ex. TextChanged
            Adress leveransadress = new Adress(AdressLeverans.Text, textBoxLeveransAdress2.Text, PostnrLeverans.Text, PostortLeverans.Text);
            Adress fakturaadress = new Adress(AdressFaktura.Text,textBoxFakturaAdress2.Text, PostnummerFaktura.Text, PostortFaktura.Text);
            Customer checking  = new Customer(tbName.Text, tbLastName.Text, tbTelefon.Text, tbEpost.Text, leveransadress.Save(), fakturaadress.Save(), radioButtonForetag.Checked, textBoxOrg.Text, textBoxForetagsNamn.Text);
            if(check)
            {
                bool checkat = !customer.Equals(checking);
                customerChange = checkat;
                radioButtonKundChanged.Checked = checkat;
                buttonUpdateKund.Visible = true;
            }
            else
            {
                customerChange = check;
                radioButtonKundChanged.Checked = check;
                buttonUpdateKund.Visible = false;
            }            
            
        }
        private void checkCustomerChanged()
        {
            if (customerChange && customer != null && loaded)
            {
                DialogResult result1 = MessageBox.Show(customer.ToString() + " ändrades, vill du spara?",
                "Spara",
                MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    saveCustomer();
                    customer.Update();
                    MessageBox.Show("Sparades");
                }
            }
        }        
        private void listBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(loaded)
            {                            
                if (e.KeyCode == Keys.Enter && listBoxPostnummer.SelectedIndex != -1)
                {
                    postnummer = listBoxPostnummer.SelectedItem as Postnummer;
                    if(radioButtonLeverans.Checked)
                    {
                        PostnrLeverans.Text = postnummer.postnummer;
                        PostortLeverans.Text = postnummer.ort;
                    }                    
                    else if (radioButtonFaktura.Checked)
                    {
                        PostnummerFaktura.Text = postnummer.postnummer;
                        PostortFaktura.Text = postnummer.ort;
                    }
                    
                    listBoxPostnummer.DataSource = null;
                    listBoxPostnummer.Visible = false;
                }
                if (e.KeyCode == Keys.Escape)
                {
                    listBoxPostnummer.DataSource = null;
                    listBoxPostnummer.Visible = false;
                }                
            }
        }
        private void RadioButtonPrivateForetag_CheckedChanged(object sender, EventArgs e)
        {
            bool privateMode = !radioButtonPrivate.Checked;
            labelOrgnr.Visible = privateMode;
            textBoxOrg.Visible = privateMode;
            labelForetag.Visible = privateMode;
            textBoxForetagsNamn.Visible = privateMode;
            Customer_Change(true);
        }

        private void radioButtonFaktura_CheckedChanged(object sender, EventArgs e)
        {
            AdressLeverans.Visible = radioButtonLeverans.Checked;
            AdressFaktura.Visible = !AdressLeverans.Visible;
            PostnrLeverans.Visible = radioButtonLeverans.Checked;
            PostnummerFaktura.Visible = !PostnrLeverans.Visible;
            PostortLeverans.Visible = radioButtonLeverans.Checked;
            PostortFaktura.Visible = !PostortLeverans.Visible;
            textBoxLeveransAdress2.Visible = radioButtonLeverans.Checked;
            textBoxFakturaAdress2.Visible = !textBoxLeveransAdress2.Visible;
            
        }

        private void PostortFaktura_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (loaded)
            {
                string text = textBox.Text;
                if (!String.IsNullOrEmpty(text))
                {
                    listBoxPostnummer.DataSource = Postnummer.search(text as string);
                    listBoxPostnummer.Visible = listBoxPostnummer.Items.Count > 0;
                }
                else
                {
                    listBoxPostnummer.Visible = false;
                    listBoxPostnummer.DataSource = null;
                }
                Customer_Change(true);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if(!newCustomer && customer != null)
            {
                DialogResult result1 = MessageBox.Show("Vill du radera " + customer.ToString() + ", samt alla maskiner, uppdrag och hämtningar associerade med kunden?",
                "Ta bort",
                MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    customer.Remove();
                    if (CustomerRemoved != null)
                        CustomerRemoved(this, new EventArgs());
                }
            }
        }
    }
}
