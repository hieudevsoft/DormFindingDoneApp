using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DormFinding.Classess
{
    public class BookComment
    {
        private int _rating;
        private int _id;
        private BitmapImage image;
        private string _comment;
        private string user;
        private string owner;

        public int Rating { get => _rating; set => _rating = value; }
        public string Comment { get => _comment; set => _comment = value; }
        public BitmapImage Image { get => image; set => image = value; }
        public string User { get => user; set => user = value; }
        public string Owner { get => owner; set => owner = value; }
        public int Id { get => _id; set => _id = value; }

        public BookComment()
        {
        }

        public BookComment(int rating, string comment, BitmapImage image, string user, string owner,int id)
        {
            Rating = rating;
            Comment = comment;
            Image = image;
            User = user;
            Owner = owner;
            Id = id;
        }
    }
}
