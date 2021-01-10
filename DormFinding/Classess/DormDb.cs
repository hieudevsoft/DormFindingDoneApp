using System.Windows;

namespace DormFinding
{
    public class DormDb
    {
        private int _id;
        private string _owner;
        private string _address;
        private double _price;
        private string _description;
        private double _sale;
        private byte[] _image;
        private int _count;
        private int _countLike;
        private byte _isWifi;
        private byte _isParking;
        private byte _isTelevision;
        private byte _isBathroom;
        private byte _isAirCondiditioner;
        private byte _isWaterHeater;
        private double _size;
        private int _quality;
        public string Owner { get => _owner; set => _owner = value; }
        public string Address { get => _address; set => _address = value; }
        public string Description { get => _description; set => _description = value; }
        public double Price { get => _price; set => _price = value; }

        public int Count { get => _count; set => _count = value; }
        public int CountLike { get => _countLike; set => _countLike = value; }
        public byte IsWifi { get => _isWifi; set => _isWifi = value; }
        public byte IsParking { get => _isParking; set => _isParking = value; }
        public byte IsTelevision { get => _isTelevision; set => _isTelevision = value; }
        public byte IsBathroom { get => _isBathroom; set => _isBathroom = value; }
        public byte IsAirCondiditioner { get => _isAirCondiditioner; set => _isAirCondiditioner = value; }
        public byte IsWaterHeater { get => _isWaterHeater; set => _isWaterHeater = value; }
        public int Id { get => _id; set => _id = value; }
        public byte[] Image { get => _image; set => _image = value; }
        public int Quality { get => _quality; set => _quality = value; }
        public double Sale { get => _sale; set => _sale = value; }
        public double Size { get => _size; set => _size = value; }

        public DormDb()
        {

        }

        public DormDb(
            int id,
            string owner,
            string address,
            string description,
            double price,
            double sale,
            byte[] image,
            int count,
            int countLike,
            byte isWifi,
            byte isParking,
            byte isTelevision,
            byte isBathroom,
            byte isAirCondiditioner,
            byte isWaterHeater,
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
    }
}
