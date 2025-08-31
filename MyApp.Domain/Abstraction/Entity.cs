using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Abstraction
{
    public abstract class Entities
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
    }
}
