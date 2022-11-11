using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Core.Aggregate
{
    internal interface ITaskReposiroty
    {
        Task<bool> CreateTaskAsync(Task task);
        Task<bool> ComplateTaskAsync(Task task);
    }
}
