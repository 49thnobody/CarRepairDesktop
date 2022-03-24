using CarRepairDesktop.Model;
using System.Windows;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.CarModels
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var dbInstance = EntityModel.GetInstance();
            var CarModel = new CarModel();
            CarModel.Title = tbName.Text;
            dbInstance.CarModels.Add(CarModel); 
            dbInstance.SaveChanges();
            MessageBox.Show("Успешно");
            Navigator.Back();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Back();
        }
    }
}
