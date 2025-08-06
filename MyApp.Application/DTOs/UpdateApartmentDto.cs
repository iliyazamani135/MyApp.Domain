using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Entities;

namespace MyApp.Application.DTOs
{
    public class UpdateApartmentDto
    {
        public string Subject { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public decimal PricePerNight { get; set; }
        public string Title { get; set; }
    }
}
