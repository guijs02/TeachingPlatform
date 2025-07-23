using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Shared;

namespace TeachingPlatform.Domain.Entities
{
    public abstract class Entity(Guid id)
    {
        public readonly Notification Notification = new();
        public Guid Id { get; set; } = id;
    }
}
