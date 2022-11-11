using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Core.Exceptions
{
    public class TaskNotFoundException: Exception
    {
        public TaskNotFoundException(): base("Task not found. "){}    
    }
}
