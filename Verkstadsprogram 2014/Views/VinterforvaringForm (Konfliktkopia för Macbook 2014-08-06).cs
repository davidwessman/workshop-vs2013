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
using Verkstadsprogram_2014.Views;

namespace Verkstadsprogram_2014
{
    public partial class VinterforvaringForm : Form
    {
        BindingList<Hamtning> display = new BindingList<Hamtning>();
        BindingListView<Hamtning> view;
        DateTime date1;
        DateTime date2;
        DateTime date3;
        Vinterforvaring vinter1;
        Vinterforvaring vinter2;
        Vinterforvaring vinter3;
        Hamtning hamtning;
        public VinterforvaringForm()
        {
            InitializeComponent();
            textBoxSearch.GotFocus += textBoxSearch_GotFocus;
            textBoxSearch.LostFocus += textBoxSearch_LostFocus;           
            foreach(Hamtning a in Hamtning.Aktuella())
            {
                display.Add(a);
            }
            view = new BindingListView<Hamtning>(display);
            dataGridView1.DataSource = view;            
            dataGridView1.Columns["inlagd"].Visible = false;
            dataGridView1.Columns["hamtning"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;            
            dataGridView1.Columns["kommentar"].Visible = false;
            dataGridView1.Columns["inlamnat"].Visible = false;
            dataGridView1.Columns["maskin"].Visible = false;
            dateE.Value = DateTime.Today;
            ShowDays();

 
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxSearch.Text;
            if (!String.IsNullOrEmpty(text) && text != "Sök kunde efter namn.")
            {
                listBoxSearch.Visible = true;
                listBoxSearch.DataSource = Customer.SearchName((string)text);
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
                tbox.Text = "";
                tbox.ForeColor = Color.Black;
            }
        }
        private void textBoxSearch_LostFocus(object sender, EventArgs e)
        {
            var tbox = sender as TextBox;
            if (tbox.Text == "")
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
                Customer customer = (Customer)listBoxSearch.SelectedItem;                
                if(radioButtonHamtning.Checked)
                {
                    HamtningsForm form = new HamtningsForm(customer);
                    form.Show(this);
                }

            }
        }
        private void textBoxSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.LShiftKey && listBoxSearch.SelectedIndex + 1 < listBoxSearch.Items.Count)
            {

                listBoxSearch.SelectedIndex = listBoxSearch.SelectedIndex + 1;
            }
            if (e.KeyCode == Keys.RShiftKey && listBoxSearch.SelectedIndex - 1 > -1)
            {
                listBoxSearch.SelectedIndex = listBoxSearch.SelectedIndex - 1;
            }
        }
        private void dateE_ValueChanged(object sender, EventArgs e)
        {
            date2 = dateE.Value;
            date1 = date2.AddDays(-1);
            if (date1.DayOfWeek == DayOfWeek.Sunday)
                date1 = date1.AddDays(-1);
            date3 = date2.AddDays(1);
            if (date3.DayOfWeek == DayOfWeek.Sunday)
                date3 = date3.AddDays(1);

            ShowDays();
        }
        private void ShowDays()
        {
            if(date1 != null && date2 != null && date3 != null)
            {
                textBoxDate1.Text = veckodag(date1) +" "+ date1.ToString("dd'/'MM'/'yy");
                vinter1 = Vinterforvaring.
                textBoxDate2.Text = veckodag(date2) + " " + date2.ToString("dd'/'MM'/'yy");
                textBoxDate3.Text = veckodag(date3) + " " + date3.ToString("dd'/'MM'/'yy");
            }
        }
        private string veckodag(DateTime dag)
        {
            var culture = new System.Globalization.CultureInfo("sv-SE");
            return FirstLetterToUpper(culture.DateTimeFormat.GetDayName(dag.DayOfWeek));
        }
        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && view != null && view.Count > 0 && e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.CurrentCell.RowIndex > -1 && dataGridView1.CurrentCell.RowIndex < dataGridView1.RowCount)
                {
                    ObjectView<Hamtning> customerView = view[dataGridView1.CurrentCell.RowIndex];
                    hamtning = customerView.Object;
                    Vinterforvaring1.Items.Add(hamtning);
                    int index = Vinterforvaring1.FindString(hamtning.ToString());
                    Vinterforvaring1.SetSelected(index, true);
                }
            }
        }
    }
}
