using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace Wpf_TimeCraft_Calendar_IlayBiton
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private User user;
        public LoginWindow()
        {
            InitializeComponent();
            user = new User();
            this.DataContext = user;
        }

        private void ShowPassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            image.Source = new BitmapImage(new Uri(@"Media\show-password.png", UriKind.Relative));
            pbPass.Visibility = Visibility.Collapsed;
            tbPass.Text = pbPass.Password.ToString();
            tbPass.Visibility = Visibility.Visible;
        }

        private void HidePassword_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            image.Source = new BitmapImage(new Uri(@"Media\hide-password.png", UriKind.Relative));
            pbPass.Focus();
            pbPass.Visibility = Visibility.Visible;
            tbPass.Visibility = Visibility.Collapsed;
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidPassword validPassword = new ValidPassword();
            ValidationResult result = validPassword.Validate(((PasswordBox)sender).Password, CultureInfo.CurrentCulture);
            if (!result.IsValid) // result not valid
            {
                errPass.Text = result.ErrorContent.ToString();
                pbPass.ToolTip = result.ErrorContent;
                pbPass.BorderThickness = new Thickness(1);
                tbPass.BorderThickness = new Thickness(1);
            }
            else // result is valid
            {
                errPass.Text = string.Empty;
                pbPass.ToolTip = string.Empty;
                pbPass.BorderThickness = new Thickness(0);
                tbPass.BorderThickness = new Thickness(0);
                user.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
