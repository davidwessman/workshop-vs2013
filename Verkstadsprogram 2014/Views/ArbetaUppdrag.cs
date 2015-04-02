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
    public partial class ArbetaUppdrag : Form
    {
        Customer customer;        
        Maskin maskin;        
        Uppdrag uppdrag;        
        Modell model;

        public ArbetaUppdrag(Uppdrag uppdrag)
        {
            InitializeComponent();
            this.uppdrag = uppdrag;
            this.maskin = Maskin.Find(uppdrag.maskinID);
            this.customer = Customer.Find(maskin.customerID);
            if (customer != null && maskin != null && uppdrag != null)
            {
                this.customer.Load();
                customerShow.showCustomer(customer);
                maskinShow1.showMachine(maskin);
                uppdragShow1.showUppdrag(uppdrag);
                uppdragShow1.SuggestReservdelar(true);
                this.Text = "Visar: " + customer.ToString() + " " + maskin.ToString() + " " + uppdrag.ToString();
            }
        }
        private void refresh()
        {
            customer.Load();
            customerShow.showCustomer(customer);
            maskinShow1.showMachine(maskin);
            uppdragShow1.showUppdrag(uppdrag);
        }

        private void maskinShow_Model(object sender, EventArgs e)
        {
            this.model = maskinShow1.modelC;
            uppdragShow1.modelC = this.model;            
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

        private void uppdragShow1_UppdragUpdated(object sender, EventArgs e)
        {
            uppdrag = this.uppdragShow1.uppdrag;
            if ( uppdrag != null)
            {
                    uppdrag.Update();
            }     
        }

        private void customerShow_CustomerUpdated(object sender, EventArgs e)
        {
            customer = this.customerShow.customer;
            if (customer != null)
            {
                customer.Update();
            }          
        }

        private void maskinShow1_MachineUpdated(object sender, EventArgs e)
        {
            maskin = this.maskinShow1.maskin;
            if (maskin != null)
            {
                maskin.Update();
            }
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            customerShow.Visible = radioButtonKund.Checked;
            maskinShow1.Visible = radioButtonMaskin.Checked;
            uppdragShow1.Visible = radioButtonUppdrag.Checked;
            refresh();
        }

        
    }
}
