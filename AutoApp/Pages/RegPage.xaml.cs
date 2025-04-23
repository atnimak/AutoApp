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

namespace AutoApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            try
            {
                FIOTextBox.Text = string.Empty;
                LoginTextBox.Text = string.Empty;
                PhoneNumberBox.Text = string.Empty;
                EmailTextBox.Text = string.Empty;
                LoginTextBox.Text = string.Empty;
                PasswordBox.Password = string.Empty;
            }
            catch (Exception)
            {

            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.Manager.MainFrame.CanGoBack)
            {
                Classes.Manager.MainFrame.GoBack();
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
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
                if (string.IsNullOrEmpty(PhoneNumberBox.Text))
                {
                    errors.AppendLine("Заполните номер телефона");
                }
                if (string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    errors.AppendLine("Заполните эл.почту");
                }
                if (string.IsNullOrEmpty(FIOTextBox.Text))
                {
                    errors.AppendLine("Заполните ФИО");
                }
                else
                {
                    string[] fio0 = FIOTextBox.Text.Split(' ');
                    if (fio0.Length != 3) errors.AppendLine("Заполните ФИО корректно");
                }
                if (!string.IsNullOrEmpty(LoginTextBox.Text)
                    && Data.CarsDBEntities.GetContext().User.Any(d => d.Login == LoginTextBox.Text))
                {
                    errors.AppendLine("Такой логин уже занят");
                }

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string[] fio = FIOTextBox.Text.Split(' ');

                Data.User user = new Data.User()
                {
                    Login = LoginTextBox.Text,
                    PhoneNumber = PhoneNumberBox.Text,
                    Email = EmailTextBox.Text,
                    SecondName = fio[0],
                    FirstName = fio[1],
                    ThirdName = fio[2],
                    Password = PasswordBox.Password,
                    IdUserRole = 1
                };
                Data.CarsDBEntities.GetContext().User.Add(user);
                Data.CarsDBEntities.GetContext().SaveChanges();

                MessageBox.Show("Успешная регистрация!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

                Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}