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

        Message Create(Currency currency);

        Message Edit(Currency currency);

        Message Delete(int id);
    }
}