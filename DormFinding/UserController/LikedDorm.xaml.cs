using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace DormFinding
{
    
    public partial class LikedDorm : UserControl
    {
        private List<Dorm> listDorm;
        private User user;
        public LikedDorm(List<Dorm> list,User user)
        {
            listDorm = list;
            this.user = user;
            InitializeComponent();
            TransitioningContentSlide.OnApplyTemplate();
            setUpListViewHori();
        }
        private void setUpListViewHori()
        {
           
            listViewHori.ItemsSource = listDorm;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewHori.ItemsSource);
            view.Filter = DormFilter;
        }
        private bool DormFilter(Object item)
        {
            if (String.IsNullOrEmpty(searchQuery.Text)) return true;
            else return ((item as Dorm).Owner.IndexOf(searchQuery.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void searchQuery_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(listViewHori.ItemsSource).Refresh();
        }

        private void listViewHori_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dorm dorm = listViewHori.SelectedItem as Dorm;
            layoutMainDorm.Children.Clear();
            TransitioningContentSlide1.OnApplyTemplate();
            layoutMainDorm.VerticalAlignment = VerticalAlignment.Top;
            layoutMainDorm.HorizontalAlignment = HorizontalAlignment.Left;
            layoutMainDorm.Width = 1150;
            layoutMainDorm.Height = 720;
            layoutMainDorm.Children.Add(new ShowDorm(dorm,user,3));
        }
    }
}
