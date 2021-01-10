
using DormFinding.Database;
using DormFinding.Models;
using DormFinding.Utils;
using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for PostDorm.xaml
    /// </summary>
    public partial class PostDorm : UserControl
    {


        public BitmapImage ImageDorm
        {
            get { return (BitmapImage)GetValue(ImageDormProperty); }
            set { SetValue(ImageDormProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImageDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageDormProperty =
            DependencyProperty.Register("ImageDorm", typeof(BitmapImage), typeof(PostDorm),new PropertyMetadata(new BitmapImage(new Uri($"../../images/upload_files.png", UriKind.RelativeOrAbsolute))));


        public string OwnerDorm
        {
            get { return (string)GetValue(OwnerDormProperty); }
            set { SetValue(OwnerDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OwnerDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OwnerDormProperty =
            DependencyProperty.Register("OwnerDorm", typeof(string), typeof(PostDorm), new PropertyMetadata(""));


        public string AddressDorm
        {
            get { return (string)GetValue(AddressDormProperty); }
            set { SetValue(AddressDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddressDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddressDormProperty =
            DependencyProperty.Register("AddressDorm", typeof(string), typeof(PostDorm), new PropertyMetadata(""));


        public double PriceDorm
        {
            get { return (double)GetValue(PriceDormProperty); }
            set { SetValue(PriceDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PriceDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceDormProperty =
            DependencyProperty.Register("PriceDorm", typeof(double), typeof(PostDorm), new PropertyMetadata(0.0));



        public double AreaDorm
        {
            get { return (double)GetValue(AreaDormProperty); }
            set { SetValue(AreaDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AreaDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AreaDormProperty =
            DependencyProperty.Register("AreaDorm", typeof(double), typeof(PostDorm), new PropertyMetadata(0.0));


        public double SaleDorm
        {
            get { return (double)GetValue(SaleDormProperty); }
            set { SetValue(SaleDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SaleDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaleDormProperty =
            DependencyProperty.Register("SaleDorm", typeof(double), typeof(PostDorm), new PropertyMetadata(0.0));



        public string DesDorm
        {
            get { return (string)GetValue(DesDormProperty); }
            set { SetValue(DesDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DesDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DesDormProperty =
            DependencyProperty.Register("DesDorm", typeof(string), typeof(PostDorm), new PropertyMetadata(""));



        public bool WifiDorm
        {
            get { return (bool)GetValue(WifiDormProperty); }
            set { SetValue(WifiDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WifiDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WifiDormProperty =
            DependencyProperty.Register("WifiDorm", typeof(bool), typeof(PostDorm), new PropertyMetadata(false));



        public bool ParkingDorm
        {
            get { return (bool)GetValue(ParrkingDormProperty); }
            set { SetValue(ParrkingDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ParrkingDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ParrkingDormProperty =
            DependencyProperty.Register("ParkingDorm", typeof(bool), typeof(PostDorm), new PropertyMetadata(false));



        public bool TelevisionDorm
        {
            get { return (bool)GetValue(TelevisionDormProperty); }
            set { SetValue(TelevisionDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TelevisionDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TelevisionDormProperty =
            DependencyProperty.Register("TelevisionDorm", typeof(bool), typeof(PostDorm), new PropertyMetadata(false));




        public bool BathDorm
        {
            get { return (bool)GetValue(BathDormProperty); }
            set { SetValue(BathDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BathDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BathDormProperty =
            DependencyProperty.Register("BathDorm", typeof(bool), typeof(PostDorm), new PropertyMetadata(false));



        public bool AirConDorm
        {
            get { return (bool)GetValue(AirConDormProperty); }
            set { SetValue(AirConDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AirConDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AirConDormProperty =
            DependencyProperty.Register("AirConDorm", typeof(bool), typeof(PostDorm), new PropertyMetadata(false));


        private User user;
        public bool WaterHeaterDorm
        {
            get { return (bool)GetValue(WaterHeaterDormProperty); }
            set { SetValue(WaterHeaterDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaterHeaterDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaterHeaterDormProperty =
            DependencyProperty.Register("WaterHeaterDorm", typeof(bool), typeof(PostDorm), new PropertyMetadata(false));

        private string filePathImage;
        private Dorm dormSend;
        private bool check = false;
        public PostDorm(User user, Dorm id)
        {
            InitializeComponent();
            this.user = user;
            this.dormSend = id;
            initDorm();
            TransitioningContentSlideAdd.OnApplyTemplate();
        }
        private void initDorm()
        {
            if (dormSend != null)
            {
                OwnerDorm = dormSend.Owner;
                AddressDorm = dormSend.Address;
                PriceDorm = dormSend.Price;
                AreaDorm = dormSend.Size;
                SaleDorm = dormSend.Sale;
                DesDorm = dormSend.Description;
                ImageDorm = dormSend.Image;
                WifiDorm = Helpers.ConvertVisibilityToBool(dormSend.IsWifi);
                ParkingDorm = Helpers.ConvertVisibilityToBool(dormSend.IsParking);
                TelevisionDorm = Helpers.ConvertVisibilityToBool(dormSend.IsTelevision);
                BathDorm = Helpers.ConvertVisibilityToBool(dormSend.IsBathroom);
                AirConDorm = Helpers.ConvertVisibilityToBool(dormSend.IsAirCondiditioner);
                WaterHeaterDorm = Helpers.ConvertVisibilityToBool(dormSend.IsWaterHeater);
                btnBack.Visibility = Visibility.Visible;
                check = true;
            }
        }
        private void tbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void tbArea_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9]+");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void tbSale_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^(?:100|[1-9]?[0-9])$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void btnUploadDorm_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(.jpg,.png)|*.jpg;*.png;*.jpeg|*.gif|All";
            dialog.Title = "Select Image";
            dialog.Multiselect = false;
            dialog.ValidateNames = true;
            if(dialog.ShowDialog() == true)
            {
                filePathImage = dialog.FileName;
                ImageDorm = new BitmapImage(new System.Uri(filePathImage, System.UriKind.RelativeOrAbsolute));
            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            DormDb dorm = new DormDb();
            dorm.Owner = OwnerDorm;
            dorm.Address = AddressDorm;
            dorm.Price = PriceDorm;
            dorm.Size = AreaDorm;
            dorm.Sale = SaleDorm;
            dorm.Quality = 0;
            dorm.Count = 0;
            dorm.CountLike = 0;
            dorm.Description = DesDorm;
            dorm.Image = Helpers.ConvertImageToBinary(ImageDorm);
            dorm.IsWifi = Helpers.ConverBoolToByte(WifiDorm);
            dorm.IsParking = Helpers.ConverBoolToByte(ParkingDorm);
            dorm.IsTelevision = Helpers.ConverBoolToByte(TelevisionDorm);
            dorm.IsBathroom = Helpers.ConverBoolToByte(BathDorm);
            dorm.IsAirCondiditioner = Helpers.ConverBoolToByte(AirConDorm);
            dorm.IsWaterHeater = Helpers.ConverBoolToByte(WaterHeaterDorm);
            if (!check)
            {

                if (DormDatabase.Insert(dorm))
                {
                    Helpers.MakeConfirmMessage(Window.GetWindow(this), "Post Dorm Successfully~", "Notify");
                    OwnerDormDatabase.Insert(user.Email, DormDatabase.GetAllListDorm()[DormDatabase.GetAllListDorm().Count - 1].Id);
                }
            }
            else
            {
               
                if(DormDatabase.Update(dorm,dormSend.Id)) Helpers.MakeConfirmMessage(Window.GetWindow(this), "Update Dorm Successfully~", "Notify");
                else Helpers.MakeErrorMessage(Window.GetWindow(this), "Failure update Dorm", "Error");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainControl mainControl = (MainControl)Window.GetWindow(this);
            mainControl.MainHomeLayout.Children.Clear();
            mainControl.MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
            mainControl.MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
            mainControl.MainHomeLayout.Width = 1150;
            mainControl.MainHomeLayout.Height = 690;
            mainControl.MainHomeLayout.Children.Add(new MyDorm(user));
        }
    }
}
