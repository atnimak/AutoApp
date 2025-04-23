using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace AutoApp.Pages.Manager
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();

            Init();
        }
        public void Init()
        {
            try
            {
                var id = Classes.Manager.CurrentUser.Id;
                OrdersDataGrid.ItemsSource = Data.CarsDBEntities.GetContext().Order.ToList();
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

        private void EditAutoButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.Manager.EditOrderPage((sender as Button).DataContext as Data.Order));
        }

        private void DeleteAutoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = OrdersDataGrid.SelectedItem as Data.Order;
                var auto = selected.IdAuto;
                Data.CarsDBEntities.GetContext().Order.Remove(selected);
                Data.CarsDBEntities.GetContext().SaveChanges();
                var autoObj = Data.CarsDBEntities.GetContext().Auto.Where(d => d.Id == selected.IdAuto).FirstOrDefault();
                autoObj.Status = false;
                MessageBox.Show($"Успешно удалено!", "Успех!",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void GenerateExcel(DataTable dataTable, string fileName)
        {
            try
            {
                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(dataTable);

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add(System.Reflection.Missing.Value);

                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = workbook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                foreach (DataTable table in dataSet.Tables)
                {
                    Microsoft.Office.Interop.Excel.Worksheet excelWorkSheet = workbook.Sheets.Add();
                    excelWorkSheet.Name = table.TableName;

                    for (int i = 1; i < table.Columns.Count + 1; i++)
                    {
                        excelWorkSheet.Cells[1, 1].Font.Bold = true;
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)excelWorkSheet.Cells[1, i + 1];
                        excelWorkSheet.Cells[1, i + 1].Font.Bold = true;
                        excelWorkSheet.Columns[i + 1].ColumnWidth = 20;

                        excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                    }

                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        for (int k = 0; k < table.Columns.Count; k++)
                        {
                            excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                        }
                    }
                }

                string filePath = string.Empty;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.FileName = "Folder Selection.";
                if (openFileDialog.ShowDialog() == true)
                {
                    filePath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);

                    workbook.SaveAs(filePath + $"\\{fileName}.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault,
                        System.Type.Missing, System.Type.Missing, true, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                        Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, System.Type.Missing, System.Type.Missing);

                    MessageBox.Show("Файл успешно сохранён в выбранной папке!", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
                    excelApp.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Wait;
                GenerateExcel(CreateDT(), "PKSK");
                Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public DataTable CreateDT()
        {
            DataTable dt = new DataTable();

            try
            {
                try
                {
                    dt.TableName = "Заказы";

                    dt.Columns.Add("Id", typeof(string));
                    dt.Columns.Add("ФИО клиента", typeof(string));
                    dt.Columns.Add("ФИО менеджера", typeof(string));
                    dt.Columns.Add("Дата заказа", typeof(string));
                    dt.Columns.Add("Привод", typeof(string));
                    dt.Columns.Add("Модель", typeof(string));
                    dt.Columns.Add("Марка", typeof(string));
                    dt.Columns.Add("Год выпуска", typeof(string));
                    dt.Columns.Add("Пробег", typeof(string));
                    dt.Columns.Add("ВИН", typeof(string));
                    dt.Columns.Add("Цена", typeof(string));
                    dt.Columns.Add("Описание", typeof(string));
                    dt.Columns.Add("Мотор", typeof(string));
                    dt.Columns.Add("Собственники", typeof(string));
                    dt.Columns.Add("Статус", typeof(string));
                    
                    for (int i = 0; i < Data.CarsDBEntities.GetContext().Order.ToList().Count(); i++)
                    {
                        string descr = string.Empty;
                        try
                        {
                            if (Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.Description != null)
                            {
                                descr = Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.Description;
                            }
                        }
                        catch (Exception)
                        {

                        }

                        string fioManager = string.Empty;
                        try
                        {
                            if (Data.CarsDBEntities.GetContext().Order.ToList()[i].User1 != null)
                            {
                                fioManager = Data.CarsDBEntities.GetContext().Order.ToList()[i].User1.SecondName + " " +
                                             Data.CarsDBEntities.GetContext().Order.ToList()[i].User1.FirstName + " " +
                                             Data.CarsDBEntities.GetContext().Order.ToList()[i].User1.ThirdName;
                            }
                        }
                        catch (Exception)
                        {

                        }

                        string status = string.Empty;
                        if (Data.CarsDBEntities.GetContext().Order.ToList()[i].Status == true) status = "Закрыт";
                        if (Data.CarsDBEntities.GetContext().Order.ToList()[i].Status == false) status = "Открыт";

                        DataRow myDataRow = dt.NewRow();

                        myDataRow["Id"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].Id.ToString();
                        myDataRow["ФИО клиента"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].User.SecondName + " " + 
                            Data.CarsDBEntities.GetContext().Order.ToList()[i].User.FirstName + " " + 
                            Data.CarsDBEntities.GetContext().Order.ToList()[i].User.ThirdName;
                        myDataRow["ФИО менеджера"] = fioManager;
                        myDataRow["Дата заказа"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].DateOfSale;
                        myDataRow["Привод"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.TypeDriveUnit.NameTypeDriveUnit;
                        myDataRow["Модель"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.Model.NameOfModel;
                        myDataRow["Марка"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.Brand.NameOfBrand;
                        myDataRow["Год выпуска"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.YearOfCreate;
                        myDataRow["Пробег"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.Mileage;
                        myDataRow["ВИН"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.VinNumber;
                        myDataRow["Цена"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.Price;
                        myDataRow["Мотор"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.Engine;
                        myDataRow["Собственники"] = Data.CarsDBEntities.GetContext().Order.ToList()[i].Auto.Owners;
                        myDataRow["Статус"] = status;

                        dt.Rows.Add(myDataRow);
                    }
                }
                catch (Exception)
                {

                }
                return dt;
            }
            catch (Exception)
            {

            }

            return dt;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Init();
        }
    }
}