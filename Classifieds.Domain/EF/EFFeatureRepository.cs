using System;
using System.Data.Entity;
using System.Linq;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.EF
{
    public class EFFeatureRepository : EFBaseRepository, IFeatureRepository
    {
        public IQueryable<Feature> GetFeatures
        {
            get { return Db.Features; }
        }

        public Feature GetFeature(int id)
        {
            return Db.Features.Find(id);
        }

        public Message Create(Feature feature)
        {
            try
            {
                Db.Features.Add(feature);
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating {0}", feature.GetType()));
            }
        }

        public Message Update(Feature feature)
        {
            try
            {
                Db.Entry(feature).State = EntityState.Modified;
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing {0}", feature.GetType()));
            }
        }

        public Message Delete(int id)
        {
            Feature feature = GetFeature(id);
            try
            {
                Db.Features.Remove(feature);
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