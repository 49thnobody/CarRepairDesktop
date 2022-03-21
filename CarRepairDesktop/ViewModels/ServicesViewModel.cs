﻿using CarRepairDesktop.Model;
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


        private Service _selectedService;
        public Service SelectedService { get => _selectedService; set => _selectedService = value; }

        public override string Check()
        {
            if (SelectedService == null) return "Нет услуги для проверки.";
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(SelectedService.Title))
                errors.AppendLine("Название услуги не введено.");

            if (SelectedService.Price < 0)
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
                _dbInstance.Services.Add(SelectedService);
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
                _dbInstance.Services.Remove(SelectedService);
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