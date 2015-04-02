using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Verkstadsprogram_2014
{
    public class Maskin
    {
        #region Attribut
        [System.ComponentModel.DisplayName("Maskinnr.")]
        public string maskinID { get; set; }
        [System.ComponentModel.DisplayName("Inlagd")]
        public DateTime inlagd { get; set; }
        [System.ComponentModel.DisplayName("Ändrad")]
        public DateTime changed { get; set; }
        [System.ComponentModel.DisplayName("Märke")]
        public string brand { get; set; }
        [System.ComponentModel.DisplayName("Sort")]
        public string type { get; set; }
        [System.ComponentModel.DisplayName("Serienr.")]
        public string serialNbr { get; set; }
        [System.ComponentModel.DisplayName("Kundnr.")]
        public string customerID { get; set; }
        [System.ComponentModel.DisplayName("Senaste service")]
        public DateTime latestService { get; set; }
        [System.ComponentModel.DisplayName("Vinterförvaring")]
        public Boolean vinterforvaring { get; set; }
        [System.ComponentModel.DisplayName("Modell")]
        public string modell { get; set; }
        [System.ComponentModel.DisplayName("Produktnr.")]
        public string productNbr { get; set; }
        [System.ComponentModel.DisplayName("Tillverkningsår")]
        public string productionYear { get; set; }
        [System.ComponentModel.DisplayName("Antal uppdrag")]
        public int antalUppdrag { get; set; }
        [System.ComponentModel.DisplayName("Uppdrag")]
        public List<Uppdrag> uppdrag { get; set; }
        public string motorNr { get; set; }
        public string pincode { get; set; }
        public string aggregatNbr { get; set; }
        #endregion
        #region Konstruktorer
        public Maskin(string maskinID,DateTime inlagd,DateTime changed, string brand,string type,string serialNbr,string customerID,DateTime latestService,Boolean vinterforvaring,string modell,string productNbr, string productionYear,string motorNr, string pincode,string aggregatNbr)
        {
            this.maskinID = maskinID;
            this.inlagd = inlagd;
            this.changed = changed;
            this.brand = brand;
            this.type = type;
            this.serialNbr = serialNbr;
            this.customerID = customerID;
            this.latestService = latestService;
            this.vinterforvaring = vinterforvaring;
            this.modell = modell;
            this.productionYear = productionYear;
            this.productNbr = productNbr;
            this.uppdrag = Uppdrag();
            this.motorNr = motorNr;
            this.pincode = pincode;
            this.aggregatNbr = aggregatNbr;
        }
        public Maskin(string brand, string type, string serialNbr, string modell,string productNbr, string productionYear,string motorNr,string pinCode, Customer kund,string aggregatNbr)
        {
            this.maskinID = kund.customerID + "-" + kund.maskiner.Count.ToString().PadLeft(2, '0');            
            this.brand = brand;
            this.type = type;
            this.serialNbr = serialNbr;
            this.modell = modell;
            this.productNbr = productNbr;
            this.productionYear = productionYear;
            this.customerID = kund.customerID;
            this.inlagd = DateTime.Now;
            this.changed = DateTime.Now;
            this.latestService = Variables.notChosen;
            this.vinterforvaring = false;
            this.antalUppdrag = 1;
            this.uppdrag = new List<Uppdrag>();
            this.pincode = pincode;
            this.motorNr = motorNr;
            this.aggregatNbr = aggregatNbr;
        }
        public Maskin()
        {
            this.maskinID = String.Empty;
            this.brand = String.Empty;
            this.type = String.Empty;
            this.serialNbr = String.Empty;
            this.modell = String.Empty;
            this.productionYear = String.Empty;
            this.customerID = String.Empty;
            this.inlagd = DateTime.Now;
            this.changed = DateTime.Now;
            this.latestService = Variables.notChosen;
            this.vinterforvaring = false;
            this.uppdrag = new List<Uppdrag>();
            this.pincode = String.Empty;
            this.motorNr = String.Empty;
            this.aggregatNbr = String.Empty;
        }
        #endregion
        #region Metoder
        public void Add()
        {            
            Databas.addMachine(this);
        }
        public void Update()
        {
            Databas.updateMachine(this);
        }
        public void Load(int val)
        {
            this.uppdrag = Databas.getMachinesUppdrag(this.maskinID, val);
        }
        public void Remove()
        {
            this.Load(0);
            if(uppdrag != null && uppdrag.Count > 0)
            foreach(Uppdrag a in uppdrag)
            {
                a.Remove();
            }
            Databas.removeMachine(this);
        }
        public Uppdrag AddUppdrag(Uppdrag uppdrag)
        {
            if(uppdrag != null && !hasUppdrag(uppdrag))
            {                
                uppdrag.maskinID = this.maskinID;
                this.Load(0);
                uppdrag.uppdragID = this.maskinID + "-"+(this.uppdrag.Count + 1).ToString().PadLeft(2, '0');
                this.uppdrag.Add(uppdrag);
                uppdrag.Add();                
                this.Update();
                return uppdrag;
            }
            return null;
        }
        public List<Uppdrag> Uppdrag()
        {
            return Databas.getUppdragSortedMachine(this);
        }
        public List<Uppdrag> Uppdrag(bool aktuella)
        {
            if (aktuella)
                return Databas.getMachinesUppdrag(this.maskinID, 1);
            else
                return Databas.getMachinesUppdrag(this.maskinID, 2);
            
        }
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
        public string getPinCode(bool access)
        {
            string a = String.Empty;
            if (access)
            {
                if (this.pincode.Length < 6)
                {
                    a = this.pincode;
                    setPinCode(this.pincode);                    
                }
                else
                {                    
                    byte[] bytesToBeDecrypted = Convert.FromBase64String(pincode);
                    byte[] passwordBytes = Encoding.UTF8.GetBytes("abcdefg");
                    passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
                    MessageBox.Show(Convert.ToBase64String(passwordBytes));

                    byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

                    string result = Encoding.UTF8.GetString(bytesDecrypted);
                    MessageBox.Show("get: "+result);
                    return result;
                }                                  
            }            
            return a;
        }
        public string setPinCode(string pin)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(pin);
            byte[] passwordBytes = Encoding.UTF8.GetBytes("abcdefg");

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
            MessageBox.Show(Convert.ToBase64String(passwordBytes));
            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);
            MessageBox.Show("set: " + result);
            return result;
        }
        private byte[] EncryptDataToMemory(string Data, byte[] Key, byte[] IV)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a new TripleDES object.
                TripleDES tripleDESalg = TripleDES.Create();

                // Create a CryptoStream using the MemoryStream  
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tripleDESalg.CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array. 
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the  
                // MemoryStream that holds the  
                // encrypted data. 
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer. 
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
        public static string DecryptTextFromMemory(byte[] Data, byte[] Key, byte[] IV)
        {
            try
            {
                // Create a new MemoryStream using the passed  
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a new TripleDES object.
                TripleDES tripleDESalg = TripleDES.Create();

                // Create a CryptoStream using the MemoryStream  
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tripleDESalg.CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data. 
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream 
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it. 
                return new ASCIIEncoding().GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
        public bool hasUppdrag(Uppdrag uppdrag)
        {
            bool check = false;
            foreach (Uppdrag search in this.uppdrag)
            {
                if (this.Equals(search))
                    check = true;
            }
            return check;
        }
        public bool hasHamtning()
        {
            bool check = false;
            check = Databas.checkAktuellHamtning(this.maskinID);
            return check;
        }
        public static Maskin Find(string maskinID)
        {
            return Databas.getMachine(maskinID);
        }
        #endregion
        public bool Equals(Maskin obj)
        {
            return (obj != null && obj.maskinID == this.maskinID && obj.customerID == this.customerID && obj.ToString().Equals(this.ToString()));
        }
        public string Display
        {
            get
            {
                if (string.IsNullOrEmpty(maskinID))
                { return "Ny maskin"; }
                string maskin = maskinID.Substring(maskinID.Length - 2);
                return maskin + " - " + brand + " - " + type;
            }
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(maskinID))
            { return "Ny maskin"; }
            string maskin = maskinID.Substring(maskinID.Length - 2);
            return maskin + " - " + brand + " - " + type;
        }
    }
}
