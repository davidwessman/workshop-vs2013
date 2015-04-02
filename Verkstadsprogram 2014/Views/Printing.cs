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

namespace Verkstadsprogram_2014.Views
{
    public partial class Printing : Form
    {
        Customer customer = null;
        Maskin maskin = null;
        Uppdrag uppdrag = null;
        Hamtning hamtning = null;
        Printer print;
        public Printing()
        {
            InitializeComponent();
           
        }
        public void loadCustomer(Customer customer)
        {
            this.customer = customer;
            textBox1.Text = customer.ToString();
        }
        public void loadMaskin(Maskin maskin)
        {
            this.maskin = maskin;
            textBox2.Text = maskin.ToString();            
        }
        public void loadUppdrag(Uppdrag uppdrag)
        {
            this.uppdrag = uppdrag;
            textBox3.Text = uppdrag.ToString();            
        }
        public void loadHamtning(Hamtning hamtning)
        {
            this.hamtning = hamtning;
            textBox4.Text = hamtning.ToString();            
        }
        public void loadPrinting()
        {
            print = new Printer(customer, maskin, uppdrag,hamtning);
            if (print.PrinterSettings.PaperSizes != null)
                foreach (PaperSize a in print.PrinterSettings.PaperSizes)
                    listBoxFormat.Items.Add(a.PaperName);
            if (print.PrinterSettings.PaperSources != null)
                foreach (PaperSource a in print.PrinterSettings.PaperSources)
                    listBoxSource.Items.Add(a.SourceName);
            PrintPreviewDialog printreview = new PrintPreviewDialog();
            PrintDialog pdlg = new PrintDialog();
            printPreviewControl1.Document = print;
            checkBoxes();
            
            
        }
        private void checkBoxes()
        {
            checkPrintKund.Enabled = (customer != null);
            checkPrintKund.Checked = checkPrintKund.Enabled;

            checkPrintMaskin.Enabled = (maskin != null);
            checkPrintMaskin.Checked = checkPrintMaskin.Enabled;

            checkPrintUppdrag.Enabled = (uppdrag != null);
            checkPrintUppdrag.Checked = checkPrintUppdrag.Enabled;

            checkPrintHamtning.Enabled = (hamtning != null);
            checkPrintHamtning.Checked = checkPrintHamtning.Enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBoxFormat.SelectedIndex > -1 && listBoxSource.SelectedIndex > -1 && print != null)
            {
                print.DefaultPageSettings.PaperSize = print.PrinterSettings.PaperSizes[listBoxFormat.SelectedIndex];
                print.DefaultPageSettings.PaperSource = print.PrinterSettings.PaperSources[listBoxSource.SelectedIndex];                
                print.Print();
            }
        }

        private void checkPrintKund_CheckedChanged(object sender, EventArgs e)
        {
            print.PrintKund(checkPrintKund.Checked);
            printPreviewControl1.Document = print;
        }        

        private void checkPrintMaskin_CheckedChanged(object sender, EventArgs e)
        {
            print.PrintMaskin(checkPrintMaskin.Checked);
            printPreviewControl1.Document = print;
        }

        private void checkPrintUppdrag_CheckedChanged(object sender, EventArgs e)
        {
            print.PrintUppdrag(checkPrintUppdrag.Checked);
            printPreviewControl1.Document = print;
        }

        private void checkPrintHamtning_CheckedChanged(object sender, EventArgs e)
        {
            print.PrintHamtning(checkPrintHamtning.Checked);
            printPreviewControl1.Document = print;
        }

        private void textBoxPinPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (LoginForm.Authenticate(textBoxPinPassword.Text))
                {
                    print.Pincode(true);
                    printPreviewControl1.Document = print;
                }
                else
                {
                    print.Pincode(false);
                    printPreviewControl1.Document = print;
                }
            }
            if (String.IsNullOrEmpty(textBoxPinPassword.Text))
            {
                print.Pincode(false);
                printPreviewControl1.Document = print;

            }
        }

        private void listBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFormat.SelectedIndex > -1)
            {
                print.DefaultPageSettings.PaperSize = print.PrinterSettings.PaperSizes[listBoxFormat.SelectedIndex];
                MessageBox.Show(print.DefaultPageSettings.PaperSize.Height.ToString() + "\n" + print.DefaultPageSettings.PaperSize.Width.ToString() + "\n" + print.DefaultPageSettings.PaperSize.Kind.ToString() + "\n" + print.DefaultPageSettings.PaperSize.RawKind.ToString() + "\n");
                printPreviewControl1.Document = print;
            }
        }

        private void listBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSource.SelectedIndex > -1)
            {
                print.DefaultPageSettings.PaperSource = print.PrinterSettings.PaperSources[listBoxSource.SelectedIndex];
            }
        }
    }
}
