using System;

namespace Classifieds.Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal ExchangeRate { get; set; }
    }
}