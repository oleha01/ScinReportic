using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScinReport.Models.Repositories
{
    interface IRepository
    {
        IEnumerable<Publication> Publications { get; }
        void AddPublication (Publication p);
    }
}
