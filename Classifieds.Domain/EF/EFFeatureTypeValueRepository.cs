using System;
using System.Data.Entity;
using System.Linq;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.EF
{
    public class EFFeatureTypeValueRepository : EFBaseRepository, IFeatureTypeValueRepository
    {
        public IQueryable<FeatureTypeValue> GetFeatureTypeValues
        {
            get { return Db.FeatureTypeValues.Include("Section"); }
        }

        public FeatureTypeValue GetFeatureTypeValue(int id)
        {
            return Db.FeatureTypeValues.Find(id);
        }

        public Message Create(FeatureTypeValue value)
        {
            try
            {
                Db.FeatureTypeValues.Add(value);
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating {0}", value.GetType()));
            }
        }

        public Message Edit(FeatureTypeValue featureTypeValue)
        {
            try
            {
                Db.Entry(featureTypeValue).State = EntityState.Modified;
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing {0}", featureTypeValue.GetType()));
            }
        }

        public Message Delete(int id)
        {
            FeatureTypeValue value = GetFeatureTypeValue(id);
            try
            {
                Db.FeatureTypeValues.Remove(value);
                Db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Deleting {0}", value.GetType()));
            }
        }
    }
}