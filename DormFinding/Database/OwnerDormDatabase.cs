using DormFinding.Models;
using DormFinding.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DormFinding.Database
{
    public static class OwnerDormDatabase
    {
        //Insert Dorm By Email and Id Dorm
        public static void Insert(string email, int idDorm)
        {

            Mydatabase.sql = $"insert into {Helpers.tbDormOwner}({Helpers.colEmailOwnerDorm},{Helpers.colIdOwnerDorm}) values(@Email,@Id);";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);
                Mydatabase.cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error Insert to table owner dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Delete by Id Dorm
        public static void DeleteByDormId(int id)
        {

            Mydatabase.sql = $"delete from {Helpers.tbDormOwner} where {Helpers.colIdOwnerDorm} = @Id";

            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);

                Mydatabase.cmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                MessageBox.Show("Delete tbOwnerDorm Error " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Get Owner of Dorm
        public static UserProfile GetOwnerProfileOfDorm(int idDorm)
        {
            UserProfile owner = new UserProfile();

            Mydatabase.sql = $"select {Helpers.colImageProfile},{Helpers.colNameProfile},{Helpers.colPhoneProfile},{Helpers.colEmailProfile}," +
                $"{Helpers.colAdressProfile}, {Helpers.colGenderProfile} " +
                $"from {Helpers.tbUserProfile},{Helpers.tbDormOwner} " +
                $"where {Helpers.colIdOwnerDorm} = @Id and {Helpers.colEmailOwnerDorm} = {Helpers.colEmailProfile};";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);
                Mydatabase.rd = Mydatabase.cmd.ExecuteReader();
                while (Mydatabase.rd.Read())
                {
                    string email = Mydatabase.rd.GetValue(3).ToString();
                    string name = Mydatabase.rd.GetValue(1).ToString();
                    string phone = Mydatabase.rd.GetValue(2).ToString();
                    string address = Mydatabase.rd.GetValue(4).ToString();
                    byte gender = byte.Parse(Mydatabase.rd.GetValue(5).ToString());
                    byte[] image;
                    try
                    {
                        
                        image = (byte[])Mydatabase.rd.GetValue(0);
                       
                    }
                    catch(Exception e)
                    {
                        image = Helpers.ConvertImageToBinary(new BitmapImage(new Uri("../../images/blank_account.png", UriKind.RelativeOrAbsolute)));
                    }
                   
                    owner = new UserProfile(email, name, "", phone, address, "", gender, image);


                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error GetOwnerProfileWithDorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.rd.Close();
                Mydatabase.CloseConnection();
            }

            return owner;
        }

        //Get All Dorm By Email Owner
        public static List<Dorm> GetAllListDormOwner(string email)
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm},{Helpers.tbDormOwner} where {Helpers.colIdDorm} = {Helpers.colIdOwnerDorm} and {Helpers.colEmailOwnerDorm} = @Email";
            List<Dorm> listDorm = new List<Dorm>();

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.rd = Mydatabase.cmd.ExecuteReader();
                while (Mydatabase.rd.Read())
                {
                    Dorm dorm = new Dorm();
                    int id = Mydatabase.rd.GetInt32(0);
                    string owner = Mydatabase.rd.GetString(1);
                    string address = Mydatabase.rd.GetString(2);
                    string description = Mydatabase.rd.GetString(3);
                    double price = Mydatabase.rd.GetDouble(4);
                    double sale = Mydatabase.rd.GetDouble(5);

                    byte[] image;
                    if (Mydatabase.rd.GetValue(6).ToString().Equals(""))
                    {
                        dorm.Image = new System.Windows.Media.Imaging.BitmapImage(new Uri($"../../images/icon_app.ico", UriKind.RelativeOrAbsolute));

                    }
                    else
                    {
                        image = (byte[])Mydatabase.rd.GetValue(6);

                        dorm.Image = Helpers.ConvertByteToImageBitmap(image);
                    }

                    int count = Mydatabase.rd.GetInt32(7);
                    int countLike = Mydatabase.rd.GetInt32(8);

                    byte wifi = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(9));

                    byte parking = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(10));
                    byte television = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(11));
                    byte bathroom = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(12));
                    byte aircon = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(13));
                    byte waterheater = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(14));
                    int quality = Mydatabase.rd.GetInt16(15);
                    double size = Mydatabase.rd.GetDouble(16);

                    dorm.Id = id;
                    dorm.Owner = owner;
                    dorm.Address = address;
                    dorm.Description = description;
                    dorm.Price = price;
                    dorm.Sale = sale;
                    dorm.Count = count;
                    dorm.CountLike = countLike;
                    dorm.IsWifi = Helpers.ConvertByteToVisibility(wifi);
                    dorm.IsParking = Helpers.ConvertByteToVisibility(parking);
                    dorm.IsTelevision = Helpers.ConvertByteToVisibility(television);
                    dorm.IsBathroom = Helpers.ConvertByteToVisibility(bathroom);
                    dorm.IsAirCondiditioner = Helpers.ConvertByteToVisibility(aircon);
                    dorm.IsWaterHeater = Helpers.ConvertByteToVisibility(waterheater);
                    dorm.Quality = quality;
                    dorm.Size = size;

                    listDorm.Add(dorm);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading List Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.rd.Close();
                Mydatabase.CloseConnection();
            }

            return listDorm;
        }

        //Update State Dorm
        public static bool Update(string email,int id, int state)
        {
            Mydatabase.sql = $"update {Helpers.tbBookDorm} set {Helpers.colStateBookDorm} = @State where {Helpers.colEmailOwnerBookDorm} = @Email and {Helpers.colIdDormBookDorm} = @Id";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@State", state);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);
                Mydatabase.cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Reset Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }
    }
}
