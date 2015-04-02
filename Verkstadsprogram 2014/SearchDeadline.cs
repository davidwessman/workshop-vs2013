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
    public partial class SearchDeadline : UserControl
    {
        BindingList<Display> deadlineDisplay = new BindingList<Display>();
        public SearchDeadline()
        {
            InitializeComponent();
        }

        private void dateTimePickerDeadline_KeyDown(object sender, KeyEventArgs e)
        {
             
            if(e.KeyCode == Keys.Enter)
            {
                deadlineDisplay.Clear();
                showDeadline(dateTimePickerDeadline.Value);                
            }
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView1.Visible = false;
            }
        }
        private void showDeadline(DateTime deadline)
        {
            BindingList<Uppdrag> uppdragen = Databas.getDeadlineUppdrag(deadline);
            foreach (Uppdrag uppdrag in uppdragen)
            {
                Maskin maskin = Databas.getMachine(uppdrag.maskinID);
                Customer kund = Databas.searchCustomerID(maskin.customerID);
                deadlineDisplay.Add(new Display(kund, maskin, uppdrag));
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns["datum"].DataPropertyName = "datum";
            dataGridView1.Columns["namn"].DataPropertyName = "namn";
            dataGridView1.Columns["sort"].DataPropertyName = "sort";
            dataGridView1.Columns["work"].DataPropertyName = "work";
            dataGridView1.DataSource = deadlineDisplay;
            dataGridView1.Visible = true;
        }         

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView1.Visible = false;
            }            
        }        
    }
}
