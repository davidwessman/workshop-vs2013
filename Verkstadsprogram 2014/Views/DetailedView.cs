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
    public partial class DetailedView : Form
    {
        Customer customer;
        List<Customer> searchCustomer = new List<Customer>();
        Maskin maskin;        
        Uppdrag uppdrag;        
        Modell model;

        bool newMachine = false;
        bool newUppdrag = false;        
        int aktuell = 0;
        
        
        public DetailedView(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            this.customer.Load();
            
            radioButtonMaskinShow.Checked = true;
            radioButtonUppdragShow.Checked = true; 
            
            customerShow.showCustomer(customer);
            listBoxMaskiner.DataSource = customer.maskiner;
            listBoxMaskiner.DisplayMember = "Display";                                   
            if(customer.maskiner.Count == 0)
            {
                newMachine = true;
                newUppdrag = true;
            }            
            
            this.Text = "Visar: " + customer.ToString();            
        }

        #region Customer
        private void radioButtonKund_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonKund.Checked)
            {
                customerShow.Visible = true;
                maskinShow1.Visible = false;
            }
        }
        #endregion

        #region Maskiner
        private void listBoxMaskiner_SelectedIndexChanged(object sender, EventArgs e)
        {                        
            if (listBoxMaskiner.SelectedIndex > -1)
            {                
                maskin = listBoxMaskiner.SelectedItem as Maskin;                
                if(maskin != null)
                {                    
                    maskin.Load(aktuell);
                    this.maskinShow1.showMachine(maskin);
                    listBoxUppdrag.DataSource = maskin.uppdrag;
                    listBoxUppdrag.DisplayMember = "Display";
                    radioButtonMaskin.Checked = true;
                    radioButtonMaskinShow.Checked = true;
                    newMachine = false;
                }                                
            }
            else
            {
                maskin = new Maskin();
                this.maskinShow1.showMachine(maskin);
                newMachine = true;
                radioButtonMaskinNew.Checked = true;
            }            
        }
        private void radioButtonMaskin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMaskin.Checked)
            {
                maskinShow1.Visible = true;
                customerShow.Visible = false;
                maskinNewShow.Visible = true;
            }
            else
            {
                maskinShow1.Visible = false;
                customerShow.Visible = true;
                maskinNewShow.Visible = false;
            }            
        }                
        #endregion
    
        private void refresh()
        {
            customer.Load();
            listBoxMaskiner.DataSource = customer.maskiner;
            listBoxUppdrag.SelectedIndex = -1;            
            if (listBoxMaskiner.SelectedIndex > -1)
            {
                maskin = listBoxMaskiner.SelectedItem as Maskin;
            }


        }
        
             
             
        private void refreshCustomer()
        {
            if (customer != null)
            {
                customer.Load();
                this.Text = "Visar: " + customer.ToString();
                listBoxMaskiner.DataSource = customer.maskiner;
            }
        }       
        private void refreshMachine()
        {
            if(maskin != null)
            {
                maskin.Load(0);
                listBoxUppdrag.DataSource = maskin.uppdrag;
                maskinShow1.showMachine(maskin);
            }
        }
            
        private void listBoxUppdrag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUppdrag.SelectedIndex > -1)
            {
                radioButtonUppdragShow.Checked = true;
                uppdrag = (Uppdrag)listBoxUppdrag.SelectedItem;                
                if(uppdrag != null)
                {
                    this.uppdragShow1.showUppdrag(uppdrag);                                                       
                }                                
            }            
        }
        private void radioButtonMaskinNew_CheckedChanged(object sender, EventArgs e)
        {
            newMachine = radioButtonMaskinNew.Checked;
            if (newMachine)
                listBoxMaskiner.SelectedIndex = -1;
            else if (listBoxMaskiner.Items.Count > 0 && listBoxMaskiner.SelectedIndex == -1)
                listBoxMaskiner.SetSelected(0, true);
            else if (listBoxMaskiner.Items.Count == 0 && radioButtonMaskinShow.Checked)
                radioButtonMaskinNew.Checked = true;
        }

        private void listBoxUppdrag_DataSourceChanged(object sender, EventArgs e)
        {
            if(listBoxUppdrag.Items.Count == 0)
            {
                radioButtonUppdragNew.Checked = true;
            }
        }

        private void radioButtonUppdrag_CheckedChanged(object sender, EventArgs e)
        {
            newUppdrag = radioButtonUppdragNew.Checked;
            if (newUppdrag)
            {
                listBoxUppdrag.SelectedIndex = -1;
                uppdrag = new Uppdrag();
                this.uppdragShow1.newUppdrag(uppdrag);
                newUppdrag = true;
            }
            else if (listBoxUppdrag.Items.Count > 0)
                listBoxUppdrag.SetSelected(0, true);
            else if (listBoxUppdrag.Items.Count == 0 && radioButtonUppdragShow.Checked)
                radioButtonUppdragNew.Checked = true;
        }

        private void maskinShow_Model(object sender, EventArgs e)
        {
            this.model = maskinShow1.modelC;
            uppdragShow1.modelC = this.model;            
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            if(customer != null)
            {
                Printer print = new Printer(customer,maskin,uppdrag,null);
                PrintPreviewDialog printreview = new PrintPreviewDialog();
                PrintDialog pdlg = new PrintDialog();
                printreview.Document = print;
                printreview.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Printing form = new Printing();
            form.Show();
            if (customer != null)
                form.loadCustomer(customer);
            if (maskin != null)
                form.loadMaskin(maskin);
            if (uppdrag != null)
                form.loadUppdrag(uppdrag);
            form.loadPrinting();
            
        }

        private void maskinShow1_MachineRemoved(object sender, EventArgs e)
        {
            MessageBox.Show("Maskinen togs bort");            
            refresh();
        }

        private void maskinShow1_MachineUpdated(object sender, EventArgs e)
        {
            maskin = this.maskinShow1.maskin;
            if (maskin != null)
            {
                if (newMachine)
                    customer.AddMachine(maskin);
                else
                    maskin.Update();
                string check = maskin.ToString();
                refreshCustomer();
                int index = listBoxMaskiner.FindString(check);
                if (index > -1 && listBoxMaskiner.Items.Count > 0)
                    listBoxMaskiner.SelectedIndex = index;
            }
        }

        private void customerShow_CustomerUpdated(object sender, EventArgs e)
        {
            customer = this.customerShow.customer;
            if (customer != null)
            {
                customer.Update();
                refreshCustomer();
            }
        }

        private void customerShow_CustomerRemoved(object sender, EventArgs e)
        {
            MessageBox.Show("Kunden togs bort");
            this.Close();
        }

        private void searchCustomer1_CustomerFound(object sender, EventArgs e)
        {
            customer = searchCustomer1.customer;
            listBoxMaskiner.DataSource = null;
            listBoxUppdrag.DataSource = null;
            listBoxMaskiner.DataSource = customer.maskiner;
            this.customerShow.showCustomer(customer);
            this.Text = "Visar: " + customer.ToString();
        }

        private void uppdragShow1_UppdragUpdated(object sender, EventArgs e)
        {
            uppdrag = this.uppdragShow1.uppdrag;
            if (maskin != null && uppdrag != null)
            {
                if (newUppdrag)
                {
                    maskin.AddUppdrag(uppdrag);
                }
                else
                {
                    uppdrag.Update();
                }
                refreshCustomer();
            }          
        }

        private void uppdragShow1_UppdragRemoved(object sender, EventArgs e)
        {
            MessageBox.Show("Uppdraget togs bort");
            radioButtonUppdragNew.Checked = true;
            refreshMachine();
        }

        
    }
}
