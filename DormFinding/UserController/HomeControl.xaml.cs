using DormFinding.Database;
using DormFinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
namespace DormFinding
{
    /// <summary>
    /// Interaction logic for HomeControl.xaml
    /// </summary>
    public partial class HomeControl : UserControl
    {
        private List<Dorm> listDorm = new List<Dorm>();
        private List<Dorm> listDormVerti = new List<Dorm>();
        private User user;
        public HomeControl(User user)
        {
            InitializeComponent();
            this.user = user;
            setUpListViewHori();
            setUpListViewVerti();
            TransitioningContentSlide.OnApplyTemplate();
        }

        private void setUpListViewHori()
        {
            listDorm = DormDatabase.GetAllListDormPopular();
            listViewHori.ItemsSource = listDorm;

        }
        private void setUpListViewVerti()
        {

            listDormVerti = DormDatabase.GetAllListDorm();
            listViewVerti.ItemsSource = listDormVerti;
            
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewVerti.ItemsSource);
            view.Filter = DormFilter;

        }

        private void listViewVerti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dorm dorm = listViewVerti.SelectedItem as Dorm;

            layoutMainDorm.Children.Clear();
            TransitioningContentSlide.OnApplyTemplate();
            layoutMainDorm.VerticalAlignment = VerticalAlignment.Top;
            layoutMainDorm.HorizontalAlignment = HorizontalAlignment.Left;
            layoutMainDorm.Width = 1150;
            layoutMainDorm.Height = 720;
            layoutMainDorm.Children.Add(new ShowDorm(dorm,user,0));
        }

       private bool DormFilter(Object item)
        {
            if (String.IsNullOrEmpty(searchQuery.Text)) return true;
            else return ((item as Dorm).Address.IndexOf(searchQuery.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void searchQuery_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listViewVerti.ItemsSource).Refresh();
        }

        private void listViewHori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dorm dorm = listViewHori.SelectedItem as Dorm;
            layoutMainDorm.Children.Clear();
            TransitioningContentSlide.OnApplyTemplate();
            layoutMainDorm.VerticalAlignment = VerticalAlignment.Top;
            layoutMainDorm.HorizontalAlignment = HorizontalAlignment.Left;
            layoutMainDorm.Width = 1150;
            layoutMainDorm.Height = 720;
            layoutMainDorm.Children.Add(new ShowDorm(dorm,user,0));
        }

        private void cbOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int a = cbOptions.SelectedIndex;
            switch (a)
            {
                case 0: listDormVerti = DormDatabase.GetAllListDormNew(); listViewVerti.ItemsSource = listDormVerti ; break;
                case 1: listDormVerti = DormDatabase.GetAllListDormIncreasingPrice(); listViewVerti.ItemsSource = listDormVerti ; break;
                case 2: listDormVerti = DormDatabase.GetAllListDormDecreasingPrice(); listViewVerti.ItemsSource = listDormVerti ; break;
                case 3: listDormVerti = DormDatabase.GetAllListDormIncreasingBookTimes(); listViewVerti.ItemsSource = listDormVerti ; break;
                case 4: listDormVerti = DormDatabase.GetAllListDormDecreasingBookTimes(); listViewVerti.ItemsSource = listDormVerti ; break;
                case 5: listDormVerti = DormDatabase.GetAllListDormIncreasingLike(); listViewVerti.ItemsSource = listDormVerti ; break;
                case 6: listDormVerti = DormDatabase.GetAllListDormDecreasingLike(); listViewVerti.ItemsSource = listDormVerti ; break;
                case 7: listDormVerti = DormDatabase.GetAllListDormIncreasingRating(); listViewVerti.ItemsSource = listDormVerti ; break;
                case 8: listDormVerti = DormDatabase.GetAllListDormDecreasingRating(); listViewVerti.ItemsSource = listDormVerti ; break;
             
            }
            CollectionViewSource.GetDefaultView(listViewVerti.ItemsSource).Refresh();
        }
    }
}
