using System;
using System.Data.Entity;
using System.Linq;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.EF
{
    public class EFSectionRepository : EFBaseRepository, ISectionRepository
    {
        public IQueryable<Section> GetSections
        {
            get { return Db.Sections; }
        }

        public Section GetSection(int id)
        {
            return Db.Sections.Find(id);
        }

        public Message Create(Section section)
        {
            try
            {
                Db.Sections.Add(section);
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating {0}", section.GetType()));
            }
        }

        public Message Edit(Section section)
        {
            try
            {
                Db.Entry(section).State = EntityState.Modified;
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing {0}", section.GetType()));
            }
        }

        public Message Delete(int id)
        {
            Section section = GetSection(id);
            try
            {
                Db.Sections.Remove(section);
                Db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Deleting {0}", section.GetType()));
            }
        }
    }
}