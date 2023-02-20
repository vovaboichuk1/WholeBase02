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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WholeBase02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void Create_a_new_account_Click(object sender, RoutedEventArgs e)
        {

            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Hide();

        }

        private void Enter_account_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow masterWindow = new MasterWindow();
            masterWindow.Show();
            Hide();

        }
    }
}
