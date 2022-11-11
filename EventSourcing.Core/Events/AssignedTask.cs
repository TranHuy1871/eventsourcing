using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Core.Events
{
    public class AssignedTask
    {
        public Guid TaskId { get; set; }
        public string AssignedBy { get; set; }
        public string AssignedTo { get; set; }
    }
}
