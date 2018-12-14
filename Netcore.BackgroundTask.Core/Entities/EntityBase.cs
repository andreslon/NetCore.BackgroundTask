using System;

namespace Netcore.BackgroundTask.Core.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        public EntityBase(Guid id)
        {
            Id = id;
        }
    }
}
