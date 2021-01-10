using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        DispatcherTimer dispatcherTimer;
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            if(progressBar.Value<100)
               progressBar.Value ++;
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                dispatcherTimer.Stop();
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 1;
            doubleAnimation.Duration = TimeSpan.FromSeconds(2);
            this.BeginAnimation(OpacityProperty, doubleAnimation);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(TimerOnTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0 ,20);
            dispatcherTimer.Start();
        }
    }
}
