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
            get { return db.Currencies; }
        }

        public Currency GetCurrency(int id)
        {
            return db.Currencies.Find(id);
        }

        public Message Create(Currency Currency)
        {
            try
            {
                db.Currencies.Add(Currency);
                db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating", Currency.GetType()));
            }
        }

        public Message Edit(Currency Currency)
        {
            try
            {
                db.Entry(Currency).State = EntityState.Modified;
                db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing ", Currency.GetType()));
            }
        }

        public Message Delete(int id)
        {
            Currency Currency = GetCurrency(id);
            try
            {
                db.Currencies.Remove(Currency);
                db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Deleting", Currency.GetType()));
            }
        }
    }
}