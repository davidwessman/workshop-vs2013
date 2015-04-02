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
    public partial class ListBoxChooser : UserControl
    {
        List<Listor> listan = new List<Listor>();
        public event EventHandler Changed;
        public ListBoxChooser()
        {
            InitializeComponent();
        }
        public void Ladda()
        {            
            if(listan.Count > 0)
            {
                listBox.Items.Clear();
                listBoxChosen.Items.Clear();
                foreach(Listor a in listan)
                {
                    listBox.Items.Add(a.string1);
                }
            }
        }
        public void Ladda(List<Listor> listan)
        {
            this.listan = listan;            
            if (listan.Count > 0)
            {
                listBox.Items.Clear();
                listBoxChosen.Items.Clear();
                foreach (Listor a in listan)
                {
                    listBox.Items.Add(a.string1);
                }
            }
        }
        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && listBox.SelectedIndex > -1)
            {
                Add((Arbete)listBox.SelectedItem);   
            }
        }
        private void Add(Arbete a)
        {
            if(!listBoxChosen.Items.Contains(a))
            {
                listBoxChosen.SelectedIndex = -1;
                listBoxChosen.Items.Add(a);
                listBox.Items.Remove(a);
                if (listBox.Items.Count > 0)
                    listBox.SelectedIndex = 0;

                this.Changed(this, new EventArgs());
            }
        }
        private void Remove(String a)
        {
            if(listBoxChosen.Items.Contains(a))
            {
                listBox.SelectedIndex = -1;
                listBox.Items.Add(a);
                listBoxChosen.Items.Remove(a);
                if (listBoxChosen.Items.Count > 0)
                    listBoxChosen.SelectedIndex = 0;

                this.Changed(this, new EventArgs());
            }
        }
        private void listBoxChosen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && listBoxChosen.SelectedIndex > -1)
            {
                Remove((String)listBoxChosen.SelectedItem);
            }
        }
        public void Choose(Arbete choice)
        {
            Add(choice);
        }
        public List<Arbete> Chosen
        {
            get
            {
                List<Arbete> lista = new List<Arbete>();
                foreach (Arbete a in listBoxChosen.Items)
                {
                    lista.Add(a);
                }
                return lista;
            }
        }
    }
}
