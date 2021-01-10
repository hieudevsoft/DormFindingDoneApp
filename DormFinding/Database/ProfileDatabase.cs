using DormFinding.Models;
using DormFinding.Utils;
using System;
using System.Data;
using System.Windows;


namespace DormFinding.Database
{
    public static class ProfileDatabase
    {
        // Insert email to Table Profile (Not use FaceBook)
        public static void Insert(string email)
        {

            Mydatabase.sql = $"insert into {Helpers.tbUserProfile}({Helpers.colEmailProfile}) values(@Email);";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                MessageBox.Show("Information Error", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        // Insert email to Table Profile (Use FaceBook)
        public static void InsertFaceBook(string email, string name, byte[] image)
        {

            Mydatabase.sql = $"insert into {Helpers.tbUserProfile}({Helpers.colEmailProfile},{Helpers.colNameProfile},{Helpers.colImageProfile}) values(@Email,@Name,@Image);";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@Name", name);
                Mydatabase.cmd.Parameters.AddWithValue("@Image", image);
                Mydatabase.cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                MessageBox.Show("Information Error FaceBook" + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        // Get Information User
        public static UserProfile GetProfile(User user)
        {
            Mydatabase.sql = $"select * from {Helpers.tbUserProfile} where {Helpers.colEmailProfile}=@Email";
            UserProfile userProfile = null;
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", user.Email.Trim());
                Mydatabase.rd = Mydatabase.cmd.ExecuteReader();
                if (Mydatabase.rd.Read())
                {
                    string email = Mydatabase.rd.GetValue(0).ToString();
                    string name = Mydatabase.rd.GetValue(1).ToString();
                    string date = Mydatabase.rd.GetValue(2).ToString();
                    string phone = Mydatabase.rd.GetValue(3).ToString();
                    string address = Mydatabase.rd.GetValue(4).ToString();
                    string hint = Mydatabase.rd.GetValue(5).ToString();
                    byte gender = byte.Parse(Mydatabase.rd.GetValue(6).ToString());
                    byte[] image;
                    if (Mydatabase.rd.GetValue(7).ToString().Equals(""))
                    {

                        userProfile = new UserProfile(email, name, date, phone, address, hint, gender, null);
                    }
                    else
                    {
                        image = (byte[])Mydatabase.rd.GetValue(7);

                        userProfile = new UserProfile(email, name, date, phone, address, hint, gender, image);
                    }

                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading Profile" + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.rd.Close();
                Mydatabase.CloseConnection();
            }

            return userProfile;
        }

        //Update Profile when click Save In Screen My Profile
        public static Boolean UpdateProfileSave(UserProfile user)
        {

            Mydatabase.sql = $"update {Helpers.tbUserProfile} SET {Helpers.colNameProfile}=@Name , {Helpers.colPhoneProfile}=@Phone, {Helpers.colImageProfile}=@Image where {Helpers.colEmailProfile}=@Email;";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Name", user.Name);
                Mydatabase.cmd.Parameters.AddWithValue("@Email", user.Email);
                Mydatabase.cmd.Parameters.AddWithValue("@Phone", user.Phone);
                Mydatabase.cmd.Parameters.AddWithValue("@Image", user.Avatar);
                Mydatabase.cmd.ExecuteScalar();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Update User Profile " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Update Profile when click Update In Screen My Profile
        public static Boolean UpdateProfileSubmit(UserProfile user)
        {

            Mydatabase.sql = $"update {Helpers.tbUserProfile} SET {Helpers.colAdressProfile}=@Address , {Helpers.colHintProfile}=@Hint, {Helpers.colDateProfile} = @Date" +
                $", {Helpers.colGenderProfile} = @Gender where {Helpers.colEmailProfile}=@Email;";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Address", user.Address);
                Mydatabase.cmd.Parameters.AddWithValue("@Hint", user.Hint);
                Mydatabase.cmd.Parameters.AddWithValue("@Date", user.Date);
                Mydatabase.cmd.Parameters.AddWithValue("@Gender", user.Gender);
                Mydatabase.cmd.Parameters.AddWithValue("@Email", user.Email);
                Mydatabase.cmd.ExecuteScalar();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Update User Profile " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }
    }
}
