
using DormFinding.Models;
using DormFinding.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace DormFinding.Database
{
    public static class DormDatabase
    {
        //Insert Dorm to Database
        public static bool Insert(DormDb dorm)
        {

            Mydatabase.sql = $"insert into {Helpers.tbDorm}(" +
                $"{Helpers.colOwnerDorm}," +
                $"{Helpers.colAdressDorm}," +
                $"{Helpers.colDescriptionDorm}," +
                $"{Helpers.colPriceDorm}," +
                $"{Helpers.colSaleDorm}," +
                $"{Helpers.colImageDorm}," +
                $"{Helpers.colCountDorm}," +
                $"{Helpers.colCountLikeDorm}," +
                $"{Helpers.colWifiDorm}," +
                $"{Helpers.colParkingDorm}," +
                $"{Helpers.colTelevisionDorm}," +
                $"{Helpers.colBathroomDorm}," +
                $"{Helpers.colAirconditionerDorm}," +
                $"{Helpers.colWaterHeaterDorm}," +
                $"{Helpers.colQualityDorm}," +
                $"{Helpers.colSizeDorm})" +
                $"values(" +
                $"@Owner," +
                $"@Address," +
                $"@Description," +
                $"@Price," +
                $"@Sale," +
                $"@Image," +
                $"@Count," +
                $"@CountLike," +
                $"@Wifi," +
                $"@Parking," +
                $"@Television," +
                $"@Bathroom," +
                $"@AirConditioner," +
                $"@WaterHeater," +
                $"@Quality," +
                $"@Size" +
                $");";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Owner", dorm.Owner);
                Mydatabase.cmd.Parameters.AddWithValue("@Address", dorm.Address);
                Mydatabase.cmd.Parameters.AddWithValue("@Description", dorm.Description);
                Mydatabase.cmd.Parameters.AddWithValue("@Price", dorm.Price);
                Mydatabase.cmd.Parameters.AddWithValue("@Sale", dorm.Sale);
                Mydatabase.cmd.Parameters.AddWithValue("@Image", dorm.Image);
                Mydatabase.cmd.Parameters.AddWithValue("@Count", dorm.Count);
                Mydatabase.cmd.Parameters.AddWithValue("@CountLike", dorm.CountLike);
                Mydatabase.cmd.Parameters.AddWithValue("@Wifi", dorm.IsWifi);
                Mydatabase.cmd.Parameters.AddWithValue("@Parking", dorm.IsParking);
                Mydatabase.cmd.Parameters.AddWithValue("@Television", dorm.IsTelevision);
                Mydatabase.cmd.Parameters.AddWithValue("@Bathroom", dorm.IsBathroom);
                Mydatabase.cmd.Parameters.AddWithValue("@AirConditioner", dorm.IsAirCondiditioner);
                Mydatabase.cmd.Parameters.AddWithValue("@WaterHeater", dorm.IsWaterHeater);
                Mydatabase.cmd.Parameters.AddWithValue("@Quality", dorm.Quality);
                Mydatabase.cmd.Parameters.AddWithValue("@Size", dorm.Size);

                Mydatabase.cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Insert Dorm Error " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Update Dorm to Database
        public static bool Update(DormDb dorm, int id)
        {

            Mydatabase.sql = $"update {Helpers.tbDorm} set " +
                $"{Helpers.colOwnerDorm} = @Owner," +
                $"{Helpers.colAdressDorm} = @Address," +
                $"{Helpers.colDescriptionDorm} = @Description," +
                $"{Helpers.colPriceDorm } = @Price," +
                $"{Helpers.colSaleDorm} = @Sale ," +
                $"{Helpers.colImageDorm} = @Image," +
                $"{Helpers.colCountDorm} = @Count," +
                $"{Helpers.colCountLikeDorm} = @CountLike," +
                $"{Helpers.colWifiDorm} = @Wifi," +
                $"{Helpers.colParkingDorm} = @Parking," +
                $"{Helpers.colTelevisionDorm} = @Television," +
                $"{Helpers.colBathroomDorm} = @Bathroom," +
                $"{Helpers.colAirconditionerDorm} = @AirConditioner," +
                $"{Helpers.colWaterHeaterDorm} = @WaterHeater," +
                $"{Helpers.colQualityDorm} = @Quality," +
                $"{Helpers.colSizeDorm} = @Size where {Helpers.colIdDorm} = @Id;";

            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Owner", dorm.Owner);
                Mydatabase.cmd.Parameters.AddWithValue("@Address", dorm.Address);
                Mydatabase.cmd.Parameters.AddWithValue("@Description", dorm.Description);
                Mydatabase.cmd.Parameters.AddWithValue("@Price", dorm.Price);
                Mydatabase.cmd.Parameters.AddWithValue("@Sale", dorm.Sale);
                Mydatabase.cmd.Parameters.AddWithValue("@Image", dorm.Image);
                Mydatabase.cmd.Parameters.AddWithValue("@Count", dorm.Count);
                Mydatabase.cmd.Parameters.AddWithValue("@CountLike", dorm.CountLike);
                Mydatabase.cmd.Parameters.AddWithValue("@Wifi", dorm.IsWifi);
                Mydatabase.cmd.Parameters.AddWithValue("@Parking", dorm.IsParking);
                Mydatabase.cmd.Parameters.AddWithValue("@Television", dorm.IsTelevision);
                Mydatabase.cmd.Parameters.AddWithValue("@Bathroom", dorm.IsBathroom);
                Mydatabase.cmd.Parameters.AddWithValue("@AirConditioner", dorm.IsAirCondiditioner);
                Mydatabase.cmd.Parameters.AddWithValue("@WaterHeater", dorm.IsWaterHeater);
                Mydatabase.cmd.Parameters.AddWithValue("@Quality", dorm.Quality);
                Mydatabase.cmd.Parameters.AddWithValue("@Size", dorm.Size);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);

                Mydatabase.cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Update Dorm Error " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Update Rating Dorm
        public static bool UpdateRating(int id, int quality)
        {

            Mydatabase.sql = $"update {Helpers.tbDorm} set " +
                $"{Helpers.colQualityDorm} = @Quality " +
                $"where {Helpers.colIdDorm} = @Id;";

            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Quality", quality);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);

                Mydatabase.cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error updateRatingDorm Error " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Update Count Dorm
        public static bool UpdateCountDorm(int id, int count)
        {

            Mydatabase.sql = $"update {Helpers.tbDorm} set " +
                $"{Helpers.colCountDorm} = @Count " +
                $"where {Helpers.colIdDorm} = @Id;";

            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Count", count);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);

                Mydatabase.cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error updateCountDorm Error " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Update Like Dorm
        public static void UpdateLikeDorm(Dorm dorm)
        {
            Mydatabase.sql = $"update {Helpers.tbDorm} SET {Helpers.colCountLikeDorm}=@Count where {Helpers.colIdDorm}=@Id;";

            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Count", dorm.CountLike);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", dorm.Id);

                Mydatabase.cmd.ExecuteScalar();


            }
            catch (Exception e)
            {
                MessageBox.Show("Error Update Like Dorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Get number of user book this dorm
        public static int GetCount(int id)
        {

            Mydatabase.sql = $"select {Helpers.colCountDorm} from {Helpers.tbDorm} where {Helpers.colIdDorm} = @Id";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);

                int count = Convert.ToInt32(Mydatabase.cmd.ExecuteScalar());
                return count;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error getCountDorm Error " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        // Delete Dorm
        public static bool Delete(int id)
        {

            Mydatabase.sql = $"delete from {Helpers.tbDorm} where {Helpers.colIdDorm} = @Id";

            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);

                Mydatabase.cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Delete Dorm tbDorm Error " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                Mydatabase.CloseConnection();
            }
        }

        //Gưt All List Dorm New

        public static List<Dorm> GetAllListDormNew()
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm} order by {Helpers.colIdDorm} DESC";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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

        //Get All List Dorm already in Databasee
        public static List<Dorm> GetAllListDorm()
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm}";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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

        //Get List Dorm follow rating
        public static List<Dorm> GetAllListDormPopular()
        {
            Mydatabase.sql = $"select top 6 * from {Helpers.tbDorm} order by {Helpers.colQualityDorm} desc";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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
                MessageBox.Show("Error getAllListDormPopular " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.rd.Close();
                Mydatabase.CloseConnection();
            }

            return listDorm;
        }

        //Arrange Dorm Increasing Price
        public static List<Dorm> GetAllListDormIncreasingPrice()
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm} order by {Helpers.colPriceDorm}";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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

        //Arrange Dorm Decreasing Price
        public static List<Dorm> GetAllListDormDecreasingPrice()
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm} order by {Helpers.colPriceDorm} DESC";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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

        //Arrange Dorm Increasing BookTimes
        public static List<Dorm> GetAllListDormIncreasingBookTimes()
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm} order by {Helpers.colCountDorm}";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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

        //Arrange Dorm Decreasing BookTimes
        public static List<Dorm> GetAllListDormDecreasingBookTimes()
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm} order by {Helpers.colCountDorm} DESC";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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

        //Arrange Dorm Increasing Like
        public static List<Dorm> GetAllListDormIncreasingLike()
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm} order by {Helpers.colCountLikeDorm}";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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

        //Arrange Dorm Decreasing Like
        public static List<Dorm> GetAllListDormDecreasingLike()
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm} order by {Helpers.colCountLikeDorm} DESC";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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

        //Arrange Dorm Increasing Rating
        public static List<Dorm> GetAllListDormIncreasingRating()
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm} order by {Helpers.colQualityDorm}";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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

        //Arrange Dorm Decreasing Rating
        public static List<Dorm> GetAllListDormDecreasingRating()
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm} order by {Helpers.colQualityDorm} DESC";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
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

        //Get Dorm by Id

        public static Dorm Get(int idDorm)
        {
            Mydatabase.sql = $"select * from {Helpers.tbDorm} where {Helpers.colIdDorm} = @Id";
            List<Dorm> listDorm = new List<Dorm>();
            try
            {
                Mydatabase.OpenConnection();

                Mydatabase.cmd.CommandType = CommandType.Text;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);
                Mydatabase.rd = Mydatabase.cmd.ExecuteReader();
                if (Mydatabase.rd.Read())
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

                    return dorm;

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error get " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.rd.Close();
                Mydatabase.CloseConnection();
            }

            return null;
        }

    }
}
