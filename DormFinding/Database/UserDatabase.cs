using DormFinding.Models;
using DormFinding.Utils;
using System;
using System.Data;
using System.Windows;

namespace DormFinding.Database
{
    public static class UserDatabase
    {
        // Insert User to Database
        public static Boolean Insert(string email, string password, byte isActive)
        {
            Mydatabase.sql = $"insert into {Helpers.tbUser} values(@Email,@Password,@IsRemember);";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@Password", password);
                Mydatabase.cmd.Parameters.AddWithValue("@IsRemember", isActive);
                Mydatabase.cmd.ExecuteScalar();

                return true;
            }
            catch (Exception e)
            {

                return false;

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        // Check Account exists in Database
        public static Boolean CheckAccount(string email, string password)
        {

            Mydatabase.sql = $"select count(*) from {Helpers.tbUser} where {Helpers.colEmail}=@Email and {Helpers.colPassword}=@password;";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@Password", password);
                int count = Convert.ToInt32(Mydatabase.cmd.ExecuteScalar().ToString());

                if (count != 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Email or Password not correct", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error connecting...", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                Mydatabase.CloseConnection();
            }



        }

        // Update user
        public static Boolean Update(User user, string email)
        {

            Mydatabase.sql = $"update {Helpers.tbUser} SET {Helpers.colRemember}=@IsRemember , {Helpers.colPassword}=@Password where {Helpers.colEmail}=@Email;";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@IsRemember", user.isRemember);
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@Password", user.Password);
                Mydatabase.cmd.ExecuteScalar();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Change Remember " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Check Account Remember In App
        public static User CheckAccountAreadyInApp()
        {
            Mydatabase.sql = $"select * from {Helpers.tbUser} where {Helpers.colRemember}=@value;";
            User user = null;
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@value", 1);
                Mydatabase.rd = Mydatabase.cmd.ExecuteReader();
                while (Mydatabase.rd.Read())
                {
                    string email = Mydatabase.rd.GetValue(0).ToString();
                    string password = Mydatabase.rd.GetValue(1).ToString();
                    user = new User(email, password, 1);
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading remember" + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.rd.Close();
                Mydatabase.CloseConnection();
            }
            return user;
        }
    }
}
