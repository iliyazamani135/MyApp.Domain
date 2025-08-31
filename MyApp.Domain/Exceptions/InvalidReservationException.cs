using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Exceptions
{
    public class InvalidReservationException : Exception
    {
        public InvalidReservationException(string message) : base(message) { }
    }
}
