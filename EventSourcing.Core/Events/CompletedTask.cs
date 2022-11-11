using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Core.Events
{
    public class CompletedTask
    {
        public Guid TaskId { get; set; }
        public string CompletedBy { get; set; }
    }
}
