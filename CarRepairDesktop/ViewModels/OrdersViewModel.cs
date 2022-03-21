using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRepairDesktop.ViewModels
{
    public class OrdersViewModel : ViewModel
    {
        public List<Order> Entities { get => _dbInstance.Orders.ToList(); }

        public List<Order> SortedEntities { get => _sortedEntities; set => Set(ref _sortedEntities, value); }

        private List<Order> _sortedEntities;


        private Order _selectedOrder;
        public Order SelectedOrder { get => _selectedOrder; set => _selectedOrder = value; }

        public override string Check()
        {
            if (SelectedOrder == null) return "Нет заказа для проверки.";
            StringBuilder errors = new StringBuilder();

            if (SelectedOrder.PlannedEndDate == null)
                errors.AppendLine("Плановая дата окончания не указана.");

            if (SelectedOrder.Services.Count == 0)
                errors.AppendLine("В заказе нет услуг.");

            if (errors.Length > 0)
                return errors.ToString();
            return string.Empty;
        }

        public override string Add()
        {
            var check = Check();
            if (check != string.Empty) return check;

            SelectedOrder.StartDate = DateTime.Now;

            try
            {
                _dbInstance.Orders.Add(SelectedOrder);
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно добавлена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public override string Edit()
        {
            var check = Check();
            if (check != string.Empty) return check;

            try
            {
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно изменена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public override string Delete()
        {
            try
            {
                _dbInstance.Orders.Remove(SelectedOrder);
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно удалена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
