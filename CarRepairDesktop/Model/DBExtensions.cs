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
                Dictionary<int, int> ranksCount = new Dictionary<int, int>();

                foreach (var rank in ranks.Distinct().ToList())
                    ranksCount.Add(rank, 0);

                foreach (var rank in ranks)
                    ranksCount[rank]++;

                int mostCommonRank = ranksCount[ranks[0]];
                foreach (var rank in ranksCount)
                {
                    if (rank.Value > ranksCount[mostCommonRank])
                        mostCommonRank = rank.Key;
                }

                return mostCommonRank;
            }
        }
    }
}
