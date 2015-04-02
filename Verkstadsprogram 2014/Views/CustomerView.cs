using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verkstadsprogram_2014.Controllers;
using Verkstadsprogram_2014.Views;

namespace Verkstadsprogram_2014
{
    public partial class CustomerView : Form  
    {
        public Customer customer;
        public Maskin maskin;
        public Uppdrag uppdrag;
        Hamtning hamtning;        
        bool newCustomer;
        bool newMachine = false;
        bool chooseMachine;
        public CustomerView()
        {
            InitializeComponent();
            newCustomer = true;            
            customer = new Customer();
            customerForm.addNew(customer);
            newMachine = true;
        }
        public CustomerView(Customer customer,bool valjMaskin)
        {
            InitializeComponent();
            newCustomer = false;
            this.customer = customer;
            customerForm.showCustomer(customer);
            maskinForm1.Visible = true;
            maskinForm1.showMachine(new Maskin());
            this.chooseMachine = valjMaskin;
            if(chooseMachine)
            {
                customer.Load();
                listBoxMaskiner.DataSource = customer.maskiner;
                tableMaskinChoice.Visible = true;
            }
        }
        public CustomerView(Hamtning hamtning)
        {
            InitializeComponent();
            newCustomer = false;
            this.hamtning = hamtning;
            this.customer = hamtning.customer;
            if (hamtning.maskin == null)            
                newMachine = true;            
            this.maskin = hamtning.getMaskin();            
            customerForm.showCustomer(this.customer);
            maskinForm1.Visible = true;
            maskinForm1.showMachine(this.maskin);
            uppdragForm1.Visible = true;
            uppdragForm1.newUppdrag(new Uppdrag());            
        }        
        private void CustomerView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(customer != null)
                customerForm.showCustomer(customer); //För att kolla om något ändrats
            if (maskin != null)
                maskinForm1.showMachine(maskin);
            if (uppdrag != null)
                uppdragForm1.showUppdrag(uppdrag);
            
        }
        private void maskinForm1_MachineUpdated(object sender, EventArgs e)
        {
            maskin = this.maskinForm1.maskin;
            if (maskin != null && customer != null)
            {                
                customer.Load();
                if(newMachine)
                {
                    customer.AddMachine(maskin);                    
                    if (chooseMachine)
                    {
                        customer.Load();
                        string maskinen = maskin.ToString();
                        listBoxMaskiner.DataSource = customer.maskiner;
                        int index = listBoxMaskiner.FindString(maskinen);
                        if (index > -1)
                            listBoxMaskiner.SetSelected(index, true);
                    }
                }
                else
                {
                    maskin.Update();
                }                
                uppdragForm1.Visible = true;
                uppdragForm1.newUppdrag(new Uppdrag());
            }                              
        }
        private void uppdragForm1_UppdragUpdated(object sender, EventArgs e)
        {
            uppdrag = this.uppdragForm1.uppdrag;
            if (uppdrag != null && maskin != null)
                maskin.AddUppdrag(uppdrag);
            if(hamtning != null)
            {
                hamtning.hamtad = true;
                hamtning.Update();
            }

        }
        private void customerForm_CustomerUpdated(object sender, EventArgs e)
        {
            customer = this.customerForm.customer;
            if (customer != null)
            {
                if (newCustomer)
                {
                    if (!customer.Add())                    
                    {
                     MessageBox.Show("Det finns redan en kund med kundnummer: " + customer.customerID + ", ändra kundnummret i inställningar och prova igen.");
                     customerForm.notSaved();
                    }
                    else
                    {
                        maskinForm1.Visible = true;
                        maskinForm1.showMachine(new Maskin());
                    }

                }
                else
                {
                    customer.Update();
                    maskinForm1.Visible = true;
                    maskinForm1.showMachine(new Maskin());
                    if(chooseMachine)
                    {
                        tableMaskinChoice.Visible = true;
                        customer.Load();
                        listBoxMaskiner.DataSource = customer.maskiner;
                    }
                }
                    
                
            }
        }
        private void buttonPrint_Click_1(object sender, EventArgs e)
        {
            if(customer != null && maskin != null && uppdrag != null)
            {
                Printing printer = new Printing();
                printer.loadCustomer(customer);
                printer.loadMaskin(maskin);
                printer.loadUppdrag(uppdrag);
                printer.loadPrinting();
                printer.Show();
            }
            
        }
        private void listBoxMaskiner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chooseMachine)
            {
                if(listBoxMaskiner.SelectedIndex > -1)
                {
                    radioButtonMachineChoose.Checked = true;
                    maskin = listBoxMaskiner.SelectedItem as Maskin;
                    newMachine = false;
                    maskinForm1.showMachine(maskin);
                    uppdragForm1.Visible = true;
                    uppdragForm1.newUppdrag(new Uppdrag());
                }
                else
                {
                    radioButtonMachineNew.Checked = true;
                    newMachine = true;
                    maskin = new Maskin();
                    maskinForm1.showMachine(maskin);
                    uppdragForm1.Visible = false;
                }
            }
        }
        private void radioButtonMachineChoose_CheckedChanged(object sender, EventArgs e)
        {
            if(chooseMachine)
            {
                if (radioButtonMachineChoose.Checked && listBoxMaskiner.Items.Count > 0)
                {
                    listBoxMaskiner.SetSelected(0, true);
                    newMachine = false;
                }
                else
                {
                    newMachine = true;
                    listBoxMaskiner.ClearSelected();
                }
            }
        }

        private void customerForm_CustomerRemoved(object sender, EventArgs e)
        {
            MessageBox.Show("Kunden togs bort.");
            this.Close();
        }        
    }
}
