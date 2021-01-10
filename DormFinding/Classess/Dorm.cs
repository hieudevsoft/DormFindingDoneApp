using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace DormFinding { 
    public class Dorm
    {
        private int _id;
        private string _owner;
        private string _address;
        private double _price;
        private string _description;
        private double _sale;
        private BitmapImage _image;
        private int _count;
        private int _countLike;
        private Visibility _isWifi;
        private Visibility _isParking;
        private Visibility _isTelevision;
        private Visibility _isBathroom;
        private Visibility _isAirCondiditioner;
        private Visibility _isWaterHeater;
        private double _size;
        private int _quality;
        public string Owner { get => _owner; set => _owner = value; }
        public string Address { get => _address; set => _address = value; }
        public string Description { get => _description; set => _description = value; }
        public double Price { get => _price; set => _price = value; }
        
        public int Count { get => _count; set => _count = value; }
        public int CountLike { get => _countLike; set => _countLike = value; }
        public Visibility IsWifi { get => _isWifi; set => _isWifi = value; }
        public Visibility IsParking { get => _isParking; set => _isParking = value; }
        public Visibility IsTelevision { get => _isTelevision; set => _isTelevision = value; }
        public Visibility IsBathroom { get => _isBathroom; set => _isBathroom = value; }
        public Visibility IsAirCondiditioner { get => _isAirCondiditioner; set => _isAirCondiditioner = value; }
        public Visibility IsWaterHeater { get => _isWaterHeater; set => _isWaterHeater = value; }
        public int Id { get => _id; set => _id = value; }
        public BitmapImage Image { get => _image; set => _image = value; }
        public int Quality { get => _quality; set => _quality = value; }
        public double Sale { get => _sale; set => _sale = value; }
        public double Size { get => _size; set => _size = value; }

        public Dorm()
        {

        }

        public Dorm(
            int id,
            string owner,
            string address,
            string description,
            double price,
            double sale,
            BitmapImage image,
            int count,
            int countLike,
            Visibility isWifi,
            Visibility isParking,
            Visibility isTelevision,
            Visibility isBathroom,
            Visibility isAirCondiditioner,
            Visibility isWaterHeater,
            int quality,
            double size
            )
            
        {
            Id = id;
            Owner = owner;
            Address = address;
            Description = description;
            Price = price;
            Sale = _sale;
            Image = image;
            Quality = quality;
            Count = count;
            CountLike = countLike;
            IsWifi = isWifi;
            IsParking = isParking;
            IsTelevision = isTelevision;
            IsBathroom = isBathroom;
            IsAirCondiditioner = isAirCondiditioner;
            IsWaterHeater = isWaterHeater;
            Size = size;
        }

        public static implicit operator Dorm(List<Dorm> v)
        {
            throw new NotImplementedException();
        }
    }
}
