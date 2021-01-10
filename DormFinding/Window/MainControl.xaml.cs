using DormFinding.Database;
using DormFinding.Utils;
using Facebook;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>

    public partial class MainControl : Window
    {
        private Uri uriPhoto;
        private BitmapImage imageAvatar;
        public User user;
        private string token;
        int check = 0;
        private string id { get; set; }

        public MainControl(User user, string token)
        {
            InitializeComponent();
            this.token = token;
            this.user = user;


        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception exx)
            {

            }

        }

        private void btnExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            DoubleAnimation doubleAnimation2 = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            doubleAnimation2.From = 1;
            doubleAnimation2.To = 0;
            btnOpenMenu.BeginAnimation(OpacityProperty, doubleAnimation);
            btnCloseMenu.BeginAnimation(OpacityProperty, doubleAnimation2);
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCloseMenu.Visibility = Visibility.Collapsed;

        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            DoubleAnimation doubleAnimation2 = new DoubleAnimation();
            doubleAnimation.Duration = TimeSpan.FromSeconds(1);
            doubleAnimation2.From = 1;
            doubleAnimation2.To = 0;
            btnOpenMenu.BeginAnimation(OpacityProperty, doubleAnimation2);
            btnCloseMenu.BeginAnimation(OpacityProperty, doubleAnimation);
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCloseMenu.Visibility = Visibility.Visible;
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to sign out?", "Notify", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (user != null)
                    {
                        if (user.Email.Contains("@facebook.com"))
                        {
                            FacebookClient fb = new FacebookClient();
                            Uri logoutUrl = fb.GetLogoutUrl(new
                            {
                                access_token = token,
                                next = "https://www.facebook.com/connect/login_sucess.html"
                            });

                            wbLogout.Visibility = Visibility.Visible;
                            wbLogout.Navigate(logoutUrl.AbsoluteUri);

                            token = null;


                        }
                        else
                        {
                            user.isRemember = 0;
                            UserDatabase.Update(user, user.Email);
                            MainWindow m = new MainWindow();
                            m.Show();
                            this.Hide();
                        }

                    }
                    break;
            }

        }

        private void ListViewSideBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewSideBar.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    wbLogout.Visibility = Visibility.Collapsed;
                    TransitioningContentSlideAdd.OnApplyTemplate();
                    MainHomeLayout.Children.Clear();
                    MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                    MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                    MainHomeLayout.Children.Add(new HomeControl(user));
                    break;
                case 1:
                    wbLogout.Visibility = Visibility.Collapsed;
                    TransitioningContentSlideAdd.OnApplyTemplate();
                    MainHomeLayout.Children.Clear();
                    MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                    MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                    MainHomeLayout.Width = 1150;
                    MainHomeLayout.Height = 720;
                    MainHomeLayout.Children.Add(new LikedDorm(LikeDatabase.GetAllListDormByEmail(user.Email), user));
                    break;
                case 2:
                    wbLogout.Visibility = Visibility.Collapsed;
                    TransitioningContentSlideAdd.OnApplyTemplate();
                    MainHomeLayout.Children.Clear();
                    MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                    MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                    MainHomeLayout.Width = 1150;
                    MainHomeLayout.Height = 720;
                    MainHomeLayout.Children.Add(new MyDorm(user));
                    break;
                case 3:
                    wbLogout.Visibility = Visibility.Collapsed;
                    TransitioningContentSlideAdd.OnApplyTemplate();
                    MainHomeLayout.Children.Clear();
                    MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                    MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                    MainHomeLayout.Width = 1150;
                    MainHomeLayout.Height = 720;
                    MainHomeLayout.Children.Add(new PostDorm(user, null));
                    break;
                case 4:
                    wbLogout.Visibility = Visibility.Collapsed;
                    TransitioningContentSlideAdd.OnApplyTemplate();
                    MainHomeLayout.Children.Clear();
                    MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                    MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                    MainHomeLayout.Children.Add(new Profile(user));
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            SlideCursor.Visibility = Visibility.Visible;
            TransitioningContentSlide.OnApplyTemplate();
            switch (index)
            {
                case 0: SlideCursor.Margin = new Thickness(0, 5, 0, 0); break;
                case 1: SlideCursor.Margin = new Thickness(0, 78, 0, 0); break;
                case 2: SlideCursor.Margin = new Thickness(0, 155, 0, 0); break;
                case 3: SlideCursor.Margin = new Thickness(0, 241, 0, 0); break;
                case 4: SlideCursor.Margin = new Thickness(0, 325, 0, 0); break;
            }


        }

        private void wbLogout_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

            if (!e.Uri.ToString().StartsWith("https://www.facebook.com/connect/login_success.html"))
            {
                Helpers.MakeConfirmMessage(this, "Please Sign Out Facebook and Exit App to Logout App", "Notify");
            }
        }
    }
}
