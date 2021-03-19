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
using WeatherStation.AppData;

namespace WeatherStation.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            // Вставка логина и пароля при запуске приложения
            if (Properties.Settings.Default.LoginRemember != string.Empty)
            {
                TxbLoginLogin.Text = Properties.Settings.Default.LoginRemember;
                PsbPasswordLogin.Password = Properties.Settings.Default.PasswordRemember;
                ChbRemember.IsChecked = true;
            }
            else
            {
                TxbLoginLogin.Text = Properties.Settings.Default.LoginRemember;
                PsbPasswordLogin.Password = Properties.Settings.Default.PasswordRemember;
                ChbRemember.IsChecked = false;
            }
        }

        // Попытка найти пользователя в БД
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = ControlClass.WeatherStationAuthorizationDataBase.User.FirstOrDefault(x => x.Login == TxbLoginLogin.Text && x.Password == PsbPasswordLogin.Password);
                if (user != null)
                {
                    MessageBox.Show("Вы вошли");
                }
                else
                {
                    MessageBox.Show("Пользователя не существует");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка входа");
            }
        }

        // Переход к регистрации нового пользователя
        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            ControlClass.FrameMain.Navigate(new AuthorizationPage());
        }

        // Сохранение введенных данных
        private void ChbRemember_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LoginRemember = TxbLoginLogin.Text;
            Properties.Settings.Default.PasswordRemember = PsbPasswordLogin.Password;
            Properties.Settings.Default.Save();
        }

        private void ChbRemember_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LoginRemember = string.Empty;
            Properties.Settings.Default.PasswordRemember = string.Empty;
            Properties.Settings.Default.Save();
        }
    }
}
