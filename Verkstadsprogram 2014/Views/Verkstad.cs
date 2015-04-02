using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verkstadsprogram_2014.Views
{    
    public partial class Verkstad : Form
    {
        Customer customer;
        public Verkstad()
        {
            InitializeComponent();            
        }

        private void searchCustomer1_CustomerFound(object sender, EventArgs e)
        {
            this.customer = searchCustomer1.customer;
            if (customer != null)
            {
                CustomerView form = new CustomerView(customer,true);
                form.Show();
            }
        }

        private void buttonNyKund_Click(object sender, EventArgs e)
        {
            CustomerView form = new CustomerView();
            form.Show();
        }

        private void textBoxScanUppdrag_KeyDown(object sender, KeyEventArgs e)
        {
            if(!String.IsNullOrEmpty(textBoxScanUppdrag.Text) && e.KeyCode == Keys.Enter)
            {
                Uppdrag uppdrag = Uppdrag.Find(textBoxScanUppdrag.Text);
                if(uppdrag != null)
                {
                    ArbetaUppdrag form = new ArbetaUppdrag(uppdrag);
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Det finns inget uppdrag med detta uppdragsnummer.");
                }
            }
        }

        private void textBoxSeachHamtning_KeyDown(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxSeachHamtning.Text) && e.KeyCode == Keys.Enter)
            {
                int ID = 0;
                Int32.TryParse(textBoxSeachHamtning.Text,out ID);
                Hamtning hamtning = Hamtning.FindID(ID);
                if (hamtning != null && ID > 0)
                {
                    HamtningsForm form = new HamtningsForm(hamtning);
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Det finns inget hämtning med detta nummer.");
                }
            }
        }
    }
}
