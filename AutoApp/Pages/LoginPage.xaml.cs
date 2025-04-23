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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            try
            {
                LoginTextBox.Text = string.Empty;
                PasswordBox.Password = string.Empty;
            }
            catch (Exception)
            {

            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrEmpty(LoginTextBox.Text))
                {
                    errors.AppendLine("Заполните логин");
                }
                if (string.IsNullOrEmpty(PasswordBox.Password))
                {
                    errors.AppendLine("Заполните пароль");
                }

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (Data.CarsDBEntities.GetContext().User
                    .Any(d => d.Login == LoginTextBox.Text
                    && d.Password == PasswordBox.Password))
                {
                    var temp = (from obj in Data.CarsDBEntities.GetContext().User
                                join role in Data.CarsDBEntities.GetContext().UserRole on obj.IdUserRole equals role.Id
                                where obj.Login == LoginTextBox.Text && obj.Password == PasswordBox.Password
                                select new
                                {
                                    Id = obj.Id,
                                    IdUserRole = obj.IdUserRole,
                                    Login = obj.Login,
                                    Password = obj.Password,
                                    RoleId = role.Id,
                                    RoleName = role.RoleName
                                }).FirstOrDefault();

                    Classes.Manager.CurrentUser = Data.CarsDBEntities.GetContext().User
                    .Where(d => d.Login == LoginTextBox.Text
                    && d.Password == PasswordBox.Password).FirstOrDefault();

                    MessageBox.Show("Успешный вход!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

                    Init();

                    switch (temp.RoleName)
                    {
                        case "Клиент":
                            Classes.Manager.MainFrame.Navigate(new Pages.Client.LkPage());
                            break;
                        case "Менеджер":
                            Classes.Manager.MainFrame.Navigate(new Pages.Manager.LkPage());
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.RegPage());
        }
    }
}