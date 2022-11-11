using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Core.Events
{
    public class CreatedTask
    {
        public Guid TaskId { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
    }
}
