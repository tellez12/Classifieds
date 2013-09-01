using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.EF
{
    public class EFFeatureRepository : EFBaseRepository, IFeatureRepository
    {

        public IQueryable<Feature> GetFeatures
        {
            get { return db.Features; }
        }

        public Feature GetFeature(int id)
        {
            return db.Features.Find(id);
        }

        public Message Create(Feature Feature)
        {
            try
            {
                db.Features.Add(Feature);
                db.SaveChanges();
                return new Message();

            }
            catch (Exception e)
            {

                return new Message(e, string.Format("Error Creating", Feature.GetType()));
            }

        }

        public Message Update(Feature Feature)
        {
            try
            {
                db.Entry(Feature).State = EntityState.Modified;
                db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {

                return new Message(e, string.Format("Error Editing ", Feature.GetType()));
            }
        }

        public Message Delete(int id)
        {
            Feature Feature = GetFeature(id);
            try
            {

                db.Features.Remove(Feature);
                db.SaveChanges();

                return new Message();
            }
            catch (Exception e)            {

                return new Message(e, string.Format("Error Deleting", Feature.GetType()));
            }
        }

    }
}
