using CarRepairDesktop.Model;
using CarRepairDesktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRepairDesktop.ViewModels
{
    public class ClientsViewModel : ViewModel
    {
        public List<Client> Entities { get => _dbInstance.Clients.ToList(); }

        public List<Client> SortedEntities { get => _sortedEntities; set => Set(ref _sortedEntities, value); }

        private List<Client> _sortedEntities;


        private Client _selectedEntity;
        public Client SelectedEntity { get => _selectedEntity; set => _selectedEntity = value; }

        public override string Check()
        {
            if (SelectedEntity == null) return "Нет клиента для проверки.";
            StringBuilder errors = new StringBuilder();
            if (SelectedEntity.DriversLicense.Length < 8 || !SelectedEntity.DriversLicense.All(char.IsDigit))
                errors.AppendLine("Водительское удостоверение может содержать от 8 до 12 цифр.");
            if (SelectedEntity.FullName.Length > 50)
                errors.AppendLine("Размер поля ФИО превышен (50 символов).");
            if (string.IsNullOrEmpty(SelectedEntity.FullName))
                errors.AppendLine("ФИО не указано.");
            else if (SelectedEntity.FullName.Split(' ').Length < 2)
                errors.AppendLine("Фио казано неполностью (требуется хотя бы фамилия и имя).");
            if (string.IsNullOrEmpty(SelectedEntity.Phone))
                errors.AppendLine("Телефон не указан.");
            else if (SelectedEntity.Phone.Length!=11)
                errors.AppendLine("Размер поля Телефон не соблюден (11 символов).");
            else if (!SelectedEntity.Phone.All(char.IsDigit))
                errors.AppendLine("Телефон должен содержать только цифры.");

            if(errors.Length > 0)
                return errors.ToString();
            return string.Empty;
        }

        public override string Add()
        {
            var check = Check();
            if(check != string.Empty) return check;

            try
            {
                _dbInstance.Clients.Add(SelectedEntity);
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
                _dbInstance.Clients.Remove(SelectedEntity);
                _dbInstance.SaveChanges();
                SortedEntities = Entities;
                return "Запись успешно удалена.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static ClientsViewModel _instance;
        public static ClientsViewModel GetInstance()
        {
            if (_instance == null) _instance = new ClientsViewModel();
            return _instance;
        }
        public ClientsViewModel()
        {
            SortedEntities = Entities;
        }
    }
}
