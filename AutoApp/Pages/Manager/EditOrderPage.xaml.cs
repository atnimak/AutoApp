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

namespace AutoApp.Pages.Manager
{
    /// <summary>
    /// Логика взаимодействия для EditOrderPage.xaml
    /// </summary>
    public partial class EditOrderPage : Page
    {
        public Data.Order _currentOrder = new Data.Order();
        public EditOrderPage(Data.Order _order)
        {
            InitializeComponent();

            _currentOrder = _order;
            DataContext = _currentOrder;

            Init();
        }

        public void Init()
        {
            try
            {
                var client = Data.CarsDBEntities.GetContext().User
                    .Where(j => j.IdUserRole == 1).ToList();
                List<string> clientList = client.ConvertAll<string>(d => d.Id + " " + d.SecondName + " " + d.FirstName + " " + d.ThirdName);
                ClientComboBox.ItemsSource = clientList;

                var manager = Data.CarsDBEntities.GetContext().User
                    .Where(j => j.IdUserRole == 2).ToList();
                List<string> managerList = manager.ConvertAll<string>(d => d.Id + " " + d.SecondName + " " + d.FirstName + " " + d.ThirdName);
                ManagerComboBox.ItemsSource = managerList;

                //AutoComboBox.ItemsSource = Data.CarsDBEntities.GetContext().Auto.ToList();

                int selectedIndexClient = clientList.FindIndex(s => s.Contains(_currentOrder.IdClient.ToString()));
                ClientComboBox.SelectedIndex = selectedIndexClient;

                if (_currentOrder.IdManager != null)
                {
                    int selectedIndexManager = managerList.FindIndex(s => s.Contains(_currentOrder.IdManager.ToString()));
                    ManagerComboBox.SelectedIndex = selectedIndexManager;
                }

                //AutoComboBox.SelectedItem = Data.CarsDBEntities.GetContext().Auto.Where(d => d.Id == _currentOrder.IdAuto).FirstOrDefault();
                if (_currentOrder.Status == false) StatusCheckBox.IsChecked = false;
                if (_currentOrder.Status == true) StatusCheckBox.IsChecked = true;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (ClientComboBox.SelectedItem == null)
                {
                    errors.AppendLine("Выберите клиента!");
                }
                //if (AutoComboBox.SelectedItem == null)
                //{
                //    errors.AppendLine("Выберите авто!");
                //}

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var selectedClient = ClientComboBox.SelectedItem;
                var idClient = Convert.ToInt32(selectedClient.ToString().Substring(0, selectedClient.ToString().IndexOf(' ')));
                var client = Data.CarsDBEntities.GetContext().User.Where(d => d.Id == idClient).FirstOrDefault();
                _currentOrder.IdClient = client.Id;

                if (ManagerComboBox.SelectedItem != null)
                {
                    var selectedManager = ManagerComboBox.SelectedItem;
                    var idManager = Convert.ToInt32(selectedManager.ToString().Substring(0, selectedManager.ToString().IndexOf(' ')));
                    var manager = Data.CarsDBEntities.GetContext().User.Where(d => d.Id == idManager).FirstOrDefault();
                    _currentOrder.IdManager = manager.Id;
                }

                if (StatusCheckBox.IsChecked == false) _currentOrder.Status = false;
                if (StatusCheckBox.IsChecked == true) _currentOrder.Status = true;

                //var autoSelected = AutoComboBox.SelectedItem as Data.Auto;
                //var auto = Data.CarsDBEntities.GetContext().Auto.Where(d => d.Id == autoSelected.Id).FirstOrDefault();
                //_currentOrder.IdAuto = auto.Id;

                Data.CarsDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно сохранено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
