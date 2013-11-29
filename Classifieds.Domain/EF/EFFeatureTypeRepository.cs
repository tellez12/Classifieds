using System;
using System.Data.Entity;
using System.Linq;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.EF
{
    public class EFFeatureTypeRepository : EFBaseRepository, IFeatureTypeRepository
    {
        public IQueryable<FeatureType> GetFeatureTypes
        {
            get { return db.FeatureTypes.Include("Section"); }
        }

        public FeatureType GetFeatureType(int id)
        {
            return db.FeatureTypes.Find(id);
        }

        public Message Create(FeatureType Feature)
        {
            try
            {
                db.FeatureTypes.Add(Feature);
                db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating", Feature.GetType()));
            }
        }

        public Message Edit(FeatureType FeatureType)
        {
            try
            {
                db.Entry(FeatureType).State = EntityState.Modified;
                db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing ", FeatureType.GetType()));
            }
        }

        public Message Delete(int id)
        {
            FeatureType Feature = GetFeatureType(id);
            try
            {
                db.FeatureTypes.Remove(Feature);
                db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Deleting", Feature.GetType()));
            }
        }
    }
}