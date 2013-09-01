using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classifieds.Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
