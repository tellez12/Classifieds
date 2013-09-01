using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifieds.Domain.Utils;
using Classifieds.Domain.Entities;


namespace Classifieds.Domain.Abstract
{
    public interface ICurrencyRepository
    {
        IQueryable<Currency> GetCurrencies { get; }

        Currency GetCurrency(int id);
        Message Create(Currency Currency);
        Message Edit(Currency Currency);
        Message Delete(int id);
        
    }
}
