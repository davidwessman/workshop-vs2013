using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verkstadsprogram_2014
{
    public partial class SearchCustomer : UserControl
    {
        public event EventHandler CustomerFound;
        public Customer customer;
        public SearchCustomer()
        {
            InitializeComponent();
            textBoxSearch.GotFocus += textBoxSearch_GotFocus;
            textBoxSearch.LostFocus += textBoxSearch_LostFocus;
        }
                
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxSearch.Text;
            if (!String.IsNullOrEmpty(text) && text != "Sök kund efter namn.")
            {
                listBoxSearch.Visible = true;
                listBoxSearch.DataSource = Customer.Search(text as string);
            }
            else
            {
                listBoxSearch.Visible = false;
                listBoxSearch.DataSource = null;
            }

        }
        private void textBoxSearch_GotFocus(object sender, EventArgs e)
        {
            var tbox = sender as TextBox;
            if (tbox.Text == "Sök kund efter namn.")
            {
                tbox.Text = String.Empty;
                tbox.ForeColor = Color.Black;
            }
        }
        private void textBoxSearch_LostFocus(object sender, EventArgs e)
        {
            var tbox = sender as TextBox;
            if (tbox.Text == String.Empty)
            {
                tbox.Text = "Sök kund efter namn.";
                tbox.ForeColor = Color.Gray;
                listBoxSearch.Visible = false;
            }
        }
        private void listBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listBoxSearch.SelectedIndex != -1)
            {
                customer = listBoxSearch.SelectedItem as Customer;
                if(this.CustomerFound != null)
                    CustomerFound(this, new EventArgs());
                listBoxSearch.Visible = false;
                textBoxSearch.ResetText();
            }
        }        
    }
}
