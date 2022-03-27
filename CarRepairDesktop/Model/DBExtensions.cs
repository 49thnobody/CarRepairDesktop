using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CarRepairDesktop.Model
{
    public partial class EntityModel : DbContext
    {
        private static EntityModel _instance;

        public static EntityModel GetInstance()
        {
            if (_instance == null)
                _instance = new EntityModel();

            return _instance;
        }
    }

    public partial class Service
    {
        public int CommonRank
        {
            get
            {
                List<int> ranks = Orders.ToList().ConvertAll(p => p.Employee.Rank);
                if (ranks.Count == 0) return 1;
                Dictionary<int, int> ranksCount = new Dictionary<int, int>();

                foreach (var rank in ranks.Distinct().ToList())
                    ranksCount.Add(rank, 0);

                foreach (var rank in ranks)
                    ranksCount[rank]++;

                int mostCommonRank = ranks[0];
                foreach (var rank in ranksCount)
                {
                    if (rank.Value > ranksCount[mostCommonRank])
                        mostCommonRank = rank.Key;
                }

                return mostCommonRank;
            }
        }
    }

    public partial class Employee
    {
        private List<Order> OrdersOldCars { get => Orders.ToList().FindAll(p => (p.Car.ManufactureYear ?? DateTime.Now.Year) <= 1939); }

        public int OldCarsOrdersCount { get => OrdersOldCars.Count; }
    }

    public partial class CarModel
    {
        public List<Order> DelayedOrders
        {
            get
            {
                var cars = Cars.ToList();

                List<Order> orders = new List<Order>();

                foreach (var car in cars)
                {
                    orders.AddRange(car.Orders);
                }

                orders = orders.FindAll(p => p.RealEndDate > p.PlannedEndDate);

                return orders;
            }
        }
    }

    public partial class Client
    {
        public Employee MyMaster
        {
            get
            {
                var cars = Cars.ToList();

                var orders = new List<Order>();

                foreach (var car in cars)
                {
                    orders.AddRange(car.Orders);
                }

                var emps = orders.ConvertAll(p => p.Employee);
                emps = emps.Distinct().ToList();
                if (emps.Count == 0) return null;
                if(emps.Count == 1) return emps[0];
                return null;
            }
        }
    }
}
