using DormFinding.Models;
using DormFinding.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DormFinding.Database
{
    public static class LikeDatabase
    {
        //Insert User To Table Like Dorm
        public static Boolean Insert(string email, int idDorm, byte like)
        {

            Mydatabase.sql = $"insert into {Helpers.tbOwnerLikeDorm}({Helpers.colEmailOwnerLikeDorm},{Helpers.colIdDormOwnerLikeDorm},{Helpers.colLikeOwnerLikeDorm}) values(@Email,@Id,@Like);";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);
                Mydatabase.cmd.Parameters.AddWithValue("@Like", like);
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

        //Delete Item In Table Like Dorm
        public static void DeleteById(int id)
        {

            Mydatabase.sql = $"delete from {Helpers.tbOwnerLikeDorm} where {Helpers.colIdDormOwnerLikeDorm} = @Id";

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
                MessageBox.Show("Delete tbOwner Like Dorm Error " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Update
        public static void Update(string email, int id, byte like)
        {
            Mydatabase.sql = $"update {Helpers.tbOwnerLikeDorm} SET {Helpers.colLikeOwnerLikeDorm}=@Like where {Helpers.colEmailOwnerLikeDorm}=@Email and {Helpers.colIdDormOwnerLikeDorm} = @Id;";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Like", like);
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);
                Mydatabase.cmd.ExecuteScalar();


            }
            catch (Exception e)
            {
                MessageBox.Show("Error Update Owner Like Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Get Like Or DisLike
        public static Boolean GetStateLike(string email, int id)
        {
            Mydatabase.sql = $"select {Helpers.colLikeOwnerLikeDorm} from {Helpers.tbOwnerLikeDorm} where {Helpers.colEmailOwnerLikeDorm}=@Email and {Helpers.colIdDormOwnerLikeDorm} = @Id;";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);
                Mydatabase.rd = Mydatabase.cmd.ExecuteReader();
                if (Mydatabase.rd.Read()) return Mydatabase.rd.GetBoolean(0);


            }
            catch (Exception e)
            {
                MessageBox.Show("Error get State Owner Like Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                Mydatabase.CloseConnection();
            }
            return false;
        }

        //Get List Like Dorm
        public static List<Dorm> GetAllListDormByEmail(string email)
        {
            Mydatabase.sql = $"select * from {Helpers.tbOwnerLikeDorm},{Helpers.tbDorm} where {Helpers.colIdDormOwnerLikeDorm} = {Helpers.colIdDorm} and {Helpers.colLikeOwnerLikeDorm} = 1 and {Helpers.colEmailOwnerLikeDorm}=@Email;";
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
                    int id = Mydatabase.rd.GetInt32(3);
                    string owner = Mydatabase.rd.GetString(4);
                    string address = Mydatabase.rd.GetString(5);
                    string description = Mydatabase.rd.GetString(6);
                    double price = Mydatabase.rd.GetDouble(7);
                    double sale = Mydatabase.rd.GetDouble(8);

                    byte[] image;
                    if (Mydatabase.rd.GetValue(9).ToString().Equals(""))
                    {

                        dorm.Image = new System.Windows.Media.Imaging.BitmapImage(new Uri($"../../images/icon_app.ico", UriKind.RelativeOrAbsolute));

                    }
                    else
                    {

                        image = (byte[])Mydatabase.rd.GetValue(9);

                        dorm.Image = Helpers.ConvertByteToImageBitmap(image);
                    }

                    int count = Mydatabase.rd.GetInt32(10);
                    int countLike = Mydatabase.rd.GetInt32(11);

                    byte wifi = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(12));

                    byte parking = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(13));

                    byte television = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(14));
                    byte bathroom = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(15));
                    byte aircon = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(16));
                    byte waterheater = Helpers.ConverBoolToByte(Mydatabase.rd.GetBoolean(17));

                    int quality = Mydatabase.rd.GetInt16(18);
                    double size = Mydatabase.rd.GetDouble(19);

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
                MessageBox.Show("Error loading List Dorm Owner " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.rd.Close();
                Mydatabase.CloseConnection();
            }

            return listDorm;
        }
    }
}
