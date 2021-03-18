using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiLesson.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
