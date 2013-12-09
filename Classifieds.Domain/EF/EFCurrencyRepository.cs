using System;
using System.Data.Entity;
using System.Linq;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.EF
{
    public class EFCurrencyRepository : EFBaseRepository, ICurrencyRepository
    {
        public IQueryable<Currency> GetCurrencies
        {
            get { return Db.Currencies; }
        }

        public Currency GetCurrency(int id)
        {
            return Db.Currencies.Find(id);
        }

        public Message Create(Currency currency)
        {
            try
            {
                Db.Currencies.Add(currency);
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating {0}", currency.GetType()));
            }
        }

        public Message Edit(Currency currency)
        {
            try
            {
                Db.Entry(currency).State = EntityState.Modified;
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing {0}", currency.GetType()));
            }
        }

        public Message Delete(int id)
        {
            Currency currency = GetCurrency(id);
            try
            {
                Db.Currencies.Remove(currency);
                Db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Deleting {0}", currency.GetType()));
            }
        }
    }
}