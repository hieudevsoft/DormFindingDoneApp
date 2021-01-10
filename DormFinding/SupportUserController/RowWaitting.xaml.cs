using DormFinding.Database;
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
    /// Interaction logic for RowWaitting.xaml
    /// </summary>
    public partial class RowWaitting : UserControl
    {
        public RowWaitting()
        {
            InitializeComponent();
        }

        private void btnCanel_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            BookDorm dormB = button.DataContext as BookDorm;
            Dorm dorm = DormDatabase.Get(dormB.IdDorm);
            MainControl mainControl = (MainControl)Window.GetWindow(this);
            MessageBoxResult result = MessageBox.Show("Would you like to cancel booking this dorm?", "Notify", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (BookDatabase.DeleteDormWhenBookUser(mainControl.user.Email,dorm.Id))
                    {                    
                        mainControl.MainHomeLayout.Children.Clear();
                        mainControl.MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                        mainControl.MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                        mainControl.MainHomeLayout.Width = 1150;
                        mainControl.MainHomeLayout.Height = 720;
                        mainControl.MainHomeLayout.Children.Add(new MyDorm(mainControl.user));
                    }
                    break;
            }
        }
    }
}
