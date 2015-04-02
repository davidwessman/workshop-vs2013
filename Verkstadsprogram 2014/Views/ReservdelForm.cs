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
    public partial class ReservdelForm : Form
    {
        Reservdel reservdel;
        List<Reservdel> reservdelar;
        public ReservdelForm(Reservdel reservdel)
        {
            InitializeComponent();
            this.reservdel = reservdel;
            reservdelar = Reservdel.GetAll();
            showReservdel();           
        }
        private void showReservdel()
        {
            textBoxArtikelNr.Text = reservdel.artikelNr;
            if (String.IsNullOrWhiteSpace(reservdel.artikelNr))
                textBoxArtikelNr.Text = reservdel.name;
            textBoxBarcode.Text = reservdel.barcode;
            textBoxName.Text = reservdel.name;
            checkBox1.Checked = reservdel.orderDel;
            reservdelar = Reservdel.GetAll();            
            listBoxReservdel.DataSource = reservdelar;
            //textBoxInskrivet.Text = reservdel.readModel;
            //listBoxModels.
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            reservdel.artikelNr = textBoxArtikelNr.Text;
            reservdel.barcode = textBoxBarcode.Text;
            reservdel.name = textBoxName.Text;
            reservdel.orderDel = checkBox1.Checked;
            reservdel.Update();
            showReservdel();

        }

        private void listBoxReservdel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(listBoxReservdel.SelectedIndex > -1)
            //{
            //    reservdel = (Reservdel)listBoxReservdel.SelectedItem;
            //    showReservdel();
            //}
        }
    }
}
