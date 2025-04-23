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

                if (selectedType != null && selectedType.NameTypeDriveUnit != "Все приводы")
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

        private void AddAutoButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.Manager.AddEditAutoPage(null));
        }

        private void DeleteAutoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = AutoDataGrid.SelectedItem as Data.Auto;
                var tempCheckFK = Data.CarsDBEntities.GetContext().Order.Where(d => d.IdAuto == selected.Id).FirstOrDefault();
                if (tempCheckFK != null)
                {
                    var yesNo = MessageBox.Show($"Эта машина числится в заказах, вы точно хотите удалить авто и связанный заказ?", "Внимание!",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (yesNo == MessageBoxResult.Yes)
                    {
                        Data.CarsDBEntities.GetContext().Order.Remove(tempCheckFK);
                        Data.CarsDBEntities.GetContext().SaveChanges();
                    }
                }
                if (tempCheckFK == null)
                {
                    Data.CarsDBEntities.GetContext().Auto.Remove(selected);
                    Data.CarsDBEntities.GetContext().SaveChanges();
                }
                MessageBox.Show($"Успешно удалено!", "Успех!",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditAutoButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.Manager.AddEditAutoPage((sender as Button).DataContext as Data.Auto));
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.Manager.OrderPage());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Init();
        }
    }
}
