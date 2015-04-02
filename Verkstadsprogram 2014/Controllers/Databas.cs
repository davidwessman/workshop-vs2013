using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Verkstadsprogram_2014.Models;



namespace Verkstadsprogram_2014
{
    public class Databas : Component
    {
        static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["Verkstadsprogram_2014.Properties.Settings.VerkstadsdatabasConnectionString"].ConnectionString;
            }
        }
        public static string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings. 
            try
            {
                string pattern = "[\\~#%&*{}/:<>?|\"-\']";
                string replacement = " ";

                Regex regEx = new Regex(pattern);
                return Regex.Replace(regEx.Replace(strIn, replacement), @"\s+", " ");
            }
            // If we timeout when replacing invalid characters,  
            // we should return Empty. 
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        #region Settings
        
        public static string loadMode()
        {
            try
            {
                string mode = "";
                using (var databas = new SqlConnection(ConnectionString))
                {                    
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT text FROM Settings WHERE mode = 'mode'";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mode = reader.GetString(0);
                        }
                    }
                }
                if (mode == "")
                    mode = "Produktion";
                return mode;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue:(loadMode) " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(loadMode) " + ex.Message);
                return null;
            }
        }
        public static void setMode(Mode mode)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Settings SET text = @text WHERE mode = 'mode'";                                        
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = mode.mode;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:saveSettings " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:saveSettings " + ex.Message);
            }           
        }
        public static Mode findMode(string mode)
        {
            try
            {
                Mode modet = null;
                using (var databas = new SqlConnection(ConnectionString))
                {  
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Settings WHERE mode = @mode";
                    command.Parameters.Add("@mode", SqlDbType.NVarChar);
                    command.Parameters["@mode"].Value = mode;
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            modet = new Mode(reader.GetString(0),reader.GetInt32(1),reader.GetString(2));
                        }
                    }
                }                
                return modet;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue:(findMode) " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(findMode) " + ex.Message);
                return null;
            }
        }        
        public static void updateMode(Mode mode)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {  
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Settings SET kundnummer = @kundnummer, text = @text WHERE mode = @mode";
                    command.Parameters.Add("@kundnummer", SqlDbType.Int);
                    command.Parameters["@kundnummer"].Value = mode.kundnummer;
                    command.Parameters.Add("@mode", SqlDbType.NVarChar);
                    command.Parameters["@mode"].Value = mode.mode;
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = mode.text;
                    databas.Open();
                    command.ExecuteNonQuery();
                }

            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:saveSettings " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:saveSettings " + ex.Message);
            }
           
        }
        public static void addMode(Mode mode)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Settings (mode,kundnummer,text) VALUES (@mode,@kundnummer,@text)";
                    command.Parameters.Add("@kundnummer", SqlDbType.Int);
                    command.Parameters["@kundnummer"].Value = mode.kundnummer;
                    command.Parameters.Add("@mode", SqlDbType.NVarChar);
                    command.Parameters["@mode"].Value = mode.mode;
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = mode.text;
                    databas.Open();
                    command.ExecuteNonQuery();
                }

            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:saveSettings " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:saveSettings " + ex.Message);
            }
             
           
        }
        public static List<Mode> getModes()
        {
            try
            {
                List<Mode> modes = new List<Mode>();
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Settings";
                    

                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            modes.Add(new Mode(reader.GetString(0), reader.GetInt32(1), reader.GetString(2)));
                        }
                    }
                }

                return modes;

            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue:getCustomers " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:getCustomers " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void removeMode(Mode mode)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"DELETE FROM Settings WHERE mode = @mode";
                    command.Parameters.Add("@mode", SqlDbType.NVarChar);
                    command.Parameters["@mode"].Value = mode.mode;
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = mode.text;
                    databas.Open();
                    command.ExecuteNonQuery();
                }                
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue:(findMode) " + ex.Message);                
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(findMode) " + ex.Message);                
            }
        }
       
        #endregion

        #region Customer
        public static bool addCustomer(Customer customer)
        {
            try
            {
                bool result = false;
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Kunder (customerID,firstName,lastName,phone,epost,leveransadress,fakturaadress,inlagd,aktuell,foretag,orgNr,foretagsnamn) values (@customerID,@firstName,@lastName,@phone,@epost,@leveransadress,@fakturaadress,@inlagd,@aktuell,@foretag,@orgNr,@foretagsnamn)";
                    command.Parameters.Add("@customerID", SqlDbType.NVarChar);
                    command.Parameters["@customerID"].Value = customer.customerID;
                    command.Parameters.Add("@firstName", SqlDbType.NVarChar);
                    command.Parameters["@firstName"].Value = customer.firstNamn;
                    command.Parameters.Add("@lastName", SqlDbType.NVarChar);
                    command.Parameters["@lastName"].Value = customer.lastNamn;
                    command.Parameters.Add("@phone", SqlDbType.NVarChar);
                    command.Parameters["@phone"].Value = customer.phone;
                    command.Parameters.Add("@epost", SqlDbType.NVarChar);
                    command.Parameters["@epost"].Value = customer.epost;
                    command.Parameters.Add("@leveransadress", SqlDbType.NVarChar);
                    command.Parameters["@leveransadress"].Value = customer.leveransadress.Save();
                    command.Parameters.Add("@fakturaadress", SqlDbType.NVarChar);
                    command.Parameters["@fakturaadress"].Value = customer.fakturaadress.Save();
                    command.Parameters.Add("@inlagd", SqlDbType.DateTime);
                    command.Parameters["@inlagd"].Value = customer.inlagd;
                    command.Parameters.Add("@aktuell", SqlDbType.Bit);
                    command.Parameters["@aktuell"].Value = customer.aktuell;
                    command.Parameters.Add("@foretag", SqlDbType.Bit);
                    command.Parameters["@foretag"].Value = customer.foretag;
                    command.Parameters.Add("@orgNr", SqlDbType.NVarChar);
                    command.Parameters["@orgNr"].Value = customer.orgNr;
                    command.Parameters.Add("@foretagsnamn", SqlDbType.NVarChar);
                    command.Parameters["@foretagsnamn"].Value = customer.foretagsnamn;
                    databas.Open();
                    command.ExecuteNonQuery();
                    result = true;
                }
                return result;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue:addCustomer " + ex.Message);
                return false;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:addCustomer " + ex.Message);
                return false;
            }
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void updateCustomer(Customer customer)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Kunder SET firstName = @firstName , lastName = @lastName , phone = @phone , epost = @epost , leveransadress = @leveransadress , fakturaadress = @fakturaadress  , aktuell = @aktuell,foretag = @foretag,orgNr = @orgNr, foretagsnamn = @foretagsnamn  WHERE customerID = @customerID";
                    command.Parameters.Add("@customerID", SqlDbType.NVarChar);
                    command.Parameters["@customerID"].Value = customer.customerID;
                    command.Parameters.Add("@firstName", SqlDbType.NVarChar);
                    command.Parameters["@firstName"].Value = customer.firstNamn;
                    command.Parameters.Add("@lastName", SqlDbType.NVarChar);
                    command.Parameters["@lastName"].Value = customer.lastNamn;
                    command.Parameters.Add("@phone", SqlDbType.NVarChar);
                    command.Parameters["@phone"].Value = customer.phone;
                    command.Parameters.Add("@epost", SqlDbType.NVarChar);
                    command.Parameters["@epost"].Value = customer.epost;
                    command.Parameters.Add("@leveransadress", SqlDbType.NVarChar);
                    command.Parameters["@leveransadress"].Value = customer.leveransadress.Save();
                    command.Parameters.Add("@fakturaadress", SqlDbType.NVarChar);
                    command.Parameters["@fakturaadress"].Value = customer.fakturaadress.Save();
                    command.Parameters.Add("@aktuell", SqlDbType.Bit);
                    command.Parameters["@aktuell"].Value = customer.aktuell;
                    command.Parameters.Add("@foretag", SqlDbType.Bit);
                    command.Parameters["@foretag"].Value = customer.foretag;
                    command.Parameters.Add("@orgNr", SqlDbType.NVarChar);
                    command.Parameters["@orgNr"].Value = customer.orgNr;
                    command.Parameters.Add("@foretagsnamn", SqlDbType.NVarChar);
                    command.Parameters["@foretagsnamn"].Value = customer.foretagsnamn;
                    databas.Open();
                    command.ExecuteNonQuery();
                }                
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:updateCustomer " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:updateCustomer " + ex.Message);
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void removeCustomer(Customer customer)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"DELETE from Kunder WHERE customerID = @Id";
                    command.Parameters.Add("@Id", SqlDbType.NVarChar);
                    command.Parameters["@Id"].Value = customer.customerID;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(removeCustomer): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(removeCustomer): " + ex.Message);
            }
            
            finally // don't forget to close your connection when exception occurs.
            {

            }
        }
        public static BindingList<Customer> getCustomers(bool aktuell)
        {
            try
            {
                BindingList<Customer> result = new BindingList<Customer>();
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = (aktuell) ? @"SELECT * FROM Kunder WHERE aktuell = 'true'" : @"SELECT * FROM Kunder";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Customer(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetBoolean(9), reader.GetString(10), reader.GetString(11)));
                        }
                    }
                }

                return result;

            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue:getCustomers " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:getCustomers " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static List<Customer> searchCustomer(string text)
        {
            try
            {                
                List<Customer> result = new List<Customer>();
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Kunder WHERE firstName LIKE @text OR lastName LIKE @text OR customerID LIKE @text";
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = "%" + text + "%";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Customer(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetBoolean(9), reader.GetString(10), reader.GetString(11)));
                        }
                    }
                }                
                return result;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:searchCustomer " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:searchCustomer " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static Customer searchCustomerID(string text)
        {
            try
            {
                Customer result = null;
                using (var databas = new SqlConnection(ConnectionString))
                {                   
                    text = CleanInput(text);
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Kunder WHERE customerID LIKE @text";
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = "%" + text + "%";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new Customer(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetBoolean(9), reader.GetString(10), reader.GetString(11));
                        }
                    }
                }
                return result;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:searchCustomerID " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:searchCustomerID " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        #endregion

        #region Maskin
        public static void addMachine(Maskin maskin)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {  
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Maskiner (maskinID,inlagd,changed,brand,type,serialNbr,customerID,latestService,winterStorage,modell,productNbr,productionYear,motorNbr,pincode,aggregatNr) values (@maskinID,@inlagd,@changed,@brand,@type,@serialNbr,@customerID,@latestService,@winterStorage,@modell, @productNbr, @productionYear,@motorNbr,@pincode,@aggregatNr)";
                    command.Parameters.Add("@maskinID", SqlDbType.NVarChar);
                    command.Parameters["@maskinID"].Value = maskin.maskinID;
                    command.Parameters.Add("@inlagd", SqlDbType.DateTime);
                    command.Parameters["@inlagd"].Value = maskin.inlagd;
                    command.Parameters.Add("@changed", SqlDbType.DateTime);
                    command.Parameters["@changed"].Value = maskin.changed;
                    command.Parameters.Add("@brand", SqlDbType.NVarChar);
                    command.Parameters["@brand"].Value = maskin.brand;
                    command.Parameters.Add("@type", SqlDbType.NVarChar);
                    command.Parameters["@type"].Value = maskin.type;
                    command.Parameters.Add("@serialNbr", SqlDbType.NVarChar);
                    command.Parameters["@serialNbr"].Value = maskin.serialNbr;
                    command.Parameters.Add("@customerID", SqlDbType.NVarChar);
                    command.Parameters["@customerID"].Value = maskin.customerID;
                    command.Parameters.Add("@latestService", SqlDbType.DateTime);
                    command.Parameters["@latestService"].Value = maskin.latestService;
                    command.Parameters.Add("@winterStorage", SqlDbType.Bit);
                    command.Parameters["@winterStorage"].Value = maskin.vinterforvaring;
                    command.Parameters.Add("@modell", SqlDbType.NVarChar);
                    command.Parameters["@modell"].Value = maskin.modell;
                    command.Parameters.Add("@productNbr", SqlDbType.NVarChar);
                    command.Parameters["@productNbr"].Value = maskin.productNbr;
                    command.Parameters.Add("@productionYear", SqlDbType.NVarChar);
                    command.Parameters["@productionYear"].Value = maskin.productionYear;
                    command.Parameters.Add("@motorNbr", SqlDbType.NVarChar);
                    command.Parameters["@motorNbr"].Value = maskin.motorNr;
                    command.Parameters.Add("@pincode", SqlDbType.NVarChar);
                    command.Parameters["@pincode"].Value = maskin.pincode;
                    command.Parameters.Add("@aggregatNr", SqlDbType.NVarChar);
                    command.Parameters["@aggregatNr"].Value = maskin.aggregatNbr;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(AddMachine): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddMachine): " + ex.Message);
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void updateMachine(Maskin maskin)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Maskiner SET inlagd = @inlagd , changed = @changed , brand = @brand , type = @type , serialNbr = @serialNbr , customerID = @customerID , latestService = @latestService , winterStorage = @winterStorage , modell = @modell , productNbr = @productNbr , productionYear = @productionYear,motorNbr = @motorNbr, pincode = @pincode , aggregatNr = @aggregatNr WHERE maskinID = @maskinID";
                    command.Parameters.Add("@maskinID", SqlDbType.NVarChar);
                    command.Parameters["@maskinID"].Value = maskin.maskinID;
                    command.Parameters.Add("@inlagd", SqlDbType.DateTime);
                    command.Parameters["@inlagd"].Value = maskin.inlagd;
                    command.Parameters.Add("@changed", SqlDbType.DateTime);
                    command.Parameters["@changed"].Value = maskin.changed;
                    command.Parameters.Add("@brand", SqlDbType.NVarChar);
                    command.Parameters["@brand"].Value = maskin.brand;
                    command.Parameters.Add("@type", SqlDbType.NVarChar);
                    command.Parameters["@type"].Value = maskin.type;
                    command.Parameters.Add("@serialNbr", SqlDbType.NVarChar);
                    command.Parameters["@serialNbr"].Value = maskin.serialNbr;
                    command.Parameters.Add("@customerID", SqlDbType.NVarChar);
                    command.Parameters["@customerID"].Value = maskin.customerID;
                    command.Parameters.Add("@latestService", SqlDbType.DateTime);
                    command.Parameters["@latestService"].Value = maskin.latestService;
                    command.Parameters.Add("@winterStorage", SqlDbType.Bit);
                    command.Parameters["@winterStorage"].Value = maskin.vinterforvaring;
                    command.Parameters.Add("@modell", SqlDbType.NVarChar);
                    command.Parameters["@modell"].Value = maskin.modell;
                    command.Parameters.Add("@productNbr", SqlDbType.NVarChar);
                    command.Parameters["@productNbr"].Value = maskin.productNbr;
                    command.Parameters.Add("@productionYear", SqlDbType.NVarChar);
                    command.Parameters["@productionYear"].Value = maskin.productionYear;
                    command.Parameters.Add("@motorNbr", SqlDbType.NVarChar);
                    command.Parameters["@motorNbr"].Value = maskin.motorNr;
                    command.Parameters.Add("@pincode", SqlDbType.NVarChar);
                    command.Parameters["@pincode"].Value = maskin.pincode;
                    command.Parameters.Add("@aggregatNr", SqlDbType.NVarChar);
                    command.Parameters["@aggregatNr"].Value = maskin.aggregatNbr;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(Uppdatera maskin): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(Uppdatera maskin): " + ex.Message);
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void removeMachine(Maskin maskin)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"DELETE from Maskiner WHERE maskinID = @Id";
                    command.Parameters.Add("@Id", SqlDbType.NVarChar);
                    command.Parameters["@Id"].Value = maskin.maskinID;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(removeMachine): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(removeMachine): " + ex.Message);
            }
            
            finally // don't forget to close your connection when exception occurs.
            {

            }
        }
        public static List<Maskin> getCustomersMachines(string text)
        {            
            try
            {
                List<Maskin> result = new List<Maskin>();
                using (var databas = new SqlConnection(ConnectionString))
                {                    
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Maskiner WHERE customerID = @customer";
                    command.Parameters.Add("@customer", SqlDbType.NVarChar);
                    command.Parameters["@customer"].Value = CleanInput(text);
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Maskin(reader.GetString(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13),reader.GetString(14)));
                        }
                    }

                }
                return result;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue: " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue: " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static Maskin getMachine(string text)
        {            
            try
            {
                Maskin result = null;
                using (var databas = new SqlConnection(ConnectionString))
                {                     
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Maskiner WHERE maskinID = @maskinID";
                    command.Parameters.Add("@maskinID", SqlDbType.NVarChar);
                    command.Parameters["@maskinID"].Value = CleanInput(text);
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = (new Maskin(reader.GetString(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14)));
                        }
                    }                    
                }                
                return result;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue: " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue: " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Maskin> getMachines()
        {
            try
            {
                List<Maskin> result = new List<Maskin>();
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Maskiner";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add( new Maskin(reader.GetString(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetBoolean(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14)));
                        }
                    }
                }

                return result;

            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue:getMachines " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:getMachines " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {

            }
        }
        #endregion

        #region Uppdrag
        public static void addUppdrag(Uppdrag uppdrag)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Uppdrag (uppdragID,maskinID,inlagd,arbete,arbeteDone,reparationSpec,besked,deadline,ovrigt,startat,arbeteStart,reservdelar,orderdelar,klar,arbeteKlart,reparator,arbetstid,kommentar,faktura,fakturaNr,hylla,planet,inlamnat,utlamnad,utlamnadDate)" +
                                                               "VALUES (@uppdragID,@maskinID,@inlagd,@arbete,@arbeteDone,@reparationSpec,@besked,@deadline,@ovrigt,@startat,@arbeteStart,@reservdelar,@orderdelar,@klar,@arbeteKlart,@reparator,@arbetstid,@kommentar,@faktura,@fakturaNr,@hylla,@planet,@inlamnat,@utlamnad,@utlamnadDate)";
                    command.Parameters.Add("@uppdragID", SqlDbType.NVarChar);
                    command.Parameters["@uppdragID"].Value = uppdrag.uppdragID;

                    command.Parameters.Add("@maskinID", SqlDbType.NVarChar);
                    command.Parameters["@maskinID"].Value = uppdrag.maskinID;

                    command.Parameters.Add("@inlagd", SqlDbType.DateTime);
                    command.Parameters["@inlagd"].Value = uppdrag.inlagd;

                    command.Parameters.Add("@arbete", SqlDbType.NVarChar);
                    command.Parameters["@arbete"].Value = uppdrag.ArbeteSpara(false);

                    command.Parameters.Add("@arbeteDone", SqlDbType.NVarChar);
                    command.Parameters["@arbeteDone"].Value = uppdrag.ArbeteSpara(true);

                    command.Parameters.Add("@reparationSpec", SqlDbType.NVarChar);
                    command.Parameters["@reparationSpec"].Value = uppdrag.reparationSpec;

                    command.Parameters.Add("@besked", SqlDbType.NVarChar);
                    command.Parameters["@besked"].Value = uppdrag.besked;

                    command.Parameters.Add("@deadline", SqlDbType.NVarChar);
                    command.Parameters["@deadline"].Value = uppdrag.deadline;

                    command.Parameters.Add("@ovrigt", SqlDbType.NVarChar);
                    command.Parameters["@ovrigt"].Value = uppdrag.ovrigt;

                    command.Parameters.Add("@startat", SqlDbType.Bit);
                    command.Parameters["@startat"].Value = uppdrag.startat;

                    command.Parameters.Add("@arbeteStart", SqlDbType.DateTime);
                    command.Parameters["@arbeteStart"].Value = uppdrag.arbeteStart;

                    command.Parameters.Add("@reservdelar", SqlDbType.NVarChar);
                    command.Parameters["@reservdelar"].Value = uppdrag.ReservdelarSpara;

                    command.Parameters.Add("@orderdelar", SqlDbType.NVarChar);
                    command.Parameters["@orderdelar"].Value = uppdrag.OrderdelarSpara;

                    command.Parameters.Add("@klar", SqlDbType.Bit);
                    command.Parameters["@klar"].Value = uppdrag.klar;

                    command.Parameters.Add("@arbeteKlart", SqlDbType.DateTime);
                    command.Parameters["@arbeteKlart"].Value = uppdrag.arbeteKlart;

                    command.Parameters.Add("@reparator", SqlDbType.NVarChar);
                    command.Parameters["@reparator"].Value = uppdrag.reparator;

                    command.Parameters.Add("@arbetstid", SqlDbType.Int);
                    command.Parameters["@arbetstid"].Value = uppdrag.Arbetstid;

                    command.Parameters.Add("@kommentar", SqlDbType.NVarChar);
                    command.Parameters["@kommentar"].Value = uppdrag.kommentar;

                    command.Parameters.Add("@faktura", SqlDbType.Bit);
                    command.Parameters["@faktura"].Value = uppdrag.faktura;

                    command.Parameters.Add("@fakturaNr", SqlDbType.NVarChar);
                    command.Parameters["@fakturaNr"].Value = uppdrag.fakturanummer;

                    command.Parameters.Add("@hylla", SqlDbType.NVarChar);
                    command.Parameters["@hylla"].Value = uppdrag.hylla;

                    command.Parameters.Add("@planet", SqlDbType.Int);
                    command.Parameters["@planet"].Value = uppdrag.plan;

                    command.Parameters.Add("@inlamnat", SqlDbType.NVarChar);
                    command.Parameters["@inlamnat"].Value = uppdrag.Inlamnat();

                    command.Parameters.Add("@utlamnad", SqlDbType.Bit);
                    command.Parameters["@utlamnad"].Value = uppdrag.utlamnad;

                    command.Parameters.Add("@utlamnadDate", SqlDbType.DateTime);
                    command.Parameters["@utlamnadDate"].Value = uppdrag.utlamnadDate;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {                
                MessageBox.Show("Execute exception issue: (addUppdrag) " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue: (addUppdrag)" + ex.Message);
            }
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void updateUppdrag(Uppdrag uppdrag)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Uppdrag SET uppdragID = @uppdragID,maskinID = @maskinID,inlagd = @inlagd,arbete = @arbete,arbeteDone = @arbeteDone ,reparationSpec = @reparationSpec ,besked = @besked ,deadline = @deadline , ovrigt = @ovrigt ,startat= @startat ,arbeteStart= @arbeteStart ,reservdelar= @reservdelar ,orderdelar= @orderdelar ,klar= @klar ,arbeteKlart= @arbeteKlart ,reparator= @reparator ,arbetstid = @arbetstid ,kommentar = @kommentar ,faktura = @faktura ,fakturaNr = @fakturaNr ,hylla = @hylla ,planet = @planet ,inlamnat = @inlamnat ,utlamnad = @utlamnad ,utlamnadDate = @utlamnadDate" +
                                         " WHERE uppdragID = @uppdragID";
                    
                    command.Parameters.Add("@uppdragID", SqlDbType.NVarChar);
                    command.Parameters["@uppdragID"].Value = uppdrag.uppdragID;

                    command.Parameters.Add("@maskinID", SqlDbType.NVarChar);
                    command.Parameters["@maskinID"].Value = uppdrag.maskinID;

                    command.Parameters.Add("@inlagd", SqlDbType.DateTime);
                    command.Parameters["@inlagd"].Value = uppdrag.inlagd;

                    command.Parameters.Add("@arbete", SqlDbType.NVarChar);
                    command.Parameters["@arbete"].Value = uppdrag.ArbeteSpara(false);

                    command.Parameters.Add("@arbeteDone", SqlDbType.NVarChar);
                    command.Parameters["@arbeteDone"].Value = uppdrag.ArbeteSpara(true);

                    command.Parameters.Add("@reparationSpec", SqlDbType.NVarChar);
                    command.Parameters["@reparationSpec"].Value = uppdrag.reparationSpec;

                    command.Parameters.Add("@besked", SqlDbType.NVarChar);
                    command.Parameters["@besked"].Value = uppdrag.besked;

                    command.Parameters.Add("@deadline", SqlDbType.NVarChar);
                    command.Parameters["@deadline"].Value = uppdrag.deadline;

                    command.Parameters.Add("@ovrigt", SqlDbType.NVarChar);
                    command.Parameters["@ovrigt"].Value = uppdrag.ovrigt;

                    command.Parameters.Add("@startat", SqlDbType.Bit);
                    command.Parameters["@startat"].Value = uppdrag.startat;

                    command.Parameters.Add("@arbeteStart", SqlDbType.DateTime);
                    command.Parameters["@arbeteStart"].Value = uppdrag.arbeteStart;

                    command.Parameters.Add("@reservdelar", SqlDbType.NVarChar);
                    command.Parameters["@reservdelar"].Value = uppdrag.ReservdelarSpara;

                    command.Parameters.Add("@orderdelar", SqlDbType.NVarChar);
                    command.Parameters["@orderdelar"].Value = uppdrag.OrderdelarSpara;

                    command.Parameters.Add("@klar", SqlDbType.Bit);
                    command.Parameters["@klar"].Value = uppdrag.klar;

                    command.Parameters.Add("@arbeteKlart", SqlDbType.DateTime);
                    command.Parameters["@arbeteKlart"].Value = uppdrag.arbeteKlart;

                    command.Parameters.Add("@reparator", SqlDbType.NVarChar);
                    command.Parameters["@reparator"].Value = uppdrag.reparator;

                    command.Parameters.Add("@arbetstid", SqlDbType.Int);
                    command.Parameters["@arbetstid"].Value = uppdrag.Arbetstid;

                    command.Parameters.Add("@kommentar", SqlDbType.NVarChar);
                    command.Parameters["@kommentar"].Value = uppdrag.kommentar;

                    command.Parameters.Add("@faktura", SqlDbType.Bit);
                    command.Parameters["@faktura"].Value = uppdrag.faktura;

                    command.Parameters.Add("@fakturaNr", SqlDbType.NVarChar);
                    command.Parameters["@fakturaNr"].Value = uppdrag.fakturanummer;

                    command.Parameters.Add("@hylla", SqlDbType.NVarChar);
                    command.Parameters["@hylla"].Value = uppdrag.hylla;

                    command.Parameters.Add("@planet", SqlDbType.Int);
                    command.Parameters["@planet"].Value = uppdrag.plan;

                    command.Parameters.Add("@inlamnat", SqlDbType.NVarChar);
                    command.Parameters["@inlamnat"].Value = uppdrag.Inlamnat();

                    command.Parameters.Add("@utlamnad", SqlDbType.Bit);
                    command.Parameters["@utlamnad"].Value = uppdrag.utlamnad;

                    command.Parameters.Add("@utlamnadDate", SqlDbType.DateTime);
                    command.Parameters["@utlamnadDate"].Value = uppdrag.utlamnadDate;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("(updateUppdrag) Execute exception issue: " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("(updateUppdrag) Connection Exception issue: " + ex.Message);
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void removeUppdrag(Uppdrag uppdrag)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"DELETE from Uppdrag WHERE uppdragID = @Id";
                    command.Parameters.Add("@Id", SqlDbType.NVarChar);
                    command.Parameters["@Id"].Value = uppdrag.uppdragID;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(removeUppdrag): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(removeUppdrag): " + ex.Message);
            }
            
            finally // don't forget to close your connection when exception occurs.
            {

            }
        }
        public static Uppdrag getUppdrag(string text)
        {
            try
            {
                Uppdrag searchUppdrag = null;
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Uppdrag WHERE uppdragID = @uppdragID";
                    command.Parameters.Add("@uppdragID", SqlDbType.NVarChar);
                    command.Parameters["@uppdragID"].Value = CleanInput(text);
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchUppdrag = new Uppdrag(reader.GetString(0),reader.GetString(1),reader.GetDateTime(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetDateTime(7),reader.GetString(8),reader.GetBoolean(9),reader.GetDateTime(10),reader.GetString(11),reader.GetString(12),reader.GetBoolean(13),reader.GetDateTime(14),reader.GetString(15),reader.GetInt32(16),reader.GetString(17),reader.GetBoolean(18),reader.GetString(19),reader.GetString(20),reader.GetInt32(21),reader.GetString(22),reader.GetBoolean(23),reader.GetDateTime(24));
                        }
                    }

                }
                return searchUppdrag;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("(getUppdrag) Execute exception issue: " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("(getUppdrag) Connection Exception issue: " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Uppdrag> getAllUppdrag()
        {
            List<Uppdrag> searchUppdrag = new List<Uppdrag>();
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Uppdrag";                    
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchUppdrag.Add(new Uppdrag(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetString(8), reader.GetBoolean(9), reader.GetDateTime(10), reader.GetString(11), reader.GetString(12), reader.GetBoolean(13), reader.GetDateTime(14), reader.GetString(15), reader.GetInt32(16), reader.GetString(17), reader.GetBoolean(18), reader.GetString(19), reader.GetString(20), reader.GetInt32(21), reader.GetString(22), reader.GetBoolean(23), reader.GetDateTime(24)));
                        }
                    }
                }
                return searchUppdrag;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue: " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue: " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {


            }
        }
        public static BindingList<Uppdrag> getAllUppdrag(bool klar, bool faktura,bool utlamnad)
        {
            BindingList<Uppdrag> searchUppdrag = new BindingList<Uppdrag>();
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Uppdrag WHERE klar = @klar AND faktura = @faktura AND utlamnad = @utlamnad";
                    command.Parameters.Add("@klar", SqlDbType.Bit);
                    command.Parameters.Add("@faktura",SqlDbType.Bit);
                    command.Parameters.Add("@utlamnad", SqlDbType.Bit);
                    command.Parameters["@klar"].Value = klar;
                    command.Parameters["@faktura"].Value = faktura;
                    command.Parameters["@utlamnad"].Value = utlamnad;
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {                            
                                searchUppdrag.Add(new Uppdrag(reader.GetString(0),reader.GetString(1),reader.GetDateTime(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetDateTime(7),reader.GetString(8),reader.GetBoolean(9),reader.GetDateTime(10),reader.GetString(11),reader.GetString(12),reader.GetBoolean(13),reader.GetDateTime(14),reader.GetString(15),reader.GetInt32(16),reader.GetString(17),reader.GetBoolean(18),reader.GetString(19),reader.GetString(20),reader.GetInt32(21),reader.GetString(22),reader.GetBoolean(23),reader.GetDateTime(24)));
                        }
                    }
                }
                return searchUppdrag;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue: " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue: " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static BindingList<Uppdrag> getDeadlineUppdrag(DateTime deadline)
        {
            BindingList<Uppdrag> searchUppdrag = new BindingList<Uppdrag>();
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Uppdrag WHERE klar = 'false' AND deadline <= @deadline";
                    command.Parameters.Add("@deadline", SqlDbType.NVarChar);
                    command.Parameters["@deadline"].Value = deadline.ToString("yyyy-MM-dd");
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {   
                                searchUppdrag.Add(new Uppdrag(reader.GetString(0),reader.GetString(1),reader.GetDateTime(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetDateTime(7),reader.GetString(8),reader.GetBoolean(9),reader.GetDateTime(10),reader.GetString(11),reader.GetString(12),reader.GetBoolean(13),reader.GetDateTime(14),reader.GetString(15),reader.GetInt32(16),reader.GetString(17),reader.GetBoolean(18),reader.GetString(19),reader.GetString(20),reader.GetInt32(21),reader.GetString(22),reader.GetBoolean(23),reader.GetDateTime(24)));
                        }   
                    }
                }
                return searchUppdrag;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue: " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue: " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Uppdrag> getMachinesUppdrag(string text,int val)
        {
            List<Uppdrag> searchUppdrag = new List<Uppdrag>();
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = CleanInput(text);
                    switch (val)
                    {
                        case 0: command.CommandText = @"SELECT * FROM Uppdrag WHERE maskinID= @text"; break;
                        case 1: command.CommandText = @"SELECT * FROM Uppdrag WHERE maskinID= @text AND klar = 'false'"; break;
                        case 2: command.CommandText = @"SELECT * FROM Uppdrag WHERE maskinID= @text AND klar = 'true'"; break;
                        default: return null;
                    }

                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchUppdrag.Add(new Uppdrag(reader.GetString(0),reader.GetString(1),reader.GetDateTime(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetDateTime(7),reader.GetString(8),reader.GetBoolean(9),reader.GetDateTime(10),reader.GetString(11),reader.GetString(12),reader.GetBoolean(13),reader.GetDateTime(14),reader.GetString(15),reader.GetInt32(16),reader.GetString(17),reader.GetBoolean(18),reader.GetString(19),reader.GetString(20),reader.GetInt32(21),reader.GetString(22),reader.GetBoolean(23),reader.GetDateTime(24)));
                        }
                    }

                }
                return searchUppdrag;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("(getMachinesUppdrag)Execute exception issue: " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("(getMachinesUppdrag)Connection Exception issue: " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Uppdrag> getUppdragSortedMachine(Maskin maskin)
        {
            List<Uppdrag> searchUppdrag = new List<Uppdrag>();
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = maskin.maskinID;                    
                    command.CommandText = @"SELECT * FROM Uppdrag WHERE maskinID= @text ORDER BY uppdragID DESC ";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            searchUppdrag.Add(new Uppdrag(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetString(8), reader.GetBoolean(9), reader.GetDateTime(10), reader.GetString(11), reader.GetString(12), reader.GetBoolean(13), reader.GetDateTime(14), reader.GetString(15), reader.GetInt32(16), reader.GetString(17), reader.GetBoolean(18), reader.GetString(19), reader.GetString(20), reader.GetInt32(21), reader.GetString(22), reader.GetBoolean(23), reader.GetDateTime(24)));
                        }
                    }

                }
                return searchUppdrag;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("(getMachinesUppdrag)Execute exception issue: " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("(getMachinesUppdrag)Connection Exception issue: " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {


            }
        }
        public static List<Uppdrag> getUppdragSpareparts()
        {
            List<Uppdrag> searchUppdrag = new List<Uppdrag>();
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Uppdrag WHERE klar = 'false' AND datalength(orderDelar) > 0";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {                            
                                searchUppdrag.Add(new Uppdrag(reader.GetString(0),reader.GetString(1),reader.GetDateTime(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetDateTime(7),reader.GetString(8),reader.GetBoolean(9),reader.GetDateTime(10),reader.GetString(11),reader.GetString(12),reader.GetBoolean(13),reader.GetDateTime(14),reader.GetString(15),reader.GetInt32(16),reader.GetString(17),reader.GetBoolean(18),reader.GetString(19),reader.GetString(20),reader.GetInt32(21),reader.GetString(22),reader.GetBoolean(23),reader.GetDateTime(24)));                            
                        }
                    }
                }
                return searchUppdrag;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue: " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue: " + ex.Message);
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        #endregion

        #region Models
        public static int addModel(Modell model,string productNbr,string reservdel,string motorNbr)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Models (name,brand,sort,productNbrs,reservdelar,motorNbr) values (@name,@brand,@sort,@productNbrs,@reservdelar,@motorNbr)";
                    command.Parameters.Add("@name", SqlDbType.NVarChar);
                    command.Parameters["@name"].Value = model.name;
                    command.Parameters.Add("@brand", SqlDbType.NVarChar);
                    command.Parameters["@brand"].Value = model.brand;
                    command.Parameters.Add("@sort", SqlDbType.NVarChar);
                    command.Parameters["@sort"].Value = model.sort;
                    command.Parameters.Add("@productNbrs", SqlDbType.NVarChar);
                    command.Parameters["@productNbrs"].Value = productNbr;
                    command.Parameters.Add("@reservdelar", SqlDbType.NVarChar);
                    command.Parameters["@reservdelar"].Value = reservdel;
                    command.Parameters.Add("@motorNbr", SqlDbType.NVarChar);
                    command.Parameters["@motorNbr"].Value = motorNbr;
                    databas.Open();
                    command.ExecuteNonQuery();
                    command.CommandText = @"SELECT Id FROM Models WHERE name = @name AND brand = @brand AND sort = @sort AND productNbrs = @productNbrs AND reservdelar = @reservdelar AND motorNbr = @motorNbr";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32(0);

                        }
                    }
                }
                return 0;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(AddModel): " + ex.Message);                
                return 0;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddModel): " + ex.Message);               
                return 0;
            }
            
        }
        public static void updateModel(Modell model, string productNbr, string reservdel, string motorNbr)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Models SET name=@name, brand = @brand, sort = @sort , productNbrs = @productNbrs , reservdelar = @reservdelar,motorNbr = @motorNbr WHERE ID = @ID";
                    command.Parameters.Add("@name", SqlDbType.NVarChar);
                    command.Parameters["@name"].Value = model.name;
                    command.Parameters.Add("@brand", SqlDbType.NVarChar);
                    command.Parameters["@brand"].Value = model.brand;
                    command.Parameters.Add("@sort", SqlDbType.NVarChar);
                    command.Parameters["@sort"].Value = model.sort;
                    command.Parameters.Add("@ID", SqlDbType.Int);
                    command.Parameters["@ID"].Value = model.ID;
                    command.Parameters.Add("@productNbrs", SqlDbType.NVarChar);
                    command.Parameters["@productNbrs"].Value = productNbr;
                    command.Parameters.Add("@reservdelar", SqlDbType.NVarChar);
                    command.Parameters["@reservdelar"].Value = reservdel;
                    command.Parameters.Add("@motorNbr", SqlDbType.NVarChar);
                    command.Parameters["@motorNbr"].Value = motorNbr;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(UpdateModell): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(UpdateModell): " + ex.Message);
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }        
        }
        public static Modell searchModel(string name, string brand, string sort)
        {
            try
            {
                Modell result = null;
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Models WHERE name LIKE @name AND brand LIKE @brand AND sort LIKE @sort";
                    command.Parameters.Add("@name", SqlDbType.NVarChar);
                    command.Parameters["@name"].Value = "%"+CleanInput(name)+"%";
                    command.Parameters.Add("@brand", SqlDbType.NVarChar);
                    command.Parameters["@brand"].Value = "%"+CleanInput(brand)+"%";
                    command.Parameters.Add("@sort", SqlDbType.NVarChar);
                    command.Parameters["@sort"].Value = "%"+CleanInput(sort)+"%";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {                            
                            result = new Modell(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                        }
                    }
                }               
                return result;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(SearchModel): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(SearchModel): " + ex.Message);
                return null;
            }           
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static void removeModel(Modell delete)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"DELETE FROM Models WHERE Id = @Id";
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = delete.ID;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(RemoveModel) " + ex.Message);

            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(RemoveModel) " + ex.Message);

            }           
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Modell> getModels(string brand, string sort)
        {
            try
            {
                List<Modell> models = new List<Modell>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Models WHERE brand = @brand AND sort = @sort";
                    command.Parameters.Add("@brand", SqlDbType.NVarChar);
                    command.Parameters["@brand"].Value = CleanInput(brand);
                    command.Parameters.Add("@sort", SqlDbType.NVarChar);
                    command.Parameters["@sort"].Value = CleanInput(sort);
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            models.Add(new Modell(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
                        }
                    }
                }
                return models;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(GetModels) " + ex.Message);
                 
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(GetModels) " + ex.Message);
                 
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        #endregion        

        #region Reservdelar
        public static void addReservdel(Reservdel reservdel)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {                     
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Reservdelar (artikelNr,barcode,name,orderDel) values (@artikelNr,@barcode,@name,@orderDel)";

                    command.Parameters.Add("@artikelNr", SqlDbType.NVarChar);
                    command.Parameters["@artikelNr"].Value = reservdel.artikelNr;

                    command.Parameters.Add("@barcode", SqlDbType.NVarChar);
                    if (String.IsNullOrWhiteSpace(reservdel.barcode))
                        command.Parameters["@barcode"].Value = DBNull.Value;
                    else
                        command.Parameters["@barcode"].Value = reservdel.barcode;

                    command.Parameters.Add("@name", SqlDbType.NVarChar);
                    if (String.IsNullOrWhiteSpace(reservdel.name))
                        command.Parameters["@name"].Value = DBNull.Value;
                    else
                        command.Parameters["@name"].Value = reservdel.name;

                    command.Parameters.Add("@orderDel", SqlDbType.Bit);
                    command.Parameters["@orderDel"].Value = reservdel.orderDel;

                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(AddModel): " + ex.Message);
                 
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddModel): " + ex.Message);
                 
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void updateReservdel(Reservdel reservdel)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {                  
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Reservdelar SET artikelNr = @artikelNr , barcode = @barcode , name = @name,orderDel = @orderDel WHERE ID = @ID ";
                    command.Parameters.Add("@artikelNr", SqlDbType.NVarChar);
                    command.Parameters["@artikelNr"].Value = reservdel.artikelNr;
                    command.Parameters.Add("@barcode", SqlDbType.NVarChar);
                    command.Parameters["@barcode"].Value = reservdel.barcode;
                    command.Parameters.Add("@name", SqlDbType.NVarChar);
                    command.Parameters["@name"].Value = reservdel.name;
                    command.Parameters.Add("@orderDel", SqlDbType.Bit);
                    command.Parameters["@orderDel"].Value = reservdel.orderDel;
                    command.Parameters.Add("@ID", SqlDbType.BigInt);
                    command.Parameters["@ID"].Value = reservdel.ID;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(updateReservdel): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(UpdateReservdel): " + ex.Message);
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void removeReservdel(Reservdel reservdel)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"DELETE from Reservdelar WHERE ID = @ID";
                    command.Parameters.Add("@ID", SqlDbType.Int);
                    command.Parameters["@ID"].Value = reservdel.ID;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(removeReservdel): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(removeReservdel): " + ex.Message);
            }
            
            finally // don't forget to close your connection when exception occurs.
            {

            }
        }
        public static List<Reservdel> searchReservdel(string text)
        {
            try
            {
                List<Reservdel> reservdelar = new List<Reservdel>();
                using (var databas = new SqlConnection(ConnectionString))
                {                    
                    
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Reservdelar WHERE name LIKE @text OR artikelNr LIKE  @text OR barcode LIKE @text";
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = "%" + CleanInput(text) + "%";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string barcode = "";
                            if (!reader.IsDBNull(2))
                                barcode = reader.GetString(2);
                            string name = "";
                            if (!reader.IsDBNull(3))
                                name = reader.GetString(3);
                            bool order = true;
                            if (!reader.IsDBNull(4))
                                order = reader.GetBoolean(4);

                            reservdelar.Add(new Reservdel(reader.GetInt32(0), reader.GetString(1), barcode, name, order));
                        }
                    }
                }
                return reservdelar;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(AddModel): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddModel): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static List<Reservdel> getReservdelar()
        {
            try
            {
                List<Reservdel> reservdelar = new List<Reservdel>();
                using (var databas = new SqlConnection(ConnectionString))
                {                    
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Reservdelar";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string barcode = "";
                            if (!reader.IsDBNull(2))
                                barcode = reader.GetString(2);
                            string name = "";
                            if (!reader.IsDBNull(3))
                                name = reader.GetString(3);
                            bool order = true;
                            if (!reader.IsDBNull(4))
                                order = reader.GetBoolean(4);
                            reservdelar.Add(new Reservdel(reader.GetInt32(0), reader.GetString(1), barcode, name, order));
                        }
                    }
                }
                
                return reservdelar;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(AddModel): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddModel): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static List<Reservdel> allOrder()
        {
            try
            {
                List<Reservdel> reservdelar = new List<Reservdel>();
                using (var databas = new SqlConnection(ConnectionString))
                {                     
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Reservdelar WHERE orderDel = 'true'";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string barcode = "";
                            if (!reader.IsDBNull(2))
                                barcode = reader.GetString(2);
                            string name = "";
                            if (!reader.IsDBNull(3))
                                name = reader.GetString(3);
                            bool order = true;
                            if (!reader.IsDBNull(4))
                                order = reader.GetBoolean(4);

                            reservdelar.Add(new Reservdel(reader.GetInt32(0), reader.GetString(1), barcode, name, order));
                        }
                    }
                }
                return reservdelar;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(AddModel): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddModel): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static Reservdel searchReservdel(int ID)
        {
            try
            {                
                Reservdel reservdelen = null;
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Reservdelar WHERE ID = @ID";
                    command.Parameters.Add("@ID", SqlDbType.NVarChar);
                    command.Parameters["@ID"].Value = ID.ToString();
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string barcode = "";
                            if (!reader.IsDBNull(2))
                                barcode = reader.GetString(2);
                            string name = "";
                            if (!reader.IsDBNull(3))
                                name = reader.GetString(3);
                            bool order = true;
                            if (!reader.IsDBNull(4))
                                order = reader.GetBoolean(4);
                            reservdelen = new Reservdel(reader.GetInt32(0), reader.GetString(1), barcode, name, order);
                        }
                    }
                }
                return reservdelen;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(AddModel): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddModel): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        #endregion

        #region Hämtning
        public static int addHamtning(Hamtning hamtning)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Hamtning (customerID,brand,type,modell,pincode,kommentar,inlagd,hamtning,maskin,hamtad,vinterforvaring,postnr,bestamd) values (@customerID,@brand,@type,@modell,@pincode,@kommentar,@inlagd,@hamtning,@maskin,@hamtad,@vinterforvaring,@postnr,@bestamd)";

                    command.Parameters.Add("@customerID", SqlDbType.NVarChar);
                    command.Parameters["@customerID"].Value = hamtning.customer.customerID;
                    command.Parameters.Add("@brand", SqlDbType.NVarChar);
                    command.Parameters["@brand"].Value = hamtning.brand;
                    command.Parameters.Add("@type", SqlDbType.NVarChar);
                    command.Parameters["@type"].Value = hamtning.type;
                    command.Parameters.Add("@modell", SqlDbType.NVarChar);
                    command.Parameters["@modell"].Value = hamtning.modell;                    
                    command.Parameters.Add("@pincode", SqlDbType.NVarChar);
                    command.Parameters["@pincode"].Value = hamtning.getPinCode(true);
                    command.Parameters.Add("@kommentar", SqlDbType.NVarChar);
                    command.Parameters["@kommentar"].Value = hamtning.kommentar;
                    command.Parameters.Add("@inlagd", SqlDbType.DateTime);
                    command.Parameters["@inlagd"].Value = hamtning.inlagd;
                    command.Parameters.Add("@hamtning", SqlDbType.DateTime);
                    command.Parameters["@hamtning"].Value = hamtning.hamtning;
                    command.Parameters.Add("@maskin", SqlDbType.NVarChar);
                    string maskinID = (hamtning.maskin != null) ? hamtning.maskin.maskinID : "0";
                    command.Parameters["@maskin"].Value = maskinID;
                    command.Parameters.Add("@hamtad", SqlDbType.Bit);
                    command.Parameters["@hamtad"].Value = hamtning.hamtad;
                    command.Parameters.Add("@vinterforvaring", SqlDbType.Bit);
                    command.Parameters["@vinterforvaring"].Value = hamtning.vinterforvaring;
                    command.Parameters.Add("@postnr", SqlDbType.NVarChar);
                    command.Parameters["@postnr"].Value = hamtning.PostnummerString;                    
                    command.Parameters.Add("@bestamd", SqlDbType.Bit);
                    command.Parameters["@bestamd"].Value = hamtning.bestamd;                    
                    databas.Open();
                    command.ExecuteNonQuery();
                    command.CommandText = @"SELECT Id FROM Hamtning WHERE customerID = @customerID AND brand = @brand AND type = @type AND modell = @modell AND pincode = @pincode AND kommentar = @kommentar AND inlagd = @inlagd AND hamtning = @hamtning AND maskin = @maskin AND hamtad = @hamtad AND vinterforvaring = @vinterforvaring";
                    using( SqlDataReader reader =  command.ExecuteReader())
                    {                        
                        while(reader.Read())
                        {                            
                            return reader.GetInt32(0);

                        }
                    }
                    
                }
                return 0;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(AddHamtning): " + ex.Message);
                 
                return 0;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddHamtning): " + ex.Message);
                 
                return 0;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void updateHamtning(Hamtning hamtning)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Hamtning SET customerID = @customerID,brand = @brand,type = @type,modell = @modell,pincode = @pincode,kommentar = @kommentar,inlagd = @inlagd,hamtning = @hamtning,maskin = @maskin,hamtad = @hamtad,vinterforvaring = @vinterforvaring ,postnr = @postnr, bestamd = @bestamd WHERE ID = @ID ";
                    command.Parameters.Add("@ID", SqlDbType.Int);
                    command.Parameters["@ID"].Value = hamtning.ID;
                    command.Parameters.Add("@customerID", SqlDbType.NVarChar);
                    command.Parameters["@customerID"].Value = hamtning.customer.customerID;
                    command.Parameters.Add("@brand", SqlDbType.NVarChar);
                    command.Parameters["@brand"].Value = hamtning.brand;
                    command.Parameters.Add("@type", SqlDbType.NVarChar);
                    command.Parameters["@type"].Value = hamtning.type;
                    command.Parameters.Add("@modell", SqlDbType.NVarChar);
                    command.Parameters["@modell"].Value = hamtning.modell;
                    command.Parameters.Add("@pincode", SqlDbType.NVarChar);
                    command.Parameters["@pincode"].Value = hamtning.getPinCode(true);
                    command.Parameters.Add("@kommentar", SqlDbType.NVarChar);
                    command.Parameters["@kommentar"].Value = hamtning.kommentar;
                    command.Parameters.Add("@inlagd", SqlDbType.DateTime);
                    command.Parameters["@inlagd"].Value = hamtning.inlagd;
                    command.Parameters.Add("@hamtning", SqlDbType.DateTime);
                    command.Parameters["@hamtning"].Value = hamtning.hamtning;                    
                    command.Parameters.Add("@maskin", SqlDbType.NVarChar);
                    if (hamtning.maskin != null)
                        command.Parameters["@maskin"].Value = hamtning.maskin.maskinID;
                    else
                        command.Parameters["@maskin"].Value = "99999";
                    command.Parameters.Add("@hamtad", SqlDbType.Bit);
                    command.Parameters["@hamtad"].Value = hamtning.hamtad;
                    command.Parameters.Add("@vinterforvaring", SqlDbType.Bit);
                    command.Parameters["@vinterforvaring"].Value = hamtning.vinterforvaring;
                    command.Parameters.Add("@postnr", SqlDbType.NVarChar);
                    command.Parameters["@postnr"].Value = hamtning.PostnummerString;
                    command.Parameters.Add("@bestamd", SqlDbType.Bit);
                    command.Parameters["@bestamd"].Value = hamtning.bestamd;

                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(updateHamtning): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(updateHamtning): " + ex.Message);
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }        
        public static void removeHamtning(Hamtning hamtning)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"DELETE from Hamtning WHERE Id = @Id";
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = hamtning.ID;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(removeHamtning): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(removeHamtning): " + ex.Message);
            }
            
            finally // don't forget to close your connection when exception occurs.
            {

            }
        }
        public static List<Hamtning> getHamtning(bool ejBestamda, bool ejHamtade, bool hamtade, bool alla)
        {
            try
            {
                List<Hamtning> hamtningar = new List<Hamtning>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    if (alla)
                        command.CommandText = @"SELECT * FROM Hamtning";
                    else if (hamtade)
                        command.CommandText = @"SELECT * FROM Hamtning WHERE hamtad = 'true'";
                    else if (ejHamtade)
                        command.CommandText = @"SELECT * FROM Hamtning WHERE hamtad = 'false' AND bestamd = 'true'";
                    else if (ejBestamda)
                        command.CommandText = @"SELECT * FROM Hamtning WHERE bestamd = 'false'";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {                           
                            hamtningar.Add(new Hamtning(reader.GetInt32(0), reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetDateTime(7),reader.GetDateTime(8),reader.GetString(9),reader.GetBoolean(10),reader.GetBoolean(11),reader.GetBoolean(13)));
                        }
                    }
                }

                return hamtningar;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(getHamtning): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddModel): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static List<Hamtning> getAktuellHamtning(bool aktuell)
        {
            try
            {
                List<Hamtning> hamtningar = new List<Hamtning>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    if(aktuell)
                        command.CommandText = @"SELECT * FROM Hamtning WHERE bestamd = 'false'";
                    else
                        command.CommandText = @"SELECT * FROM Hamtning";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hamtningar.Add(new Hamtning(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetDateTime(8), reader.GetString(9), reader.GetBoolean(10), reader.GetBoolean(11), reader.GetBoolean(13)));
                        }
                    }
                }
                return hamtningar;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(getAktuellHamtning): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(getAktuellHamtning): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static List<Hamtning> getHamtningForDate(DateTime date)
        {
            try
            {
                List<Hamtning> hamtningar = new List<Hamtning>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Hamtning WHERE hamtning = @date AND bestamd = 'true'";
                    command.Parameters.Add("@date", SqlDbType.DateTime);
                    command.Parameters["@date"].Value = date;
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hamtningar.Add(new Hamtning(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetDateTime(8), reader.GetString(9), reader.GetBoolean(10), reader.GetBoolean(11), reader.GetBoolean(13)));
                        }
                    }
                }
                return hamtningar;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(getAktuellHamtning): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(getAktuellHamtning): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static List<Hamtning> getHamtningPostnummer(string postnummer)
        {
            try
            {
                List<Hamtning> hamtningar = new List<Hamtning>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Hamtning WHERE postnr = @postnr";
                    command.Parameters.Add("@postnr", SqlDbType.NVarChar);
                    command.Parameters["@postnr"].Value = postnummer;
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hamtningar.Add(new Hamtning(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetDateTime(8), reader.GetString(9), reader.GetBoolean(10), reader.GetBoolean(11), reader.GetBoolean(13)));
                        }
                    }
                }
                return hamtningar;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(getAktuellHamtning): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(getAktuellHamtning): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static List<Hamtning> getHamtningCustomer(string customerID)
        {
            try
            {
                List<Hamtning> hamtningar = new List<Hamtning>();
                using (var databas = new SqlConnection(ConnectionString))
                {
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Hamtning WHERE customerID = @customerID";
                    command.Parameters.Add("@customerID", SqlDbType.NVarChar);
                    command.Parameters["@customerID"].Value = customerID;
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hamtningar.Add(new Hamtning(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetDateTime(8), reader.GetString(9), reader.GetBoolean(10), reader.GetBoolean(11), reader.GetBoolean(13)));
                        }
                    }
                }
                return hamtningar;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(getAktuellHamtning): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(getAktuellHamtning): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {

            }
        }
        public static Hamtning searchHamtning(int ID)
        {
            try
            {                
                Hamtning hamtning = null;
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Hamtning WHERE ID = @ID";
                    command.Parameters.Add("@ID", SqlDbType.Int);
                    command.Parameters["@ID"].Value = ID;
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hamtning = new Hamtning(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7), reader.GetDateTime(8), reader.GetString(9), reader.GetBoolean(10), reader.GetBoolean(11), reader.GetBoolean(13));
                        }
                    }
                }
                return hamtning;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(SearchHamtning): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(SearchHamtning): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static Hamtning searchHamtning(string ID)
        {
            try
            {
                Hamtning hamtning = null;
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Hamtning WHERE ID = @ID";
                    command.Parameters.Add("@ID", SqlDbType.Int);
                    command.Parameters["@ID"].Value = ID;
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hamtning = new Hamtning(reader.GetInt32(0), reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetDateTime(7),reader.GetDateTime(8),reader.GetString(9),reader.GetBoolean(10),reader.GetBoolean(11),reader.GetBoolean(13));
                        }
                    }
                }
                return hamtning;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(SearchHamtning): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(SearchHamtning): " + ex.Message);
                return null;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {

            }
        }
        public static bool checkAktuellHamtning(string maskinID)
        {
            maskinID = CleanInput(maskinID);
            try
            {
                Hamtning result = null;
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Hamtning WHERE maskin = @text AND hamtad = 'false'";
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = maskinID;
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = new Hamtning(reader.GetInt32(0), reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetDateTime(7),reader.GetDateTime(8),reader.GetString(9),reader.GetBoolean(10),reader.GetBoolean(11),reader.GetBoolean(13));
                        }
                    }
                }
                return result != null;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(checkAktuellHamtning): " + ex.Message);
                return false;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(checkAktuellHamtning): " + ex.Message);
                return false;
            }           
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        #endregion

        #region Vinterförvaring
        public static int addVinterforvaring(Vinterforvaring vinter)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Vinterforvaring (datum,done,postnummer) values (@datum,@done,@postnummer)";
                    command.Parameters.Add("@datum", SqlDbType.DateTime);
                    command.Parameters["@datum"].Value = vinter.datum;                    
                    command.Parameters.Add("@done", SqlDbType.Bit);
                    command.Parameters["@done"].Value = vinter.done;
                    command.Parameters.Add("@postnummer", SqlDbType.NVarChar);
                    command.Parameters["@postnummer"].Value = vinter.SavePostnummer();
                    databas.Open();
                    command.ExecuteNonQuery();
                    command.CommandText = @"SELECT Id FROM Vinterforvaring WHERE datum = @datum AND done = @done AND postnummer = @postnummer";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32(0);

                        }
                    }
                }
                return 0;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(addVinterforvaring): " + ex.Message);
                 
                return 0;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(addVinterforvaring): " + ex.Message);
                 
                return 0;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void updateVinterforvaring(Vinterforvaring vinterforvaring)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Vinterforvaring SET datum = @datum, done = @done, postnummer = @postnummer WHERE Id = @Id";
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = vinterforvaring.ID;
                    command.Parameters.Add("@datum", SqlDbType.DateTime);
                    command.Parameters["@datum"].Value = vinterforvaring.datum;                    
                    command.Parameters.Add("@done", SqlDbType.Bit);
                    command.Parameters["@done"].Value = vinterforvaring.done;
                    command.Parameters.Add("@postnummer", SqlDbType.NVarChar);
                    command.Parameters["@postnummer"].Value = vinterforvaring.SavePostnummer();
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(UpdateVinteforvaring): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(UpdateVinteforvaring): " + ex.Message);
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }        
        public static void removeVinterforvaring(Vinterforvaring delete)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {                  
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"DELETE FROM Vinterforvaring WHERE Id = @Id";
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = delete.ID;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(RemoveModel) " + ex.Message);

            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(RemoveModel) " + ex.Message);

            }           
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Vinterforvaring> getActiveVinterforvaring()
        {
            try
            {
                List<Vinterforvaring> vinterforvaring = new List<Vinterforvaring>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Vinterforvaring";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vinterforvaring.Add(new Vinterforvaring(reader.GetInt32(0), reader.GetDateTime(1),reader.GetBoolean(2),reader.GetString(4)));
                        }
                    }
                }
                return vinterforvaring;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(getActiveVinterforvaring) " + ex.Message);
                 
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(getActiveVinterforvaring) " + ex.Message);
                 
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static Vinterforvaring getVinterforvaringDate(DateTime datum)
        {
            try
            {
                Vinterforvaring vinterforvaring = null;
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Vinterforvaring WHERE datum = @datum";
                    command.Parameters.Add("@datum", SqlDbType.DateTime);
                    TimeSpan ts = new TimeSpan(datum.Hour, datum.Minute, datum.Second);
                    command.Parameters["@datum"].Value = datum-ts;
                    databas.Open();                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {                        
                        while (reader.Read())
                        {                            
                            vinterforvaring = new Vinterforvaring(reader.GetInt32(0), reader.GetDateTime(1),reader.GetBoolean(2),reader.GetString(4));                            
                        }
                    }
                }
                return vinterforvaring;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(getActiveVinterforvaring) " + ex.Message);
                 
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(getActiveVinterforvaring) " + ex.Message);
                 
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Vinterforvaring> getVinterforvaringPostnr(string postnummer)
        {
            try
            {
                List<Vinterforvaring> vinterforvaring = new List<Vinterforvaring>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Vinterforvaring WHERE postnummer LIKE @postnummer";
                    command.Parameters.Add("@postnummer", SqlDbType.NVarChar);                    
                    command.Parameters["@postnummer"].Value = "%"+postnummer+"%";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            vinterforvaring.Add(new Vinterforvaring(reader.GetInt32(0), reader.GetDateTime(1), reader.GetBoolean(2),reader.GetString(4)));
                        }
                    }
                }
                return vinterforvaring;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(getActiveVinterforvaring) " + ex.Message);

                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(getActiveVinterforvaring) " + ex.Message);

                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {


            }
        }
        #endregion

        #region Postnummer
        public static int addPostnummer(Postnummer postnummer)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Postnummer (postnr,ort) values (@postnr,@ort)";
                    command.Parameters.Add("@postnr", SqlDbType.NVarChar);
                    command.Parameters["@postnr"].Value = postnummer.postnummer;
                    command.Parameters.Add("@ort", SqlDbType.NVarChar);
                    command.Parameters["@ort"].Value = postnummer.ort;                     
                    databas.Open();
                    command.ExecuteNonQuery();
                    command.CommandText = @"SELECT Id FROM Postnummer WHERE postnr = @postnr AND ort = @ort";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32(0);

                        }
                    }
                }
                return 0;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(addVinterforvaring): " + ex.Message);
                 
                return 0;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(addVinterforvaring): " + ex.Message);
                 
                return 0;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void updatePostnummer(Postnummer postnummer)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Postnummer SET postnr = @postnr , ort = @ort WHERE Id = @Id";
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = postnummer.ID;
                    command.Parameters.Add("@postnr", SqlDbType.NVarChar);
                    command.Parameters["@postnr"].Value = postnummer.postnummer;
                    command.Parameters.Add("@ort", SqlDbType.NVarChar);
                    command.Parameters["@ort"].Value = postnummer.ort;    
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(UpdateVinteforvaring): " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(UpdateVinteforvaring): " + ex.Message);
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void removePostnummer(Postnummer delete)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"DELETE FROM Postnummer WHERE Id = @Id";
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = delete.ID;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(RemoveModel) " + ex.Message);

            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(RemoveModel) " + ex.Message);

            }           
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }        
        public static Postnummer getPostnummer(string postnummer)
        {
            try
            {
                Postnummer ort = null;
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Postnummer WHERE postnr = @postnr";
                    command.Parameters.Add("@postnr", SqlDbType.NVarChar);
                    command.Parameters["@postnr"].Value = postnummer;
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ort = new Postnummer(reader.GetInt32(0),reader.GetString(1),reader.GetString(2));
                        }
                    }
                }
                return ort;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(getPostnummerFor) " + ex.Message);
                 
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(getPostnummerFor) " + ex.Message);
                 
                return null;
            }            
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Postnummer> searchPostnummer(string postnummer)
        {
            try
            {
                List<Postnummer> ort = new List<Postnummer>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Postnummer WHERE postnr LIKE @postnr";
                    command.Parameters.Add("@postnr", SqlDbType.NVarChar);
                    command.Parameters["@postnr"].Value = "%" + postnummer + "%";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ort.Add(new Postnummer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                }
                return ort;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(getPostnummerFor) " + ex.Message);
                 
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(getPostnummerFor) " + ex.Message);
                 
                return null;
            }            
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Postnummer> searchOrt(string ort)
        {
            try
            {
                ort = CleanInput(ort);
                List<Postnummer> postnummer = new List<Postnummer>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Postnummer WHERE ort LIKE @ort";
                    command.Parameters.Add("@ort", SqlDbType.NVarChar);
                    command.Parameters["@ort"].Value = "%" + ort + "%";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            postnummer.Add(new Postnummer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                }
                return postnummer;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(getPostnummerFor) " + ex.Message);
                 
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(getPostnummerFor) " + ex.Message);
                 
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Postnummer> getAllPostnummer()
        {
            try
            {                
                List<Postnummer> postnummer = new List<Postnummer>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Postnummer ORDER BY postnr ASC";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            postnummer.Add(new Postnummer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                }
                return postnummer;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(getAllPostnummer) " + ex.Message);

                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(getAllPostnummer) " + ex.Message);

                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {


            }
        }
        public static Postnummer SearchPostnummer(string postnummer,string ort)
        {
            try
            {
                Postnummer check = null;
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Postnummer WHERE postnr LIKE @postnr AND ort LIKE @ort";
                    command.Parameters.Add("@postnr", SqlDbType.NVarChar);
                    command.Parameters["@postnr"].Value = "%"+postnummer+"%";
                    command.Parameters.Add("@ort", SqlDbType.NVarChar);
                    command.Parameters["@ort"].Value = "%"+ort+"%";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            check = new Postnummer(reader.GetInt32(0),reader.GetString(1),reader.GetString(2));
                        }
                    }
                }
                return check;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(getPostnummerFor) " + ex.Message);
                 
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(getPostnummerFor) " + ex.Message);
                 
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
    
        #endregion
        
        #region Listor
        public static int addList(Listor list)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Listor (category,string1) values (@category,@string1)";
                    command.Parameters.Add("@category", SqlDbType.NVarChar);
                    command.Parameters.Add("@string1", SqlDbType.NVarChar);                                                        
                    command.Parameters["@category"].Value = list.category;
                    command.Parameters["@string1"].Value = list.string1; 
                    databas.Open();  
                    command.ExecuteNonQuery();
                    command.CommandText = @"SELECT Id FROM Listor WHERE category = @category AND string1 = @string1";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetInt32(0);

                        }
                    }
                    
                }
                return 9999;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(AddList): " + ex.Message);
                return 9999;                 
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddList): " + ex.Message);
                return 9999;
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void updateList(Listor list)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"UPDATE Listor SET  category = @category, string1 = @string1, int1 = @int1 WHERE Id = @id";
                    command.Parameters.Add("@id", SqlDbType.Int);
                    command.Parameters.Add("@category", SqlDbType.NVarChar);
                    command.Parameters.Add("@string1", SqlDbType.NVarChar);                    
                    command.Parameters["@id"].Value = list.ID;
                    command.Parameters["@category"].Value = list.category;
                    command.Parameters["@string1"].Value = list.string1;                    
                    databas.Open();
                    command.ExecuteNonQuery();

                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(UpdateList): " + ex.Message);
                 
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(UpdateList): " + ex.Message);
                 
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static void removeList(Listor delete)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                {                   
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"DELETE FROM Models WHERE ID = @ID";
                    command.Parameters.Add("@ID", SqlDbType.Int);
                    command.Parameters["@ID"].Value = delete.ID;
                    databas.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(RemoveModel) " + ex.Message);

            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(RemoveModel) " + ex.Message);

            }           
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Listor> getLists(string category)
        {
            try
            {
                List<Listor> lists = new List<Listor>();
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Listor WHERE category LIKE @text";
                    command.Parameters.Add("@text", SqlDbType.NVarChar);
                    command.Parameters["@text"].Value = "%" + CleanInput(category) + "%";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            lists.Add(new Listor(reader.GetInt32(0),reader.GetString(1),reader.GetString(2)));
                        }
                    }
                }
                return lists;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(GetModels) " + ex.Message);
                 
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(GetModels) " + ex.Message);
                 
                return null;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static List<Listor> loadLists(List<Listor> listor)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Listor";
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listor.Add(new Listor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        }
                    }
                }
                 
                return listor;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue:(loadLists) " + ex.Message);
                return listor;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue:(loadLists) " + ex.Message);
                return listor;
            }
             
            //{
            //    MessageBox.Show("Exception Message: " + ex.Message); //Will catch all Exception and write the message of the Exception but I do not recommend this to use.
            //}
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        public static Listor searchList(string category, string string1)
        {
            try
            {
                Listor result = null;
                using (var databas = new SqlConnection(ConnectionString))
                {         
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"SELECT * FROM Listor WHERE category LIKE @category AND string1 LIKE @string1";
                    command.Parameters.Add("@category", SqlDbType.NVarChar);
                    command.Parameters["@category"].Value = "%" + CleanInput(category) + "%";
                    command.Parameters.Add("@string1", SqlDbType.NVarChar);
                    command.Parameters["@string1"].Value = "%" + CleanInput(string1) + "%";                    
                    databas.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            result = new Listor(reader.GetInt32(0), reader.GetString(1),reader.GetString(2));
                        }
                    }
                }
                return result;
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {

                MessageBox.Show("Execute exception issue(SearchList): " + ex.Message);
                return null;
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(SearchList): " + ex.Message);
                return null;
            }           
            finally // don't forget to close your connection when exception occurs.
            {
                 

            }
        }
        public static void saveLists(List<Listor> lista)
        {
            try
            {
                using (var databas = new SqlConnection(ConnectionString))
                { 
                    SqlCommand command = databas.CreateCommand();
                    command.CommandText = @"Insert INTO Listor (category,string1) values (@category,@string1)";
                    command.Parameters.Add("@category", SqlDbType.NVarChar);                    
                    command.Parameters.Add("@string1", SqlDbType.NVarChar);                                        
                    databas.Open();
                    foreach(Listor a in lista)
                    {
                        command.Parameters["@category"].Value = a.category;
                        command.Parameters["@string1"].Value = a.string1;                                                                    
                        command.ExecuteNonQuery();
                    }
                    
                }
            }
            catch (SqlException ex) // This will catch all SQL exceptions
            {
                MessageBox.Show("Execute exception issue(AddModel): " + ex.Message);
                 
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue(AddModel): " + ex.Message);
                 
            }
            
            finally // don't forget to close your connection when exception occurs.
            {
                 
            }
        }
        #endregion
    }
}
