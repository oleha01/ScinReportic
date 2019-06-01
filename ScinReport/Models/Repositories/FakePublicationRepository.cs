using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScinReport.Models.Repositories
{
    public class FakePublicationRepository:IPublicationRepositories
    {
        public IQueryable<Publication> publications => new List<Publication> {
         new Publication  { Id = 1, TypeId = 12,Status="In Progress" },
                 new Publication { Id = 2, TypeId = 1,Status="In Progress" },
                 new Publication { Id = 3, TypeId = 13,Status="In Progress" },
                 new Publication { Id = 4, TypeId = 2,Status="In Progress" }
         }.AsQueryable<Publication>();

        
    }
}
