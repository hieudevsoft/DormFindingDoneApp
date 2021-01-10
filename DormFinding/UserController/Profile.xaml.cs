using DormFinding.Models;
using DormFinding.Utils;
using Facebook;
using Prism.Services.Dialogs;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DormFinding.Database;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        private User user;
        private UserProfile userProfile;
        private string fileImage;


        public DateTime myDate
        {
            get { return (DateTime)GetValue(myDateProperty); }
            set { SetValue(myDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for myDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty myDateProperty =
            DependencyProperty.Register("myDate", typeof(DateTime), typeof(Profile));

        public Profile(User user)
        {
            InitializeComponent();
            this.user = user;
            this.DataContext = this;
            this.Resources["colorBackGroundMode"] = new SolidColorBrush(Colors.White);
            TransitioningContentSlide1.OnApplyTemplate();
            TransitioningContentSlide2.OnApplyTemplate();
            initProfile();

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tbDarkMode_Checked(object sender, RoutedEventArgs e)
        {
            openDarkMode();

        }

        private void tbDarkMode_Unchecked(object sender, RoutedEventArgs e)
        {
            closeDarkMode();
        }

        private void openDarkMode()
        {
            this.Resources["colorBackGroundMode"] = new SolidColorBrush(Color.FromRgb(49, 49, 49));
            this.Resources["colorLightMode"] = new SolidColorBrush(Colors.White);
            txtDarkMode.Text = "Dark Mode";
        }

        private void closeDarkMode()
        {
            this.Resources["colorBackGroundMode"] = new SolidColorBrush(Colors.White);
            this.Resources["colorLightMode"] = new SolidColorBrush(Color.FromRgb(49, 49, 49));
            txtDarkMode.Text = "Light Mode";
        }

        private void initProfile()
        {
            userProfile = ProfileDatabase.GetProfile(user);
            tbNameProfile.Text = userProfile.Name;
            tbPhoneProfile.Text = userProfile.Phone;
            tbEmailProfile.Text = userProfile.Email;
            tbEmailProfile.IsEnabled = false;
            tbAddress.Text = userProfile.Address;
            tbHint.Text = userProfile.Hint;
            cbGender.SelectedIndex = userProfile.Gender;
            string date = userProfile.Date;
            if (String.IsNullOrEmpty(date))
            {
                Helpers.shortDateFormating();
                myDate = DateTime.Today;
            }
            else
            {
                Helpers.shortDateFormating();
                myDate = DateTime.Parse(date);
            }
            if (userProfile.Avatar != null)
                imgAvatarMini.ImageSource = Helpers.ConvertByteToImageBitmap(userProfile.Avatar);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            userProfile.Address = tbAddress.Text.Trim();
            userProfile.Hint = tbHint.Text.Trim();
            userProfile.Date = dpDateOfBirth.SelectedDate.ToString().Split(' ')[0].Trim();
            userProfile.Gender = (byte)cbGender.SelectedIndex;

            if (ProfileDatabase.UpdateProfileSubmit(userProfile)) MessageBox.Show("Update SuccessFull", "Notify");
        }

        private void btnSaveProfile_Click(object sender, RoutedEventArgs e)
        {
            userProfile.Name = tbNameProfile.Text.Trim();
            userProfile.Phone = tbPhoneProfile.Text.Trim();
            try
            {
                userProfile.Avatar = Helpers.ConvertImageToBinary((BitmapImage)imgAvatarMini.ImageSource);
            }
            catch(Exception ex)
            {
                userProfile.Avatar = Helpers.ConvertImageToBinary(new BitmapImage(new Uri("../../images/blank_account.png",UriKind.RelativeOrAbsolute)));
            }
            
            if (ProfileDatabase.UpdateProfileSave(userProfile)) MessageBox.Show("Update SuccessFull", "Notify");
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string oldPass = psbOldPass.Password.Trim();
            if (!user.Password.Equals(oldPass))
            {
                Helpers.MakeErrorMessage(Window.GetWindow(this), "Error", "Password is not correct");
            }
            else
            {
                string newPass = psbNewPass.Password.Trim();
                string confirmPass = psbConfirmNewPass.Password.Trim();
                if (!newPass.Equals(confirmPass))
                {
                    Helpers.MakeErrorMessage(Window.GetWindow(this), "Error", "New Password and Confirm Password isn't matcher");
                }
                else
                {
                    user.Password = newPass;
                    user.isRemember = 0;
                    if (UserDatabase.Update(user, user.Email))
                    {
                        Helpers.MakeConfirmMessage(Window.GetWindow(this), "Update Password Successfully~", "Notify");
                    }
                    else
                        Helpers.MakeErrorMessage(Window.GetWindow(this), "Error", "Update Failure");
                }
            }

        }
    
        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(.jpg,.png)|*.jpg;*.png;*.jpeg|*.gif|All";
            dialog.Title = "Select Avatar";
            dialog.Multiselect = false;
            dialog.ValidateNames = true;
            if (dialog.ShowDialog() == true)
            {
                fileImage = dialog.FileName;
                imgAvatarMini.ImageSource = new BitmapImage(new Uri(fileImage, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
