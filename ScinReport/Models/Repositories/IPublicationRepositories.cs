using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScinReport.Models.Repositories
{
    public interface IPublicationRepositories
    {
        IQueryable<Publication> publications { get; }
    }
}
