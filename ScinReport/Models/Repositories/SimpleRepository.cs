using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScinReport.Models.Repositories
{
    public class SimpleRepository:IRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<int, Publication> publications
        = new Dictionary<int, Publication>();
        public static SimpleRepository SharedRepository => sharedRepository;
        public SimpleRepository()
        {
            var initialItems = new[] {
                 new Publication  { Id = 1, TypeId = 12,Status="In Progress" },
                 new Publication { Id = 2, TypeId = 1,Status="In Progress" },
                 new Publication { Id = 3, TypeId = 13,Status="In Progress" },
                 new Publication { Id = 4, TypeId = 2,Status="In Progress" }
                 };
            foreach (var p in initialItems)
            {
                AddPublication(p);
            }
            publications.Add(-1, null);
        }
        public IEnumerable<Publication> Publications => publications.Values;
        public void AddPublication (Publication p) => publications.Add(p.Id, p);
    }
}
