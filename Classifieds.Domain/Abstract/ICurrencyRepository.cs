using System;
using System.Linq;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

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