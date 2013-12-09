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
            get { return Db.FeatureTypes.Include("Section"); }
        }

        public FeatureType GetFeatureType(int id)
        {
            return Db.FeatureTypes.Find(id);
        }

        public Message Create(FeatureType feature)
        {
            try
            {
                Db.FeatureTypes.Add(feature);
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating {0}", feature.GetType()));
            }
        }

        public Message Edit(FeatureType featureType)
        {
            try
            {
                Db.Entry(featureType).State = EntityState.Modified;
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing {0}", featureType.GetType()));
            }
        }

        public Message Delete(int id)
        {
            FeatureType feature = GetFeatureType(id);
            try
            {
                Db.FeatureTypes.Remove(feature);
                Db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Deleting {0}", feature.GetType()));
            }
        }
    }
}