using System;

namespace Domain
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
        public virtual int Version { get; set; }
    }
}