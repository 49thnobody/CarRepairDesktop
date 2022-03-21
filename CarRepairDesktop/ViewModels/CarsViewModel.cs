using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CarRepairDesktop.ViewModels
{
    public class CarsViewModel : ViewModel
    {
        public List<Car> Entities { get => _dbInstance.Cars.ToList(); }

        public List<Car> SortedEntities { get => _sortedEntities; set => Set(ref _sortedEntities, value); }

        private List<Car> _sortedEntities;


        private Car _selectedCar;
        public Car SelectedCar { get => _selectedCar; set => _selectedCar = value; }

        public override string Check()
        {
            if (SelectedCar == null) return "Нет машины для проверки.";
            StringBuilder errors = new StringBuilder();

            Regex regex = new Regex("\\w\\d{3}\\w{2}");
            var matches = regex.Matches(SelectedCar.CarNumber);
            if (matches.Count == 0)
                errors.AppendLine("Невалидный номер машины. (Пример B909NM)");

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
                _dbInstance.Cars.Add(SelectedCar);
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
                _dbInstance.Cars.Remove(SelectedCar);
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
