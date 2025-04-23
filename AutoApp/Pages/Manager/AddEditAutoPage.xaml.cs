using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEditAutoPage.xaml
    /// </summary>
    public partial class AddEditAutoPage : Page
    {
        public Data.Auto _currentAuto = new Data.Auto();
        public string flag = "default";
        public bool FlagPhoto = false;
        public AddEditAutoPage(Data.Auto _selectedAuto)
        {
            InitializeComponent();

            if (_selectedAuto != null)
            {
                _currentAuto = _selectedAuto;
                flag = "edit";
            }
            else
            {
                flag = "add";
            }

            DataContext = _currentAuto;

            Init();
        }

        public void Init()
        {
            try
            {
                TypeOfDriveUnitComboBox.ItemsSource = Data.CarsDBEntities.GetContext().TypeDriveUnit.ToList();
                ModelComboBox.ItemsSource = Data.CarsDBEntities.GetContext().Model.ToList();
                BrandComboBox.ItemsSource = Data.CarsDBEntities.GetContext().Brand.ToList();

                if (flag == "edit")
                {
                    TypeOfDriveUnitComboBox.SelectedItem = Data.CarsDBEntities.GetContext().TypeDriveUnit.Where(d => d.Id == _currentAuto.IdTypeDriveUnit).FirstOrDefault();
                    ModelComboBox.SelectedItem = Data.CarsDBEntities.GetContext().Model.Where(d => d.Id == _currentAuto.IdModel).FirstOrDefault();
                    BrandComboBox.SelectedItem = Data.CarsDBEntities.GetContext().Brand.Where(d => d.Id == _currentAuto.IdBrand).FirstOrDefault();
                    YearTextBox.Text = _currentAuto.YearOfCreate.ToString();
                    MileageTextBox.Text = _currentAuto.Mileage.ToString();
                    VinNumberTextBox.Text = _currentAuto.VinNumber;
                    PriceTextBox.Text = _currentAuto.Price.ToString();
                    DescriptionTextBox.Text = _currentAuto.Description;
                    EngineTextBox.Text = _currentAuto.Engine;
                    OwnersTextBox.Text = _currentAuto.Owners.ToString();
                    if (_currentAuto.Status == false) StatusCheckBox.IsChecked = false;
                    if (_currentAuto.Status == true) StatusCheckBox.IsChecked = true;
                    FlagPhoto = true;
                } else if (flag == "add")
                {
                    TypeOfDriveUnitComboBox.SelectedItem = null;
                    ModelComboBox.SelectedItem = null;
                    BrandComboBox.SelectedItem = null;
                    YearTextBox.Text = string.Empty;
                    MileageTextBox.Text = string.Empty;
                    VinNumberTextBox.Text = string.Empty;
                    PriceTextBox.Text = string.Empty;
                    DescriptionTextBox.Text = string.Empty;
                    EngineTextBox.Text = string.Empty;
                    OwnersTextBox.Text = string.Empty;
                    StatusCheckBox.IsChecked = false;
                    AutoImage.Source = new BitmapImage(new Uri("pack://application:,,,/AutoApp;component/Resources/image.jpg"));
                    FlagPhoto = false;
                }
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
                if (TypeOfDriveUnitComboBox.SelectedItem == null)
                {
                    errors.AppendLine("Выберите тип привода!");
                }
                if (ModelComboBox.SelectedItem == null)
                {
                    errors.AppendLine("Выберите модель!");
                }
                if (BrandComboBox.SelectedItem == null)
                {
                    errors.AppendLine("Выберите марку!");
                }
                if (string.IsNullOrEmpty(YearTextBox.Text))
                {
                    errors.AppendLine("Заполните год выпуска!");
                }
                else
                {
                    bool year = Int32.TryParse(YearTextBox.Text, out var resultYear);
                    if (year == false) errors.AppendLine("Заполните год выпуска корректно!");
                }
                if (string.IsNullOrEmpty(MileageTextBox.Text))
                {
                    errors.AppendLine("Заполните пробег!");
                }
                else
                {
                    bool mileage = decimal.TryParse(MileageTextBox.Text, out var resultMileage);
                    if (mileage == false) errors.AppendLine("Заполните пробег корректно!");
                }
                if (string.IsNullOrEmpty(VinNumberTextBox.Text))
                {
                    errors.AppendLine("Заполните ВИН номер!");
                }
                else
                {
                    if (VinNumberTextBox.Text.Length != 17) errors.AppendLine("Заполните ВИН номер корректно, 17 символов!");
                }
                if (string.IsNullOrEmpty(PriceTextBox.Text))
                {
                    errors.AppendLine("Заполните цену!");
                }
                else
                {
                    bool price = decimal.TryParse(PriceTextBox.Text, out var resultPrice);
                    if (price == false) errors.AppendLine("Заполните цену корректно!");
                }
                if (string.IsNullOrEmpty(EngineTextBox.Text))
                {
                    errors.AppendLine("Заполните мотор!");
                }
                if (string.IsNullOrEmpty(OwnersTextBox.Text))
                {
                    errors.AppendLine("Заполните владельцев!");
                }
                else
                {
                    bool owner = Int32.TryParse(OwnersTextBox.Text, out var resultOwner);
                    if (owner == false) errors.AppendLine("Заполните владельцев корректно!");
                }

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (flag == "add")
                {
                    _currentAuto.Description = DescriptionTextBox.Text;
                    _currentAuto.IdTypeDriveUnit = (TypeOfDriveUnitComboBox.SelectedItem as Data.TypeDriveUnit).Id;
                    _currentAuto.IdModel = (ModelComboBox.SelectedItem as Data.Model).Id;
                    _currentAuto.IdBrand = (BrandComboBox.SelectedItem as Data.Brand).Id;
                    _currentAuto.YearOfCreate = Convert.ToInt32(YearTextBox.Text);
                    _currentAuto.Mileage = Convert.ToDecimal(MileageTextBox.Text);
                    _currentAuto.VinNumber = VinNumberTextBox.Text;
                    _currentAuto.Price = Convert.ToDecimal(PriceTextBox.Text);
                    _currentAuto.Engine = EngineTextBox.Text;
                    _currentAuto.Owners = Convert.ToInt32(OwnersTextBox.Text);
                    _currentAuto.Status = false;

                    Data.CarsDBEntities.GetContext().Auto.Add(_currentAuto);
                    Data.CarsDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Успешно сохранено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    Init();
                }
                else if (flag == "edit")
                {
                    _currentAuto.Description = DescriptionTextBox.Text;
                    _currentAuto.IdTypeDriveUnit = (TypeOfDriveUnitComboBox.SelectedItem as Data.TypeDriveUnit).Id;
                    _currentAuto.IdModel = (ModelComboBox.SelectedItem as Data.Model).Id;
                    _currentAuto.IdBrand = (BrandComboBox.SelectedItem as Data.Brand).Id;
                    _currentAuto.YearOfCreate = Convert.ToInt32(YearTextBox.Text);
                    _currentAuto.Mileage = Convert.ToDecimal(MileageTextBox.Text);
                    _currentAuto.VinNumber = VinNumberTextBox.Text;
                    _currentAuto.Price = Convert.ToDecimal(PriceTextBox.Text);
                    _currentAuto.Engine = EngineTextBox.Text;
                    _currentAuto.Owners = Convert.ToInt32(OwnersTextBox.Text);
                    if (StatusCheckBox.IsChecked == true) _currentAuto.Status = true;
                    if (StatusCheckBox.IsChecked == false) _currentAuto.Status = false;

                    Data.CarsDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Успешно сохранено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AutoImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.png;*.jpeg;*.jpg;..";
                if (openFileDialog.ShowDialog() == true)
                {
                    if (File.Exists(openFileDialog.FileName))
                    {
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.UriSource = new Uri(openFileDialog.FileName);
                        bitmapImage.EndInit();

                        _currentAuto.Image = File.ReadAllBytes(openFileDialog.FileName);
                        AutoImage.Source = bitmapImage;
                        FlagPhoto = true;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
