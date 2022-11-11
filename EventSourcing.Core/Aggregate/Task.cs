using EventSourcing.Core.Events;
using EventSourcing.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Core.Aggregate
{
    public class Task: Aggregate
    {
        public string Title { get; private set; }
        public BoardSections Section { get; private set; }
        public string AssignedTo { get; private set; }
        public bool IsCompleted { get; private set; }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case CreatedTask x: OnCreated(x); break;
                case AssignedTask x: OnAssigned(x); break;
                case CompletedTask x: OnCompleted(x); break;
            }
        }

        public void Create(Guid taskId, string title, string createdBy)
        {
            if (Version >= 0)
            {
                throw new TaskAlreadyCreatedException();
            }

            Apply(new CreatedTask
            {
                TaskId = taskId,
                CreatedBy = createdBy,
                Title = title,
            });
        }

        public void Assign(string assignedTo, string assignedBy)
        {
            if(Version == 1)
            {
                throw new TaskNotFoundException();
            }
            if (IsCompleted)
            {
                throw new TaskCompletedException();
            }
            Apply(new AssignedTask
            {
                TaskId = Id,
                AssignedTo = assignedTo,
                AssignedBy = assignedBy,
            });
        }


        public void Complete(string completedBy)
        {
            if (Version == -1)
            {
                throw new TaskNotFoundException();
            }

            if (IsCompleted)
            {
                throw new TaskCompletedException();
            }

            Apply(new CompletedTask
            {
                TaskId = Id,
                CompletedBy = completedBy
            });
        }


        private void OnCreated(CreatedTask @event)
        {
            Id = @event.TaskId;
            Title = @event.Title;
            Section = BoardSections.Open;
        }

        private void OnAssigned(AssignedTask @event)
        {
            AssignedTo = @event.AssignedTo;
        }


        private void OnCompleted(CompletedTask @event)
        {
            IsCompleted = true;
        }
    }
}
