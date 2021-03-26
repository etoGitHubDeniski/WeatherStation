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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        // Попытка добавить нового пользователя в БД
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbUserLoginRegister.Text != string.Empty && TxbUserNameRegister.Text != string.Empty &&
                    PsbPasswordRegister.Password != string.Empty && PsbPasswordConfirm.Password != string.Empty)
                {
                    if (PsbPasswordConfirm.Password == PsbPasswordRegister.Password)
                    {
                        User user1 = ControlClass.WeatherStationAuthorizationDataBase.User.FirstOrDefault(x => x.Login == TxbUserLoginRegister.Text);
                        if (user1 == null)
                        {
                            User user = new User()
                            {
                                Login = TxbUserLoginRegister.Text,
                                IdRole = 1,
                                Password = PsbPasswordConfirm.Password,
                                Name = TxbUserNameRegister.Text
                            };
                            ControlClass.WeatherStationAuthorizationDataBase.User.Add(user);
                            ControlClass.WeatherStationAuthorizationDataBase.SaveChanges();
                            MessageBox.Show("Данные сохранены");
                            Properties.Settings.Default.LoginRegRem = TxbUserLoginRegister.Text;
                            Properties.Settings.Default.PasRegRem = PsbPasswordConfirm.Password;
                            Properties.Settings.Default.LogicRegRem = true;
                            Properties.Settings.Default.Save();
                            ControlClass.FrameMain.Navigate(new LoginPage());
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                } 
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        // Возврат к странице авторизации
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            ControlClass.FrameMain.GoBack();
        }
    }
}
