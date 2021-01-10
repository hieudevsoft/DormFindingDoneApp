namespace DormFinding
{
    using DormFinding.Database;
    using DormFinding.Models;
    using DormFinding.Utils;
    using Facebook;
    using System;
    using System.Data;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Navigation;
    using System.Windows.Threading;

    public partial class Login : UserControl
    {
        private FacebookClient facebookClient;

        private const string Appid = "1677950655708399";

        private Uri _accessUri;
       
        private const string baseUri = "https://graph.facebook.com/oauth/authorize?";
     
        public String AccessToken { get; set; }

        public Login()
        {
            InitializeComponent();
            AccessToken = "";
        }

        private void setUpLoginFacebook()
        {
            string client_id = Appid;
            string redirect_uri = "https://www.facebook.com/connect/login_success.html";
            string type = "user_agent";
            string display = "popup";

            _accessUri = new Uri($"{baseUri}&client_id={client_id}&redirect_uri={redirect_uri}&type={type}&display={display}", UriKind.Absolute);
        }

        private void btnCreateAccount_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnCreateAccount.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE46B"));
        }

        private void btnCreateAccount_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnCreateAccount.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4F8F7"));
        }

        private void tbForgetPass_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tbForgetPass.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void tbForgetPass_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            tbForgetPass.Foreground = new SolidColorBrush(Colors.DodgerBlue);
        }


        private void btnLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            btnLogin.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3AB19B"));
            btnLogin.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4F8F7"));
            

           
        }

        private void btnLogin_MouseMove(object sender, MouseEventArgs e)
        {
            btnLogin.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3AB19B"));
            btnLogin.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4F8F7"));
        }

        private void btnMinimizedWindow_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(tbEmail.Text.Trim(), tbPassword.Password.Trim(), Helpers.ConverCheckedToInt(cbRememberPass));
            
            if (UserDatabase.CheckAccount(user.Email, user.Password)){
                
                UserDatabase.Update(user,user.Email);
                MainControl m = new MainControl(user,AccessToken);
                Window.GetWindow(this).Hide();
                m.Show();
            }
            else
            {
                Helpers.MakeErrorMessage(Window.GetWindow(this), "Error join app", "Error");
            }
        }

        private void btnFaceBook_Click(object sender, RoutedEventArgs e)
        {
            lyWB.Visibility = Visibility.Visible;
            layoutLogin.Visibility = Visibility.Collapsed;
            btnBackLogin.Visibility = Visibility.Visible;
            layoutMainLogin.Visibility = Visibility.Collapsed;
            setUpLoginFacebook();
            wbBrowser.Navigate(_accessUri);
        }

        private void btnBackLogin_Click(object sender, RoutedEventArgs e)
        {
            lyWB.Visibility = Visibility.Collapsed;
            btnBackLogin.Visibility = Visibility.Collapsed;
            layoutLogin.Visibility = Visibility.Visible;
            layoutMainLogin.Visibility = Visibility.Visible;
            try
            {
                wbBrowser.GoBack();
          
                layoutLogin.Visibility = Visibility.Visible;
            }
            catch (Exception xe)
            {
               
                layoutLogin.Visibility = Visibility.Visible;
            }
        }

        private void wbBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Uri.ToString().StartsWith("https://www.facebook.com/connect/login_success.html"))
            {

                AccessToken = e.Uri.Fragment.Split('&')[0].Replace("#access_token=", "");
                facebookClient = new FacebookClient(AccessToken);
                dynamic me = facebookClient.Get("Me");
                MessageBox.Show($"Đăng nhập Facebook thành công {me.name}");
                Uri  uriPhoto = new Uri("https://graph.facebook.com/" + me.id.ToString() + "/picture/");
                User user = new User();
                user.Email = $"{me.id.ToString()}@facebook.com";
                user.Password = "dormfinding";
                user.isRemember = 0;
                if (UserDatabase.Insert(user.Email,user.Password,user.isRemember))
                {
                    ProfileDatabase.InsertFaceBook(user.Email,me.name.ToString(),Helpers.ConvertImageToBinary(new System.Windows.Media.Imaging.BitmapImage(uriPhoto)));
                }
                else
                {
                    
                }
                MainControl m = new MainControl(user,AccessToken);
                m.Show();
                Window.GetWindow(this).Hide();

            }
        }

       
    }
}
