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
    public class EFSectionRepository : EFBaseRepository, ISectionRepository
    {

        public IQueryable<Section> GetSections
        {
            get { return db.Sections; }
        }

        public Section GetSection(int id)
        {
            return db.Sections.Find(id);
        }

        public Message Create(Section Section)
        {
            try
            {
                db.Sections.Add(Section);
                db.SaveChanges();
                return new Message();

            }
            catch (Exception e)
            {

                return new Message(e, string.Format("Error Creating", Section.GetType()));
            }

        }

        public Message Edit(Section Section)
        {
            try
            {
                db.Entry(Section).State = EntityState.Modified;
                db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {

                return new Message(e, string.Format("Error Editing ", Section.GetType()));
            }
        }

        public Message Delete(int id)
        {
            Section Section = GetSection(id);
            try
            {

                db.Sections.Remove(Section);
                db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {

                return new Message(e, string.Format("Error Deleting", Section.GetType()));
            }
        }

    }
}
