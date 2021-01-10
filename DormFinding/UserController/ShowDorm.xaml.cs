using DormFinding.Classess;
using DormFinding.Database;
using DormFinding.Models;
using DormFinding.Utils;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DormFinding
{
    /// <summary>
    /// Interaction logic for ShowDorm.xaml
    /// </summary>




    public partial class ShowDorm : UserControl
    {
        private Dorm dorm;
        public BitmapImage ImageDorm
        {
            get { return (BitmapImage)GetValue(ImageDormProperty); }
            set { SetValue(ImageDormProperty, value); }
        }
        public static readonly DependencyProperty ImageDormProperty =
            DependencyProperty.Register("ImageDorm", typeof(BitmapImage), typeof(ShowDorm));
        public string OwnerDorm
        {
            get { return (string)GetValue(OwnerDormProperty); }
            set { SetValue(OwnerDormProperty, value); }
        }
        public static readonly DependencyProperty OwnerDormProperty =
            DependencyProperty.Register("OwnerDorm", typeof(string), typeof(ShowDorm));
        public string AddressDorm
        {
            get { return (string)GetValue(AddressDormProperty); }
            set { SetValue(AddressDormProperty, value); }
        }
        public static readonly DependencyProperty AddressDormProperty =
            DependencyProperty.Register("AddressDorm", typeof(string), typeof(ShowDorm));
        public string DesDorm
        {
            get { return (string)GetValue(DesDormProperty); }
            set { SetValue(DesDormProperty, value); }
        }
        public static readonly DependencyProperty DesDormProperty =
            DependencyProperty.Register("DesDorm", typeof(string), typeof(ShowDorm));
        public string PriceDorm
        {
            get { return (string)GetValue(PriceDormProperty); }
            set { SetValue(PriceDormProperty, value); }
        }
        public static readonly DependencyProperty PriceDormProperty =
            DependencyProperty.Register("PriceDorm", typeof(string), typeof(ShowDorm));
        public int QualityDorm
        {
            get { return (int)GetValue(QualityDormProperty); }
            set { SetValue(QualityDormProperty, value); }
        }
        public static readonly DependencyProperty QualityDormProperty =
            DependencyProperty.Register("QualityDorm", typeof(int), typeof(ShowDorm));
        public string CountDorm
        {
            get { return (string)GetValue(CountDormProperty); }
            set { SetValue(CountDormProperty, value); }
        }
        public static readonly DependencyProperty CountDormProperty =
            DependencyProperty.Register("CountDorm", typeof(string), typeof(ShowDorm), new PropertyMetadata("0"));
        public Visibility WifiDorm
        {
            get { return (Visibility)GetValue(WifiDormProperty); }
            set { SetValue(WifiDormProperty, value); }
        }
        public static readonly DependencyProperty WifiDormProperty =
            DependencyProperty.Register("WifiDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public Visibility ParkingDorm
        {
            get { return (Visibility)GetValue(ParkingDormProperty); }
            set { SetValue(ParkingDormProperty, value); }
        }
        public static readonly DependencyProperty ParkingDormProperty =
            DependencyProperty.Register("ParkingDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public Visibility TelevisionDorm
        {
            get { return (Visibility)GetValue(TelevisionDormProperty); }
            set { SetValue(TelevisionDormProperty, value); }
        }
        public static readonly DependencyProperty TelevisionDormProperty =
            DependencyProperty.Register("TelevisionDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public Visibility BathroomDorm
        {
            get { return (Visibility)GetValue(BathroomDormProperty); }
            set { SetValue(BathroomDormProperty, value); }
        }
        public static readonly DependencyProperty BathroomDormProperty =
            DependencyProperty.Register("BathroomDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public Visibility AirConditionerDorm
        {
            get { return (Visibility)GetValue(AirConditionerDormProperty); }
            set { SetValue(AirConditionerDormProperty, value); }
        }
        public static readonly DependencyProperty AirConditionerDormProperty =
            DependencyProperty.Register("AirConditionerDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public Visibility WaterHeaterDorm
        {
            get { return (Visibility)GetValue(WaterHeaterDormProperty); }
            set { SetValue(WaterHeaterDormProperty, value); }
        }
        public static readonly DependencyProperty WaterHeaterDormProperty =
            DependencyProperty.Register("WaterHeaterDorm", typeof(Visibility), typeof(ShowDorm), new PropertyMetadata(Visibility.Visible));
        public int CountLikeDorm
        {
            get { return (int)GetValue(CountLikeDormProperty); }
            set { SetValue(CountLikeDormProperty, value); }
        }
        public static readonly DependencyProperty CountLikeDormProperty =
            DependencyProperty.Register("CountLikeDorm", typeof(int), typeof(ShowDorm), new PropertyMetadata(0));


        public string SizeDorm
        {
            get { return (string)GetValue(SizeDormProperty); }
            set { SetValue(SizeDormProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SizeDorm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeDormProperty =
            DependencyProperty.Register("SizeDorm", typeof(string), typeof(ShowDorm), new PropertyMetadata("0"));



        private UserProfile owner;


        public BitmapImage ImageOwner
        {
            get { return (BitmapImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Image.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("ImageOwner", typeof(BitmapImage), typeof(ShowDorm), new PropertyMetadata(new BitmapImage(new Uri($"../../images/blank_account.png", UriKind.RelativeOrAbsolute))));


        public string NameOwner
        {
            get { return (string)GetValue(NameOwnerProperty); }
            set { SetValue(NameOwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameOwner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameOwnerProperty =
            DependencyProperty.Register("NameOwner", typeof(string), typeof(ShowDorm), new PropertyMetadata(""));



        public string PhoneOwner
        {
            get { return (string)GetValue(PhoneOwnerProperty); }
            set { SetValue(PhoneOwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PhoneOwner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PhoneOwnerProperty =
            DependencyProperty.Register("PhoneOwner", typeof(string), typeof(ShowDorm), new PropertyMetadata(""));
        public string AddressOwner
        {
            get { return (string)GetValue(AddressOwnerProperty); }
            set { SetValue(AddressOwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddressOwner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddressOwnerProperty =
            DependencyProperty.Register("AddressOwner", typeof(string), typeof(ShowDorm), new PropertyMetadata(""));



        public string GenderOwner
        {
            get { return (string)GetValue(GenderOwnerProperty); }
            set { SetValue(GenderOwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GenderOwner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GenderOwnerProperty =
            DependencyProperty.Register("GenderOwner", typeof(string), typeof(ShowDorm), new PropertyMetadata(""));

        private User user;

        private List<BookComment> listComment = new List<BookComment>();


        public int ValueRating
        {
            get { return (int)GetValue(ValueRatingProperty); }
            set { SetValue(ValueRatingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValueRating.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueRatingProperty =
            DependencyProperty.Register("ValueRating", typeof(int), typeof(ShowDorm));


        public string Comment
        {
            get { return (string)GetValue(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Comment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentProperty =
            DependencyProperty.Register("Comment", typeof(string), typeof(ShowDorm), new PropertyMetadata(""));

        private DispatcherTimer dispatcherTimer;

        byte handlerArrowLeft;

        public ShowDorm(Dorm dorm, User user, byte State)
        {
            handlerArrowLeft = State;
            InitializeComponent();
            this.user = user;
            this.dorm = dorm;
            TransitioningContentSlide.ApplyTemplate();
            initDorm();
            initProfile();
            initLike();
            initBookDorm();
            initComment();
            SetHover(iconSend);
        }

        private void initComment()
        {

            listComment = CommentDatabase.GetAllCommentBookDorm(owner.Email, dorm.Id);
            listViewComment.ItemsSource = listComment;
        }

        private void initDorm()
        {
            ImageDorm = dorm.Image;
            OwnerDorm = dorm.Owner;
            AddressDorm = dorm.Address;
            DesDorm = dorm.Description;
            PriceDorm = "$" + dorm.Price;
            QualityDorm = dorm.Quality;
            CountDorm = "+" + dorm.Count.ToString();
            WifiDorm = dorm.IsWifi;
            ParkingDorm = dorm.IsParking;
            TelevisionDorm = dorm.IsTelevision;
            BathroomDorm = dorm.IsBathroom;
            AirConditionerDorm = dorm.IsAirCondiditioner;
            WaterHeaterDorm = dorm.IsWaterHeater;
            CountLikeDorm = dorm.CountLike;
            SizeDorm = $"Area: {dorm.Size} m²";

        }
        private void initProfile()
        {
            owner = OwnerDormDatabase.GetOwnerProfileOfDorm(dorm.Id);
            ImageOwner = Helpers.ConvertByteToImageBitmap(owner.Avatar);
            NameOwner = owner.Name;
            PhoneOwner = owner.Phone;
            AddressOwner = owner.Address;
            lbEmail.Content = owner.Email;
            GenderOwner = Helpers.ConvertByteToGender(owner.Gender);

        }

        private void initLike()
        {
            try
            {
                Boolean click = LikeDatabase.GetStateLike(user.Email, dorm.Id);
                if (click) likeIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E34853"));
            }
            catch (Exception e)
            {

            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TransitioningContentSlide.ApplyTemplate();
            layoutDorm.Children.Clear();
            layoutDorm.VerticalAlignment = VerticalAlignment.Top;
            layoutDorm.HorizontalAlignment = HorizontalAlignment.Left;
            layoutDorm.Width = 1150;
            layoutDorm.Height = 720;

            if (handlerArrowLeft == 0) layoutDorm.Children.Add(new HomeControl(user));
            else if (handlerArrowLeft == 1) layoutDorm.Children.Add(new MyDorm(user));
            else if (handlerArrowLeft == 2) layoutDorm.Children.Add(new MyDorm(BookDatabase.GetUserDorm(user.Email, dorm.Id)));
            else layoutDorm.Children.Add(new LikedDorm(LikeDatabase.GetAllListDormByEmail(user.Email), user));
        }
        private void AnimationLikeOpacity()
        {
            Panel.SetZIndex(like, 1);
            DoubleAnimation a = new DoubleAnimation();
            a.From = 0;
            a.To = 1;
            a.AutoReverse = true;
            a.Duration = TimeSpan.FromSeconds(1);
            like.BeginAnimation(OpacityProperty, a);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(TimerOnTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void TimerOnTick(object sender, EventArgs e)
        {
            Panel.SetZIndex(like, 0);
            dispatcherTimer.Stop();
        }
        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                    if (LikeDatabase.Insert(user.Email, dorm.Id, 1))
                    {
                        AnimationLikeOpacity();
                        likeIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E34853"));
                        CountLikeDorm++;
                        dorm.CountLike++;
                        DormDatabase.UpdateLikeDorm(dorm);
                    }
                    else
                    {
                        
                        bool click = LikeDatabase.GetStateLike(user.Email, dorm.Id);
                        if (!click)
                        {   
                            likeIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E34853"));
                            CountLikeDorm++;
                            dorm.CountLike++;
                            AnimationLikeOpacity();
                            DormDatabase.UpdateLikeDorm(dorm);
                            LikeDatabase.Update(user.Email, dorm.Id, 1);
                        }
                        else
                        {
                            likeIcon.Foreground = new SolidColorBrush(Colors.Gray);
                            CountLikeDorm--;
                            if (CountLikeDorm == -1)
                            {
                            LikeDatabase.DeleteById(dorm.Id);
                            CountLikeDorm = 0;
                            }
                            dorm.CountLike = CountLikeDorm;
                            DormDatabase.UpdateLikeDorm(dorm);
                            LikeDatabase.Update(user.Email, dorm.Id, 0);
                        }
                       
                    }


                }
            catch (Exception exec)
            {
                MessageBox.Show("Error while processing Like....");
            }


        }
        private void SetAnimationForIconMove(PackIcon icon)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 1;
            animation.To = 0.5;
            animation.Duration = TimeSpan.FromSeconds(0.05);
            icon.BeginAnimation(OpacityProperty, animation);
        }

        private void SetAnimationForIconLeave(PackIcon icon)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0.5;
            animation.To = 1;
            animation.Duration = TimeSpan.FromSeconds(0.05);
            icon.BeginAnimation(OpacityProperty, animation);
        }
        private void SetHover(PackIcon icon)
        {
            icon.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                SetAnimationForIconMove(icon);

            };
            icon.MouseLeave += delegate (object sender, MouseEventArgs e)
            {
                SetAnimationForIconLeave(icon);

            };
        }
        private void initBookDorm()
        {
            try
            {
                    BookDorm bookDorm = new BookDorm();
                    bookDorm.EmailOwner = owner.Email;
                    bookDorm.EmailUser = user.Email;
                    bookDorm.IdDorm = dorm.Id;
                    bookDorm.StateDorm = 1;

                    bookDorm = BookDatabase.GetItem(bookDorm);
                    if (bookDorm.StateDorm == 0)
                    {
                        spinnerBook.Visibility = Visibility.Collapsed;
                        btnBooked.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2DCA73"));
                        btnBooked.IsEnabled = true;
                    }
                    else if (bookDorm.StateDorm == 1)
                    {
                        spinnerBook.Visibility = Visibility.Visible;
                        btnBooked.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A2D8E9"));
                        btnBooked.IsEnabled = true;
                    }
                    else
                    {
                        spinnerBook.Visibility = Visibility.Collapsed;
                        btnBooked.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F0F0F0"));
                        btnBooked.IsCancel = true;
                    }
                    lbStateBook.Content = Helpers.ConvertStateToText(bookDorm.StateDorm);
                }
            finally
            {

            }
        }
        private void btnBooked_Click(object sender, RoutedEventArgs e)
        {
            if (user.Email.Equals(owner.Email))
            {
                Helpers.MakeErrorMessage(Window.GetWindow(this), "You are owner so can't book dorm", "Error");
            }
            else if(!BookDatabase.GetEmailBookDorm(owner.Email,dorm.Id).Equals("No"))
            {

                if (BookDatabase.GetEmailBookDorm(owner.Email, dorm.Id).Equals(user.Email))
                {
                    Helpers.MakeConfirmMessage(Window.GetWindow(this), "Dorm was booked by you" , "Notify");
                } else
                Helpers.MakeErrorMessage(Window.GetWindow(this), "Dorm was booked by " + BookDatabase.GetEmailBookDorm(owner.Email, dorm.Id), "Error");
            }
            else {
                BookDorm bookDorm = new BookDorm();
                bookDorm.EmailOwner = owner.Email;
                bookDorm.EmailUser = user.Email;
                bookDorm.IdDorm = dorm.Id;
                bookDorm.StateDorm = 1;
                if (BookDatabase.Insert(bookDorm))
                {
                    spinnerBook.Visibility = Visibility.Visible;
                    btnBooked.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A2D8E9"));
                    lbStateBook.Content = "Booking...";
                }
                else
                {
                    bookDorm = BookDatabase.GetItem(bookDorm);
                    if (bookDorm.StateDorm == 0)
                    {
                        spinnerBook.Visibility = Visibility.Visible;
                        btnBooked.IsEnabled = true;
                        btnBooked.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A2D8E9"));
                        bookDorm.StateDorm = 1;
                        BookDatabase.Update(bookDorm);
                    }
                    else if (bookDorm.StateDorm == 1)
                    {
                        spinnerBook.Visibility = Visibility.Collapsed;
                        btnBooked.IsEnabled = true;
                        btnBooked.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2DCA73"));
                        bookDorm.StateDorm = 0;
                        BookDatabase.Update(bookDorm);
                    }
                    lbStateBook.Content = Helpers.ConvertStateToText(bookDorm.StateDorm);
                }
            }
        }

        private void btnComment_Click(object sender, RoutedEventArgs e)
        {
            if (user.Email.Equals(owner.Email))
            {
                Helpers.MakeErrorMessage(Window.GetWindow(this), "You are owner so can't rating", "Error");
            }
            else
            {
                if (BookDatabase.GetEmailBookDorm(owner.Email, dorm.Id).Equals(user.Email))
                {
                    ValueRating = ratingBar.Value;
                    Comment = tbComment.Text.Trim();
                    if (ValueRating == 0)
                    {
                        Helpers.MakeErrorMessage(Window.GetWindow(this), "You must rating dorm " , "Error");
                    }
                    else
                    {
                        if (CommentDatabase.Insert(owner.Email, dorm.Id, user.Email, Comment, ValueRating))
                        {
                            Helpers.MakeConfirmMessage(Window.GetWindow(this), "Thanks you bro", "Notify");
                            if (CommentDatabase.GetAvgRating(owner.Email, dorm.Id) != -1)
                            {
                                DormDatabase.UpdateRating(dorm.Id, CommentDatabase.GetAvgRating(owner.Email, dorm.Id));
                                dorm.Quality = (dorm.Quality + ValueRating) / DormDatabase.GetCount(dorm.Id);
                                MainControl mainControl = (MainControl)Window.GetWindow(this);
                                mainControl.MainHomeLayout.Children.Clear();
                                mainControl.MainHomeLayout.VerticalAlignment = VerticalAlignment.Top;
                                mainControl.MainHomeLayout.HorizontalAlignment = HorizontalAlignment.Left;
                                mainControl.MainHomeLayout.Width = 1150;
                                mainControl.MainHomeLayout.Height = 720;
                                mainControl.MainHomeLayout.Children.Add(new ShowDorm(dorm, user,1));
                            }
                            
                        }
                        else
                        {
                            Helpers.MakeErrorMessage(Window.GetWindow(this), "You already rating this dorm", "Error");
                        }
                    }
                }
                else
                    Helpers.MakeErrorMessage(Window.GetWindow(this), "You can't comment because you have never book this dorm", "Error");
            }
        }
    }
}
