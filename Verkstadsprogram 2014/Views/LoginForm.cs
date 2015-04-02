using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Verkstadsprogram_2014.Views
{
    public partial class LoginForm : Form
    {
        Maskin maskin;
        Hamtning hamtning;
        public LoginForm(Maskin maskin)
        {
            InitializeComponent();
            this.maskin = maskin;
        }
        public LoginForm(Hamtning hamtning)
        {
            InitializeComponent();
            this.hamtning = hamtning;
        }

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && autentisera(textBoxPassword.Text))
            {                
                if(maskin != null)
                    textBoxPincode.Text = maskin.getPinCode(true);                
                else if(hamtning != null)
                    textBoxPincode.Text = hamtning.getPinCode(true);                
            }
            
        }
        public static bool Authenticate(string text)
        {
            return autentisera(text);
        }
        private static bool autentisera(string text)
        {           
            return ComputeHash(text, "koder").Equals("59-54-07-79-A9-B9-FB-AA-F9-74-9B-64-AA-15-2E-21-CA-99-3F-20-95-40-3D-8F-2A-E1-A9-01-F8-BD-01-B3");
        }
        private static string ComputeHash(string input, string salt)
        {
            using (SHA256CryptoServiceProvider crypt = new SHA256CryptoServiceProvider())
            {
                if (!String.IsNullOrEmpty(input) && !String.IsNullOrEmpty(salt))
                {
                    Byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                    Byte[] saltBytes = System.Text.Encoding.UTF8.GetBytes(salt);

                    Byte[] saltedInput = new Byte[saltBytes.Length + inputBytes.Length];
                    saltBytes.CopyTo(saltedInput, 0);
                    inputBytes.CopyTo(saltedInput, salt.Length);
                    Byte[] hashedBytes = crypt.ComputeHash(saltedInput);
                    return BitConverter.ToString(hashedBytes);
                }
                return String.Empty;
            }
        }
            
        
    }
}
