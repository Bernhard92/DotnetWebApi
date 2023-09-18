using SUKiiServer.Domain.Common.BaseClasses;

namespace SUKiiServer.Domain.Entities
{
    public class TodoItem : BaseAuditableEntity
    {
        public string Name { get; internal set;  }
        public bool IsComplete { get; internal set;  }

        private TodoItem(string name, bool isComplete)
        {
            Name = name;
            IsComplete = isComplete;
            Id = Guid.NewGuid();
            CreatedBy = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            ModifiedBy = Guid.NewGuid();
            ModifiedAt = DateTime.UtcNow;
        }

        public static TodoItem Create(string name)
        {
            return new TodoItem(name, false);
        }

        public void CompleteTodo()
        {
            IsComplete = true;
        }

        public void ResetTodo()
        {
            IsComplete = false;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
