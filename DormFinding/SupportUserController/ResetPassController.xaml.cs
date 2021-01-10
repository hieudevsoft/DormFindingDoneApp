using DormFinding.Database;
using DormFinding.Models;
using DormFinding.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for ResetPassController.xaml
    /// </summary>
    public partial class ResetPassController : UserControl
    {
        private User user = new User();
        private DispatcherTimer dispatcherTimer;
        public ResetPassController()
        {
            InitializeComponent();

        }

        private void btnLoginR_MouseMove(object sender, MouseEventArgs e)
        {
            btnLoginR.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE46B"));

        }

        private void btnLoginR_MouseLeave(object sender, MouseEventArgs e)
        {
            btnLoginR.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F4F8F7"));
        }
        private void btnMinimizedWindow_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private bool isValidAccount(string email, string password, string confirmpass)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmpass))
            {
                Helpers.MakeErrorMessage(Window.GetWindow(this), "Please fill in the form", "Error");
                return false;
            }
            else
            {
                if (!password.Equals(confirmpass))

                {
                    Helpers.MakeErrorMessage(Window.GetWindow(this), "Password is not matched with the confirmed password", "Error");
                    return false;
                }
                else
                {
                    if (!Helpers.isValidEmail(email))
                    {
                        Helpers.MakeErrorMessage(Window.GetWindow(this), "Email error~", "Error");
                        return false;
                    }

                    return true;
                }
            }
        }

        private void btnResetPass_Click(object sender, RoutedEventArgs e)
        {
            icLoading.Visibility = Visibility.Visible;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(TimerOnTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 400);
            dispatcherTimer.Start();
        }
        private void TimerOnTick(object sender, EventArgs e)
        {
            try
            {
                if (isValidAccount(tbEmailReset.Text.Trim(), tbPasswordReset.Password.Trim(), tbConfirmPassReset.Password.Trim()))
                {
                    user.Email = tbEmailReset.Text.Trim();
                    try
                    {
                        UserProfile userProfile = ProfileDatabase.GetProfile(user);
                        if (userProfile != null)
                        {
                            if (userProfile.Hint.Equals(lbAnswerReset.Text.Trim()))
                            {
                                user.Password = tbPasswordReset.Password.Trim();
                                UserDatabase.Update(user, user.Email);
                                Helpers.MakeConfirmMessage(Window.GetWindow(this), "Reset Password Successfully~", "Notify");
                            }
                            else
                            {
                                Helpers.MakeErrorMessage(Window.GetWindow(this), "Hint is not correct", "Error");
                            }
                        }
                        else
                        {
                            Helpers.MakeErrorMessage(Window.GetWindow(this), "Email not exists"," Error ");
                        }
                    }
                    catch (Exception eh)
                    {
                        Helpers.MakeErrorMessage(Window.GetWindow(this), "Error", "ERROR PROCESSING....");
                    }
                }
                dispatcherTimer.Stop();
                icLoading.Visibility = Visibility.Collapsed;
            }
            catch (Exception er)
            {

            }
        }
    }
}
