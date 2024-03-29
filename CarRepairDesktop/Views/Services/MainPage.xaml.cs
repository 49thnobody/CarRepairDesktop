﻿using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace CarRepairDesktop.Views.Services
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private static ServicesViewModel context;
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            context.Mode = Mode.Edit;
            Navigator.Move(new AddEditPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                MessageBox.Show(context.Delete());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            context.SelectedEntity = new Service(); 
            context.Mode = Mode.Add;
            Navigator.Move(new AddEditPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            context = ServicesViewModel.GetInstance();
            DataContext = context;
        }
    }
}
