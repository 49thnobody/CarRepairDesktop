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


        private Client _selectedClient;
        public Client SelectedClient { get => _selectedClient; set => _selectedClient = value; }

        public override string Check()
        {
            if (SelectedClient == null) return "Нет клиента для проверки.";
            StringBuilder errors = new StringBuilder();
            if (SelectedClient.DriversLicense.Length < 8 || !SelectedClient.DriversLicense.All(char.IsDigit))
                errors.AppendLine("Водительское удостоверение может содержать от 8 до 12 цифр.");
            if (SelectedClient.FullName.Length > 50)
                errors.AppendLine("Размер поля ФИО превышен (50 символов).");
            if (string.IsNullOrEmpty(SelectedClient.FullName))
                errors.AppendLine("ФИО не указано.");
            else if (SelectedClient.FullName.Split(' ').Length < 2)
                errors.AppendLine("Фио казано неполностью (требуется хотя бы фамилия и имя).");
            if (string.IsNullOrEmpty(SelectedClient.Phone))
                errors.AppendLine("Телефон не указан.");
            else if (SelectedClient.Phone.Length!=11)
                errors.AppendLine("Размер поля Телефон не соблюден (11 символов).");
            else if (!SelectedClient.Phone.All(char.IsDigit))
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
                _dbInstance.Clients.Add(SelectedClient);
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
                _dbInstance.Clients.Remove(SelectedClient);
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
