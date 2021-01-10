using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DormFinding.Utils
{
    public class Helpers
    {
        public static bool isValidEmail(String email)
        {
            try
            {
                MailAddress maiAddress = new MailAddress(email);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public static void MakeErrorMessage(Window w,string title,string message)=> MessageBox.Show(title, message, MessageBoxButton.OK, MessageBoxImage.Error);
        public static void MakeConfirmMessage(Window w, string title, string message) => MessageBox.Show(title, message, MessageBoxButton.OK, MessageBoxImage.Information);
        public static string GetTextTextBox(TextBox t) => t.Text.Trim();
        public static string GetTextPassWord(PasswordBox p) => p.Password.Trim();
        public static byte ConverCheckedToInt(CheckBox cb)
        {
            if (cb.IsChecked == true) return 1; else return 0;
        }
        public static byte ConverBoolToByte(bool cb)
        {
            if (cb) return 1; else return 0;
        }
        public static bool ConverByteToBool(byte cb)
        {
            if (cb==1) return true; else return false;
        }
        public static BitmapImage ConvertByteToImageBitmap(byte[] array)
        {
            MemoryStream ms = new MemoryStream(array);          
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
        public static byte[] ConvertImageToBinary(BitmapImage image)
        {
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            var ms = new MemoryStream();
            encoder.Save(ms);   
            return ms.ToArray();
        }
        public static Visibility ConvertByteToVisibility(byte a)
        {
            if (a == 1) return Visibility.Collapsed; else return Visibility.Visible;
        }
        public static bool ConvertVisibilityToBool(Visibility a)
        {
            if (a == Visibility.Visible) return false; else return true;
        }
        public static void shortDateFormating()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            Thread.CurrentThread.CurrentCulture = ci;
        }
        public static byte ConvertBoolToByte(bool a)
        {
            if (a == true) return 1; else return 0;
        }
        public static string ConvertByteToGender(byte a)
        {
            if (a == 1) return "Female"; else return "Male";
        }
        public static string ConvertStateToText(int a)
        {
            if (a == 1) return "Booking...";
            if (a == 0) return "Book Now";
            if (a == 2) return "Booked";

            return "Error";
        }

        //Table User
        public static string tbUser = "tbUser";
        public static string colEmail = "_email";
        public static string colPassword = "_password";
        public static string colRemember = "_isRemember";

        //Table User Profile
        public static string tbUserProfile = "tbProfile";
        public static string colEmailProfile = "_email_profile";
        public static string colNameProfile = "_name_profile";
        public static string colDateProfile = "_date_profile";
        public static string colPhoneProfile = "_phone_profile";
        public static string colAdressProfile = "_address_profile";
        public static string colHintProfile = "_hintanswer_profile";
        public static string colGenderProfile = "_gender_profile";
        public static string colImageProfile = "_image_profile";

        //Table Dorm
        public static string tbDorm = "tbDorm";
        public static string colIdDorm = "_id";
        public static string colOwnerDorm = "_owner";
        public static string colAdressDorm = "_address";
        public static string colDescriptionDorm = "_description";
        public static string colPriceDorm = "_price";
        public static string colSaleDorm = "_sale";
        public static string colImageDorm = "_image";
        public static string colCountDorm = "_count";
        public static string colCountLikeDorm = "_countLike";
        public static string colWifiDorm = "_isWifi";
        public static string colParkingDorm = "_isParking";
        public static string colTelevisionDorm = "_isTevevision";
        public static string colBathroomDorm = "_isBathroom";
        public static string colAirconditionerDorm = "_isAirConditioner";
        public static string colWaterHeaterDorm = "_isWaterHeater";
        public static string colQualityDorm = "_quality";
        public static string colSizeDorm = "_size";

        //Table Dorm reference with User
        public static string tbDormOwner = "tbDormOwner";
        public static string colIdDormUser = "Id";
        public static string colEmailOwnerDorm = "_email_owner";
        public static string colIdOwnerDorm = "_id_dorm";

        //Table Owner Like Dorm 
        public static string tbOwnerLikeDorm = "tbOwnerLikeDorm";
        public static string colIdOwnerLikeDorm = "Id";
        public static string colEmailOwnerLikeDorm = "_email";
        public static string colIdDormOwnerLikeDorm = "_id_dorm";
        public static string colLikeOwnerLikeDorm = "_is_like";

        //Table Book Dorm
        public static string tbBookDorm = "tbBookDorm";
        public static string colEmailOwnerBookDorm = "_email_owner";
        public static string colEmailUserBookDorm = "_email_user";
        public static string colIdDormBookDorm = "_id_dorm";
        public static string colStateBookDorm = "_state_book";

        //Table Book Comment
        public static string tbBookComment = "tbDormComment";
        public static string colEmailOwnerDormComment = "_email_owner";
        public static string colEmailUserDormComment = "_email_user";
        public static string colIdDormDormComment = "_id_dorm";
        public static string colCommentDormComment = "_comment";
        public static string colRatingDormComment = "_rating";
    }
}
