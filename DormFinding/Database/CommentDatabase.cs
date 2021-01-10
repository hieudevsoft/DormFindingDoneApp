using DormFinding.Classess;
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
    public static class CommentDatabase
    {
        //Insert
        public static bool Insert(string emailOwner, int idDorm, string emailUser, string comment, int rating)
        {
            Mydatabase.sql = $"insert into {Helpers.tbBookComment} values(@EmailOwner,@Id,@EmailUser,@Comment,@Rating) ;";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text; ;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@EmailOwner", emailOwner);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);
                Mydatabase.cmd.Parameters.AddWithValue("@EmailUser", emailUser);
                Mydatabase.cmd.Parameters.AddWithValue("@Comment", comment);
                Mydatabase.cmd.Parameters.AddWithValue("@Rating", rating);
                Mydatabase.cmd.ExecuteScalar();
                return true;

            }
            catch (Exception e)
            {
                //MessageBox.Show("Error insertDormComment " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            finally
            {
                Mydatabase.CloseConnection();
            }

        }

        //Delete By Id
        public static void DeleteByIdDorm(int idDorm)
        {
            Mydatabase.sql = $"delete from {Helpers.tbBookComment} where {Helpers.tbBookComment} = @Id ;";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text; ;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);

                Mydatabase.cmd.ExecuteScalar();


            }
            catch (Exception e)
            {
                //MessageBox.Show("Error insertDormComment " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.CloseConnection();
            }

        }

        // Get Average Rating of Dorm
        public static int GetAvgRating(string emailOwner, int idDorm)
        {
            Mydatabase.sql = $"select avg({Helpers.colRatingDormComment}) from {Helpers.tbBookComment} where {Helpers.tbBookComment}.{Helpers.colEmailOwnerDormComment} = @Email and {Helpers.tbBookComment}.{Helpers.colIdDormDormComment} = @Id ;";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text; ;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", emailOwner);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", idDorm);

                int a = Convert.ToInt32(Mydatabase.cmd.ExecuteScalar().ToString());
                return a;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error getAVGRatig " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
            finally
            {
                Mydatabase.CloseConnection();
            }

        }

        //Get All Commnet of Dorm
        public static List<BookComment> GetAllCommentBookDorm(string email, int id)
        {
            List<BookComment> list = new List<BookComment>();
            Mydatabase.sql = $"select {Helpers.tbUserProfile}.{Helpers.colEmailProfile},{Helpers.tbUserProfile}.{Helpers.colImageProfile},{Helpers.tbBookComment}.{Helpers.colCommentDormComment},{Helpers.tbBookComment}.{Helpers.colRatingDormComment} " +
                $"from {Helpers.tbUserProfile},{Helpers.tbBookComment} where {Helpers.tbUserProfile}.{Helpers.colEmailProfile} = {Helpers.tbBookComment}.{Helpers.colEmailUserDormComment} " +
                $"and {Helpers.tbBookComment}.{Helpers.colEmailOwnerDormComment} = @Email and {Helpers.tbBookComment}.{Helpers.colIdDormDormComment} = @Id;";
            try
            {
                Mydatabase.OpenConnection();
                Mydatabase.cmd.CommandType = CommandType.Text; ;
                Mydatabase.cmd.CommandText = Mydatabase.sql;
                Mydatabase.cmd.Parameters.Clear();
                Mydatabase.cmd.Parameters.AddWithValue("@Email", email);
                Mydatabase.cmd.Parameters.AddWithValue("@Id", id);

                Mydatabase.rd = Mydatabase.cmd.ExecuteReader();
                while (Mydatabase.rd.Read())
                {
                    BookComment bookDorm = new BookComment();
                    bookDorm.Owner = email;
                    bookDorm.Id = id;
                    bookDorm.User = Mydatabase.rd.GetString(0);
                    try
                    {
                        bookDorm.Image = Helpers.ConvertByteToImageBitmap((byte[])Mydatabase.rd.GetValue(1));
                    }
                    catch(Exception exception)
                    {
                        bookDorm.Image = new System.Windows.Media.Imaging.BitmapImage(new Uri("../../images/blank_account.png", UriKind.RelativeOrAbsolute));
                    }
                    
                    bookDorm.Comment = Mydatabase.rd.GetString(2);                   
                    bookDorm.Rating = Mydatabase.rd.GetInt32(3);
                    list.Add(bookDorm);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error GetAllCommentBookDorm " + e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Mydatabase.CloseConnection();
            }

            return list;
        }
    }
}
