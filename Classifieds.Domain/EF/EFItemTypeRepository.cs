using System;
using System.Data.Entity;
using System.Linq;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.EF
{
    public class EFItemTypeRepository : EFBaseRepository, IItemTypeRepository
    {
        public IQueryable<ItemType> GetItemTypes
        {
            get { return Db.ItemTypes; }
        }

        public ItemType GetItemType(int id)
        {
            return Db.ItemTypes.Find(id);
        }

        public Message Create(ItemType itemType)
        {
            try
            {
                Db.ItemTypes.Add(itemType);
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating {0}", itemType.GetType()));
            }
        }

        public Message Edit(ItemType itemType)
        {
            try
            {
                Db.Entry(itemType).State = EntityState.Modified;
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing {0}", itemType.GetType()));
            }
        }

        public Message Delete(int id)
        {
            var itemType = GetItemType(id);
            try
            {
                Db.ItemTypes.Remove(itemType);
                Db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Deleting {0}", itemType.GetType()));
            }
        }
    }
}