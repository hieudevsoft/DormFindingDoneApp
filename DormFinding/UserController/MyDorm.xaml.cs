using DormFinding.Database;
using DormFinding.Models;
using DormFinding.Utils;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for MyDorm.xaml
    /// </summary>
    public partial class MyDorm : UserControl
    {
        public List<Dorm> listDormVerti = new List<Dorm>();

        public string NameOwner
        {
            get { return (string)GetValue(NameOwnerProperty); }
            set { SetValue(NameOwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameOwner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameOwnerProperty =
            DependencyProperty.Register("NameOwner", typeof(string), typeof(MyDorm), new PropertyMetadata(""));


        public BitmapImage ImageOwner
                
        {
            get { return (BitmapImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("ImageOwner", typeof(BitmapImage), typeof(MyDorm), new PropertyMetadata(new BitmapImage(new System.Uri($"../../images/blank_account.png",System.UriKind.RelativeOrAbsolute))));



        private List<BookDorm> list;
        private User owner;
        public MyDorm(User user)
        {
            InitializeComponent();
            owner = user;
            initState();
            initOwner();
            setUpListViewVerti();
        }
        private void initOwner()
        {

                UserProfile profile = ProfileDatabase.GetProfile(owner);
                NameOwner = "Hello " + profile.Name;
                if(profile.Avatar!=null)
                ImageOwner = Helpers.ConvertByteToImageBitmap(profile.Avatar);
        }
        private void initState()
        {
            list = BookDatabase.GetAllWattingBook(owner.Email,true);
            if (list.Count != 0)
            {
                notifyMyDorm.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                notifyMyDorm.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void btnNotify_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            layoutControl.Children.Clear();
            TransitioningContentSlide.OnApplyTemplate();
            layoutControl.Children.Add(new ScreenBooking(list));
        }
        private void setUpListViewVerti()
        {

            listDormVerti = OwnerDormDatabase.GetAllListDormOwner(owner.Email);
            listViewVerti.ItemsSource = listDormVerti;

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
                layoutMainDorm.Children.Add(new ShowDorm(dorm, owner,1));
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            layoutMainDorm.Children.Clear();
            TransitioningContentSlide.OnApplyTemplate();
            layoutMainDorm.VerticalAlignment = VerticalAlignment.Top;
            layoutMainDorm.HorizontalAlignment = HorizontalAlignment.Left;
            layoutMainDorm.Height = 720;
            layoutMainDorm.Children.Add(new MyDorm(owner));
        }

        private void btnDormWating_Click(object sender, RoutedEventArgs e)
        {
            layoutControl.Children.Clear();
            TransitioningContentSlide.OnApplyTemplate();
            layoutControl.Children.Add(new WaittingScreen(BookDatabase.GetAllWattingBook(owner.Email,false)));
        }
    }
}
