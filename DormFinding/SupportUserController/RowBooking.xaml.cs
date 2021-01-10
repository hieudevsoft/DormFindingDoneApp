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

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for RowBooking.xaml
    /// </summary>
    public partial class RowBooking : UserControl
    {
        public RowBooking()
        {
            InitializeComponent();
        }

        private void btnConfirmBook_Click(object sender, RoutedEventArgs e)
        {
            updateStateDorm(sender, "transfered",2);
        }

        private void btnDecline_Click(object sender, RoutedEventArgs e)
        {
            updateStateDorm(sender, "canceled",0);
        }

        private void updateStateDorm(object sender, string msg,int state)
        {
            Button button = sender as Button;
            BookDorm dorm = button.DataContext as BookDorm;
            if (BookDatabase.UpdateDormWhenBook(dorm.EmailOwner, dorm.EmailUser, dorm.IdDorm,state))
            {
                if (BookDatabase.DeleteDormWhenBook(dorm.EmailOwner, dorm.EmailUser, dorm.IdDorm))
                {
                    Helpers.MakeConfirmMessage(Window.GetWindow(this), $"The Dorm has been {msg} to { dorm.EmailUser}", "Notify");
                    int count = DormDatabase.GetCount(dorm.IdDorm) + 1;
                    DormDatabase.UpdateCountDorm(dorm.IdDorm, count);
                    MainControl mainControl = (MainControl)Window.GetWindow(this);
                    mainControl.MainHomeLayout.Children.Clear();
                    mainControl.MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                    mainControl.MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                    mainControl.MainHomeLayout.Width = 1150;
                    mainControl.MainHomeLayout.Height = 720;
                    mainControl.MainHomeLayout.Children.Add(new MyDorm(mainControl.user));
                }
                else
                {
                    Helpers.MakeErrorMessage(Window.GetWindow(this), $"Failed {msg} to {dorm.EmailUser}", "Error");
                }
            }
        }
    }
}
