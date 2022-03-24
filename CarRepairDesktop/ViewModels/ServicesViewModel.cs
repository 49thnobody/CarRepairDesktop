using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRepairDesktop.ViewModels
{
    public class ServicesViewModel : ViewModel
    {
        public List<Service> Entities { get => _dbInstance.Services.ToList(); }

        public List<Service> SortedEntities { get => _sortedEntities; set => Set(ref _sortedEntities, value); }

        private List<Service> _sortedEntities;


        private Service _selectedEntity;
        public Service SelectedEntity { get => _selectedEntity; set => _selectedEntity = value; }
        public Mode Mode { get; set; }

        public override string Check()
        {
            if (SelectedEntity == null) return "Нет услуги для проверки.";
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(SelectedEntity.Title))
                errors.AppendLine("Название услуги не введено.");

            if (SelectedEntity.Price < 0)
                errors.AppendLine("Стоимость услуги не может быть отрицательной.");

            if (errors.Length > 0)
                return errors.ToString();
            return string.Empty;
        }

        public override string Add()
        {
            var check = Check();
            if (check != string.Empty) return check;

            try
            {
                _dbInstance.Services.Add(SelectedEntity);
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
                _dbInstance.Services.Remove(SelectedEntity);
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно удалена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static ServicesViewModel _instance;
        public static ServicesViewModel GetInstance()
        {
            if (_instance == null) _instance = new ServicesViewModel();
            return _instance;
        }
        public ServicesViewModel()
        {
            SortedEntities = Entities;
        }
    }
}
