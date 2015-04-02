using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verkstadsprogram_2014.Models;

namespace Verkstadsprogram_2014.Views
{
    public partial class ChooseHamtning : Form
    {
        Postnummer postnummer;
        DateTime date;
        List<Hamtning> hamtningar;
        public ChooseHamtning(Postnummer postnummer,DateTime date)
        {
            InitializeComponent();
            this.postnummer = postnummer;
            this.date = date;
            this.hamtningar = Hamtning.forPostnummer(postnummer.postnummer);
            checkedListBox1.DataSource = hamtningar;
        }
    }
}
