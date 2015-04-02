using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Verkstadsprogram_2014
{
    public partial class AllCustomers : Form
    {

        BindingList<Customer> kunder = new BindingList<Customer>();
        BindingListView<Customer> view;        
        public Customer customer;
        bool change = false;
        public AllCustomers()
        {
           InitializeComponent();
           LoadGrid();
        }   
        private void LoadGrid()
        {
            kunder = Customer.getCustomers(false);
            view = new BindingListView<Customer>(kunder);
            dataGridView1.DataSource = view;
            dataGridView1.Columns["customerID"].DisplayIndex = 0;
            dataGridView1.Columns["epost"].DisplayIndex = 4;
            dataGridView1.Columns["aktuell"].Visible = false;
            dataGridView1.Columns["inlagd"].Visible = false;
            dataGridView1.Columns["foretag"].Visible = false;
            dataGridView1.Columns["LeveransAdress1"].Visible = false;
            dataGridView1.Columns["LeveransAdress2"].Visible = false;
            dataGridView1.Columns["LeveransPostnr"].Visible = false;
            dataGridView1.Columns["LeveransPostort"].Visible = false;
            dataGridView1.Columns["FakturaAdress1"].Visible = false;
            dataGridView1.Columns["FakturaAdress2"].Visible = false;
            dataGridView1.Columns["FakturaPostnr"].Visible = false;
            dataGridView1.Columns["FakturaPostort"].Visible = false;
            dataGridView1.Columns["PostnummerLeverans"].Visible = false;
            dataGridView1.Columns["PostnummerFaktura"].Visible = false;
            dataGridView1.Columns["Display"].Visible = false;
            dataGridView1.Columns["fakturaadress"].Visible = false;
            dataGridView1.Columns["leveransadress"].Visible = false;
            change = false;
        }   
        private void btNyArbete_Click(object sender, EventArgs e)
        {            
            if (customer != null)
            {
                CustomerView form = new CustomerView(customer,true);
                form.Show();
                change = true;
            }            
        }             
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null && view != null && view.Count > 0)
            {
                if (dataGridView1.CurrentCell.RowIndex > -1 && dataGridView1.CurrentCell.RowIndex < dataGridView1.RowCount)
                {
                    ObjectView<Customer> customerView = view[dataGridView1.CurrentCell.RowIndex];
                    customer = customerView.Object;
                    customerForm.showCustomer(customer);                    
                }
            }
        }        
        private void bNewCustomer_Click(object sender, EventArgs e)
        {
            CustomerView form = new CustomerView();
            form.Show();
            change = true;  
        }        
        private void buttonDetail_Click(object sender, EventArgs e)
        {
            DetailedView form = new DetailedView(customer);
            form.Show();
            change = true;
        }      
        private void searchCustomer1_CustomerFound(object sender, EventArgs e)
        {
            customer = this.searchCustomer1.customer;
            int rowIndex = -1;
            ObjectView<Customer> customerView = null;
            if (dataGridView1.CurrentCell != null && view != null && view.Count > 0)
            {
                if (dataGridView1.CurrentCell.RowIndex > -1 && dataGridView1.CurrentCell.RowIndex < dataGridView1.RowCount)
                {
                    customerView = view[dataGridView1.CurrentCell.RowIndex];

                }
            }
            if (dataGridView1.Rows.Count > 0 && !customerView.Object.Equals(customer))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[3].Value.ToString().Equals(customer.customerID))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                if (rowIndex > -1 && rowIndex < dataGridView1.RowCount)
                    dataGridView1.CurrentCell = dataGridView1[3, rowIndex];
            }
        }
        private void customerForm_CustomerUpdated(object sender, EventArgs e)
        {
            customer = this.customerForm.customer;
            if (customer != null)
            {
                customer.Update();
            }
        }

        private void customerForm_CustomerRemoved(object sender, EventArgs e)
        {
            MessageBox.Show("Kunden togs bort.");
            LoadGrid();
            
        }

        private void AllCustomers_Activated(object sender, EventArgs e)
        {
            if(change)
            {
                LoadGrid();
            }
        }
    }
    
}
