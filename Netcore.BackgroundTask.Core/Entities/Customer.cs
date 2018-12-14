using System;

namespace Netcore.BackgroundTask.Core.Entities
{
    public class Customer : EntityBase
    {
        public Customer() : base() { }
        public Customer(Guid id) : base(id) { }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{Name} {LastName}";

    }
}
