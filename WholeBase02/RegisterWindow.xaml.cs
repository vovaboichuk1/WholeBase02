using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WholeBase02
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        AppContext db;

        public RegisterWindow()
        {
            InitializeComponent();

            db = new AppContext();
        }

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void ThemToogle_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
                LabelName.Foreground = Brushes.Black;
                LabelName1.Foreground = Brushes.Black;
                LabelName2.Foreground = Brushes.Black;
                LabelName3.Foreground = Brushes.Black;
                LabelName4.Foreground = Brushes.Black;
                LabelName5.Foreground = Brushes.Black;

            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
                LabelName.Foreground = Brushes.White;
                LabelName1.Foreground = Brushes.White;
                LabelName2.Foreground = Brushes.White;
                LabelName3.Foreground = Brushes.White;
                LabelName4.Foreground = Brushes.White;
                LabelName5.Foreground = Brushes.White;
            }
            paletteHelper.SetTheme(theme);
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private void Button_Enter_Auth_Account_Click(object sender, RoutedEventArgs e)
        {

            MainWindow authWindow = new MainWindow();
            authWindow.Show();
            Hide();
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxUserName.Text;
            string password = TextBoxPassword.Password;


            if (name.Length < 4)
            {
                TextBoxUserName.ToolTip = "Мінімум 4 символи";
                TextBoxUserName.Background = Brushes.IndianRed;
            }
            else if (password.Length < 6)
            {
                TextBoxPassword.ToolTip = "Мінімум 6 символів";
                TextBoxPassword.Background = Brushes.IndianRed;
            }
            else
            {
                TextBoxUserName.ToolTip = "";
                TextBoxUserName.Background = Brushes.Transparent;

                TextBoxPassword.ToolTip = "";
                TextBoxPassword.Background = Brushes.Transparent;

                User user = new User(name, password);
                db.Users.Add(user);
                db.SaveChanges();

                MainWindow authWindow = new MainWindow();
                authWindow.Show();
                Hide();
                //fgdgfgfgfgf
            }
        }
    }
}
