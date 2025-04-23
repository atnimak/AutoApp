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
    /// Логика взаимодействия для ViewOrderPage.xaml
    /// </summary>
    public partial class ViewOrderPage : Page
    {
        public ViewOrderPage()
        {
            InitializeComponent();

            Init();
        }
        public void Init()
        {
            try
            {
                var id = Classes.Manager.CurrentUser.Id;
                OrdersDataGrid.ItemsSource = Data.CarsDBEntities.GetContext().Order
                    .Where(d => d.IdClient == id).ToList();
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
    }
}
