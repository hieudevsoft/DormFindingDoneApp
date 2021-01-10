namespace DormFinding
{
    using DormFinding.Database;
    using System.Windows;
    using System.Windows.Input;


    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            User user = UserDatabase.CheckAccountAreadyInApp();
            if (user != null)
            {
                MainControl m = new MainControl(user,"");
                m.Show();
                Window.GetWindow(this).Hide();
            }
            else
            {

            }
        }
    }
   
}