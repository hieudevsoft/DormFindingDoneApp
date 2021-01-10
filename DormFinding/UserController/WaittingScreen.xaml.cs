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
    /// Interaction logic for WaittingScreen.xaml
    /// </summary>
    public partial class WaittingScreen : UserControl
    {
        private List<BookDorm> list;
        public WaittingScreen(List<BookDorm> listA)
        {
            this.list = listA;
            InitializeComponent();
            listViewDormBook.ItemsSource = list;
        }

        private void listViewDormBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookDorm dormB = listViewDormBook.SelectedItem as BookDorm;
            Dorm dorm = DormDatabase.Get(dormB.IdDorm);
            MainControl mainControl = (MainControl)Window.GetWindow(this);
            mainControl.MainHomeLayout.Children.Clear();
            TransitioningContentSlide.OnApplyTemplate();
            mainControl.MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
            mainControl.MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
            mainControl.MainHomeLayout.Width = 1150;
            mainControl.MainHomeLayout.Height = 720;
            mainControl.MainHomeLayout.Children.Add(new ShowDorm(dorm, BookDatabase.GetOwnerByIdDorm(dorm.Id),2));
        }
    }
}
