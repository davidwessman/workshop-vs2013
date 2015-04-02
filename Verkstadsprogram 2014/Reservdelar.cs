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
    public partial class Reservdelar : UserControl
    {
        Del del;
        List<Del> reservdelsLista;
        List<Del> orderLista;
        public event EventHandler Change;
        
        public Reservdelar()
        {
            InitializeComponent();
        }
        private void textBoxReservdel_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxReservdel.Text))
            {
                List<Reservdel> search = Databas.searchReservdel(textBoxReservdel.Text);
                if (search != null && search.Count > 0)
                {
                    listBoxReservdelsSearch.Visible = true;
                    listBoxReservdelsSearch.DataSource = search;
                }
            }
            else
            {
                listBoxReservdelsSearch.Visible = false;
            }
        }
        private void textBoxReservdel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBoxReservdelsSearch.SelectedIndex > -1)
                {
                    if (numericUpDownReservdel.Value == 0)
                        numericUpDownReservdel.Select();

                    else
                    {
                        del = new Del((Reservdel)listBoxReservdelsSearch.SelectedItem, numericUpDownReservdel.Value);
                        checkedListBoxReservdelar.Items.Add(del);
                        textBoxReservdel.Text = del.reservdel.ToString();
                        listBoxReservdelsSearch.Visible = false;
                        textBoxReservdel.Clear();
                        numericUpDownReservdel.Value = 0;                        

                        if (this.Change != null)
                        {
                            this.Change(this, new EventArgs());
                        }
                    }


                }
            }
        }
        private void buttonAddReservdel_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxReservdel.Text))
            {
                ReservdelForm form = new ReservdelForm(new Reservdel(textBoxReservdel.Text));
                form.Show();
            }
        }
        private void listBoxReservdelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                if (checkedListBoxReservdelar.SelectedIndex > -1)
                {
                    del = (Del)checkedListBoxReservdelar.SelectedItem;
                    checkedListBoxReservdelar.Items.Remove(del);                    
                    textBoxReservdel.Text = del.reservdel.artikelNr;
                    numericUpDownReservdel.Value = del.antal;
                    numericUpDownReservdel.Select();
                    if (this.Change != null)
                    {
                        this.Change(this, new EventArgs());
                    }
                }
            }
        }

        public void Clear()
        {
            numericUpDownReservdel.Value = 0;
            textBoxReservdel.Clear();
            checkedListBoxReservdelar.Items.Clear();            
        }
        public void Ladda(List<Del> reservdelslista,List<Del> orderlista)
        {
            this.reservdelsLista = reservdelslista;
            this.orderLista = orderlista;
            foreach(Del a in reservdelslista)
            {
                checkedListBoxReservdelar.Items.Add(a);
                int index = checkedListBoxReservdelar.FindString(a.ToString());
                checkedListBoxReservdelar.SetItemChecked(index, true);
            }
            foreach (Del a in orderlista)
            {
                checkedListBoxReservdelar.Items.Add(a);
            }
        }
        public List<Del> reservdelslista
        {
            get
            {
                reservdelsLista = new List<Del>();
                foreach(Del a in checkedListBoxReservdelar.Items)
                {
                    if (checkedListBoxReservdelar.CheckedItems.Contains(a))
                        reservdelsLista.Add(a);
                }
                return reservdelsLista;
            }
        }
        public List<Del> orderlista
        {
            get
            {
                orderLista = new List<Del>();
                foreach (Del a in checkedListBoxReservdelar.Items)
                {
                    if (!checkedListBoxReservdelar.CheckedItems.Contains(a))
                        orderLista.Add(a);
                }
                return orderLista;
            }
        }
        public void AddDel(Reservdel reserv)
        {
            if(reserv != null)
            {
                textBoxReservdel.Text = reserv.artikelNr;
                numericUpDownReservdel.Select();
            }
        }
    }
}
