using AutoApp.Data;
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

namespace AutoApp.Pages.Client
{
    /// <summary>
    /// Логика взаимодействия для LkPage.xaml
    /// </summary>
    public partial class LkPage : Page
    {
        public LkPage()
        {
            InitializeComponent();

            Init();
        }
        public void Init()
        {
            try
            {
                AutoDataGrid.ItemsSource = Data.CarsDBEntities.GetContext().Auto.Where(d => d.Status == false).ToList();

                var drive = Data.CarsDBEntities.GetContext().TypeDriveUnit.ToList();
                drive.Insert(0, new Data.TypeDriveUnit { NameTypeDriveUnit = "Все приводы" });

                var brand = Data.CarsDBEntities.GetContext().Brand.ToList();
                brand.Insert(0, new Data.Brand { NameOfBrand = "Все бренды" });

                TypeDriveUnitComboBox.ItemsSource = drive;
                BrandComboBox.ItemsSource = brand;
                TypeDriveUnitComboBox.SelectedIndex = 0;
                BrandComboBox.SelectedIndex = 0;
            }
            catch (Exception)
            {

            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.Manager.MainFrame.CanGoBack)
            {
                Classes.Manager.CurrentUser = null;
                Classes.Manager.MainFrame.GoBack();
            }
        }

        List<Data.Auto> autos = Data.CarsDBEntities.GetContext().Auto.Where(d => d.Status == false).ToList();
        public void Update()
        {
            try
            {
                autos = Data.CarsDBEntities.GetContext().Auto.Where(d => d.Status == false).ToList();

                var selectedType = TypeDriveUnitComboBox.SelectedItem as Data.TypeDriveUnit;
                var selectedBrand = BrandComboBox.SelectedItem as Data.Brand;

                if (selectedType!= null && selectedType.NameTypeDriveUnit != "Все приводы")
                {
                    autos = autos.Where(d => d.IdTypeDriveUnit == selectedType.Id).ToList();
                }

                if (selectedBrand != null && selectedBrand.NameOfBrand != "Все бренды")
                {
                    autos = autos.Where(d => d.IdBrand == selectedBrand.Id).ToList();
                }

                AutoDataGrid.ItemsSource = autos;
            }
            catch (Exception)
            {

            }
        }

        private void BrandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void TypeDriveUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.Client.ViewOrderPage());
        }

        private void NewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = (sender as Button).DataContext as Data.Auto;
                var dt = DateTime.Now.Date;
                var id = Classes.Manager.CurrentUser.Id;
                Data.Order order = new Data.Order
                {
                    IdClient = id,
                    IdAuto = selected.Id,
                    DateOfSale = dt,
                    Status = false
                };
                Data.CarsDBEntities.GetContext().Order.Add(order);
                Data.CarsDBEntities.GetContext().SaveChanges();
                selected.Status = true;
                Data.CarsDBEntities.GetContext().SaveChanges();
                MessageBox.Show($"Заказ успешно оформлен\nНомер заказа: {order.Id}", "Успех!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
