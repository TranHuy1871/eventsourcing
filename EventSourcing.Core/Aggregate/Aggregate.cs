﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Core.Aggregate
{
    public abstract class Aggregate
    {
        readonly IList<object> _changes = new List<object>();
        public Guid Id { get; set; } = Guid.Empty;
        public long Version { get; set; } = -1;
        protected abstract void When(object @event);
        public void Apply(object @event)
        {
            When(@event);
            _changes.Add(@event);   
        }
        public void Load(long version, IEnumerable<object> history)
        {
            Version = version;
            foreach (var item in history)
            {
                When(item);
            }
        }
        public object[] GetChanges() => _changes.ToArray();
    }
}
