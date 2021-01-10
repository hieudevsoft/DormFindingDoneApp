using DormFinding.Database;
using System.Windows;
using System.Windows.Controls;


namespace DormFinding
{
    /// <summary>
    /// Interaction logic for RowLayout.xaml
    /// </summary>
    public partial class RowLayout : UserControl
    {
        public RowLayout()
        {
            InitializeComponent();
            TransitioningContentSlide.OnApplyTemplate();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Dorm dorm = button.DataContext as Dorm;
            MessageBoxResult result = MessageBox.Show("Would you like to delete this dorm?", "Notify", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (DormDatabase.Delete(dorm.Id))
                    {
                        BookDatabase.DeleteByIdDorm(dorm.Id);
                        OwnerDormDatabase.DeleteByDormId(dorm.Id);
                        LikeDatabase.DeleteById(dorm.Id);
                        CommentDatabase.DeleteByIdDorm(dorm.Id);
                        MainControl mainControl = (MainControl)Window.GetWindow(this);
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Dorm dorm = button.DataContext as Dorm;
            MainControl mainControl = (MainControl)Window.GetWindow(this);
            mainControl.MainHomeLayout.Children.Clear();
            mainControl.MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
            mainControl.MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
            mainControl.MainHomeLayout.Width = 1150;
            mainControl.MainHomeLayout.Height = 720;
            mainControl.MainHomeLayout.Children.Add(new PostDorm(mainControl.user, dorm));
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Dorm dorm = button.DataContext as Dorm;
            MainControl mainControl = (MainControl)Window.GetWindow(this);
            MessageBoxResult result = MessageBox.Show("Would you like to reset this dorm?", "Notify", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (OwnerDormDatabase.Update(mainControl.user.Email,dorm.Id,0))
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
