using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verkstadsprogram_2014.Controllers
{
    public partial class Printer : PrintDocument
    {
        Customer customer;
        Maskin maskin;
        Uppdrag uppdrag;
        Hamtning hamtning;
        bool kunden;
        bool maskinen;
        bool uppdraget;
        bool hamtningen;
        bool pin;
        int rowHeight = 10;
        int column1 = 10;
        int column2 = 20;
        public Printer() : base()
        {
            InitializeComponent();
        }
        public Printer(Customer customer,Maskin maskin,Uppdrag uppdrag,Hamtning hamtning)
            : base()
        {
            InitializeComponent();
            this.customer = customer;
            this.maskin = maskin;
            this.uppdrag = uppdrag;
            this.hamtning = hamtning;
        }
        public void PrintKund(bool check)
        {
            kunden = check;
        }
        public void PrintMaskin(bool check)
        {
            maskinen = check;
        }
        public void PrintUppdrag(bool check)
        {
            uppdraget = check;
        }
        public void PrintHamtning(bool check)
        {
            hamtningen = check;
        }
        public void Pincode(bool check)
        {
            pin = check;
        }

        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);
            //Lägg till inställningar
        }
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            //Lokala variabler
            int printHeight;
            int printWidth;
            int leftMargin;
            int rightMargin;
            int topMargin;
            Int32 lines = 0;
            Int32 chars;
            Point currPos;
            Font printfont;
            Font headline;
            Font barcode;
            //Utskiftsyta och marginaler
            {
                leftMargin = e.MarginBounds.Left;
                rightMargin = e.MarginBounds.Right;
                topMargin = e.MarginBounds.Top;
                printHeight = e.MarginBounds.Height;
                printWidth = e.MarginBounds.Width;                
            }
            // Swapp höjd och bredd om man printar i landscape
            if(base.DefaultPageSettings.Landscape)
            {
                int tmp = printHeight;
                printHeight = printWidth;
                printWidth = tmp;
            }
            // Rektangulär printyta
            RectangleF printArea = new RectangleF(leftMargin, rightMargin, printWidth, printHeight);

            //StringFormat används för textlayout i dokumentet
            StringFormat format = new StringFormat(StringFormatFlags.LineLimit);

            // Skriv sidan
            Image image = Verkstadsprogram_2014.Properties.Resources.Logo;
            Rectangle logo = new Rectangle((printWidth)/2, 40, 150, 150);   
            // Logo            


            if (printWidth > 600)
            {
                printfont = new Font("Arial", 28.0f);
                headline = new Font("Arial", 32.0f);
                barcode = new Font("Free 3 of 9 Extended", 30, FontStyle.Regular, GraphicsUnit.Point);
                if (!barcode.Name.Equals("Free 3 of 9 Extended"))
                    barcode = new Font("Free 3 of 9 Utökad", 30, FontStyle.Regular, GraphicsUnit.Point);
                rowHeight = 50;
            }
            else
            {
                printfont = new Font("Arial", 18.0f);
                headline = new Font("Arial", 22.0f);
                barcode = new Font("Free 3 of 9 Extended", 22, FontStyle.Regular, GraphicsUnit.Point);
                if (!barcode.Name.Equals("Free 3 of 9 Extended"))
                    barcode = new Font("Free 3 of 9 Utökad", 22, FontStyle.Regular, GraphicsUnit.Point);
                rowHeight = 35;
            }
            
            column1 = (int)(printWidth*0.10);
            column2 = (int)(printWidth*0.75);
            currPos = new Point(column1, topMargin);
            if(!hamtningen)
            {
                e.Graphics.DrawImage(image, logo);
                currPos = new Point(column1, 180);
            }

            #region Kund
            if (customer != null && kunden)
            {                
                if(customer.foretag)
                {
                    e.Graphics.DrawString(customer.foretagsnamn + " " + customer.orgNr, printfont, Brushes.Black, currPos);
                    currPos = newRow(currPos);
                }
                e.Graphics.DrawString(customer.firstNamn + " " + customer.lastNamn, printfont, Brushes.Black, currPos);
                currPos = nextColumn(currPos);
                e.Graphics.DrawString("*"+customer.customerID+"*", barcode, Brushes.Black, currPos);
                currPos = newRow(currPos);
                if(hamtning != null && hamtningen)
                {
                    e.Graphics.DrawString(customer.LeveransAdress1 + " " + customer.LeveransAdress2, printfont, Brushes.Black, currPos);
                    currPos = newRow(currPos);
                    e.Graphics.DrawString(customer.LeveransPostnr + " " + customer.LeveransPostort, printfont, Brushes.Black, currPos);
                    currPos = newRow(currPos);
                }
            }
            #endregion
            #region Maskin
            if (maskin != null && maskinen)
            {
                e.Graphics.DrawString(maskin.maskinID, printfont, Brushes.Black, currPos);
                currPos = nextColumn(currPos);
                e.Graphics.DrawString("*"+maskin.maskinID+"*" ,barcode, Brushes.Black, currPos);
                currPos = newRow(currPos);
            }
            #endregion
            #region Hämtning
            if (hamtning != null && hamtningen)
            {
                e.Graphics.DrawString("Hämtning", printfont, Brushes.Black, currPos);
                currPos = nextColumn(currPos);
                e.Graphics.DrawString("*" + hamtning.ID + "*", barcode, Brushes.Black, currPos);
                MessageBox.Show(hamtning.ID.ToString());
                currPos = newRow(currPos);
                e.Graphics.DrawString(hamtning.type + " " + hamtning.brand, printfont, Brushes.Black, currPos);
                currPos = newRow(currPos);
                if (pin && !String.IsNullOrWhiteSpace(hamtning.getPinCode(true)))
                {
                    e.Graphics.DrawString("Pinkod:", printfont, Brushes.Black, currPos);
                    currPos = nextColumn(currPos);
                    e.Graphics.DrawString(hamtning.getPinCode(true), printfont, Brushes.Black, currPos);
                    currPos = newRow(currPos);
                }
                e.Graphics.MeasureString(hamtning.kommentar, printfont, new Size(printWidth, printHeight), format, out chars, out lines);
                e.Graphics.DrawString(hamtning.kommentar, printfont, Brushes.Black, currPos);
                for (int i = 0; i < lines; i++)
                    currPos = newRow(currPos);
                lines = 0;
            }
            #endregion
            #region Uppdrag
            if (uppdrag != null && uppdraget)
            {
                e.Graphics.DrawString(uppdrag.uppdragID, printfont, Brushes.Black, currPos);
                currPos = nextColumn(currPos);
                e.Graphics.DrawString("*" + uppdrag.uppdragID + "*", barcode, Brushes.Black, currPos);
                currPos = newRow(currPos);
                e.Graphics.DrawString("Inlämnad", printfont, Brushes.Black, currPos);
                currPos = nextColumn(currPos);                
                e.Graphics.DrawString(uppdrag.Inlamnad, printfont, Brushes.Black, currPos);
                currPos = newRow(currPos);
                e.Graphics.DrawString("Färdig till", printfont, Brushes.Black, currPos);                
                currPos = nextColumn(currPos);
                e.Graphics.DrawString(uppdrag.Deadline, printfont, Brushes.Black, currPos);
                currPos = newRow(currPos);
                if(uppdrag.arbete.Count > 0)
                {
                    e.Graphics.DrawString("Arbete", headline, Brushes.Black, currPos);
                    currPos = newRow(currPos);
                    foreach (Arbete a in uppdrag.arbete)
                    {
                        currPos.X += 15;
                        Point rectanglen = currPos;
                        rectanglen.Y += 5;
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle(rectanglen, new Size(25, 25)));
                        currPos.X += 45;
                        e.Graphics.DrawString(a.name, printfont, Brushes.Black, currPos);
                        if (a.name == "Reparation" && !String.IsNullOrEmpty(uppdrag.reparationSpec))
                        {
                            currPos = nextColumn(currPos);
                            e.Graphics.MeasureString("Reparationsspec\n"+uppdrag.reparationSpec, printfont, new Size(printWidth, printHeight), format, out chars, out lines);
                            e.Graphics.DrawString("Reparatonsspec\n"+uppdrag.reparationSpec, printfont, Brushes.Black, currPos);                            
                        }
                        currPos = newRow(currPos);
                    }
                    if (lines > 0 && lines > uppdrag.arbete.Count)
                    {
                        for (int i = 0; i < lines - uppdrag.arbete.Count; i++)
                            currPos = newRow(currPos);
                        lines = 0;
                    }
                    

                }
                
                if(!String.IsNullOrEmpty(uppdrag.ovrigt))
                {
                    e.Graphics.DrawString("Övrigt", headline, Brushes.Black, currPos);
                    currPos.Y += 10;
                    currPos = nextColumn(currPos);
                    e.Graphics.MeasureString(uppdrag.ovrigt, printfont, new Size(printWidth, printHeight), format, out chars, out lines);
                    e.Graphics.DrawString(uppdrag.ovrigt, printfont, Brushes.Black, currPos);
                    for(int i = 0;i<lines;i++)
                        currPos = newRow(currPos);
                    lines = 0;
                }
            }
            #endregion
            #region Kundlapp
            
            if(hamtningen)
            {
                currPos = newRow(currPos);
                logo = new Rectangle((printWidth) / 2, currPos.Y, 150, 150); 
                e.Graphics.DrawImage(image, logo);
                currPos = newRow(currPos);
                currPos.Y += 150;
                string print = "Vi har hämtat er:\n" + hamtning.brand + " " + hamtning.type + "\nidag, " + hamtning.hamtning.ToString("dd'/'MM'/'yy");
                e.Graphics.MeasureString(print, printfont, new Size(printWidth, printHeight), format, out chars, out lines);
                e.Graphics.DrawString(print, printfont, Brushes.Black, currPos);
                for (int i = 0; i < lines+1; i++)
                    currPos = newRow(currPos);
                lines = 0;
                print = "042-12 68 70\nwww.grasklipparservice.se\nLillefredsvägen 12-6\n26375 Nyhamnsläge";
                e.Graphics.MeasureString(print, printfont, new Size(printWidth, printHeight), format, out chars, out lines);
                e.Graphics.DrawString(print, printfont, Brushes.Black, currPos);
                for (int i = 0; i < lines; i++)
                    currPos = newRow(currPos);
                lines = 0;
            }            
            #endregion



        }
        private Point newRow(Point current)
        {
            current.Y += rowHeight;
            current.X = column1;
            return current;
        }
        private Point nextColumn(Point current)
        {
            current.X = column2;
            return current;
        }
       
    }
}
