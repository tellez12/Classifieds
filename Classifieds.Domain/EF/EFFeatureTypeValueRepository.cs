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
    public class EFFeatureTypeValueRepository : EFBaseRepository, IFeatureTypeValueRepository
    {

        public IQueryable<FeatureTypeValue> GetFeatureTypeValues
        {
            get { return db.FeatureTypeValues.Include("Section"); }
        }

        public FeatureTypeValue GetFeatureTypeValue(int id)
        {
            return db.FeatureTypeValues.Find(id);
        }

        public Message Create(FeatureTypeValue Value)
        {
            try
            {
                db.FeatureTypeValues.Add(Value);
                db.SaveChanges();
                return new Message();

            }
            catch (Exception e)
            {

                return new Message(e, string.Format("Error Creating", Value.GetType()));
            }

        }

        public Message Edit(FeatureTypeValue FeatureTypeValue)
        {
            try
            {
                db.Entry(FeatureTypeValue).State = EntityState.Modified;
                db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {

                return new Message(e, string.Format("Error Editing ", FeatureTypeValue.GetType()));
            }
        }

        public Message Delete(int id)
        {
            FeatureTypeValue Value = GetFeatureTypeValue(id);
            try
            {

                db.FeatureTypeValues.Remove(Value);
                db.SaveChanges();

                return new Message();
            }
            catch (Exception e)            {

                return new Message(e, string.Format("Error Deleting", Value.GetType()));
            }
        }

    }
}
