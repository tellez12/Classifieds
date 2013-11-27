using System;
using System.Data;
using System.Linq;
using Classifieds.Domain.Abstract;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.EF
{
    public class EFItemRepository : EFBaseRepository, IItemRepository
    {
        public IQueryable<Item> GetItems
        {
            get { return db.Items; }
        }

        public Item GetItem(int id)
        {
            return db.Items.Find(id);
        }

        public Message Create(Item Item)
        {
            try
            {
                db.Items.Add(Item);
                db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating", Item.GetType()));
            }
        }

        public Message Update(Item Item)
        {
            try
            {
                db.Entry(Item).State = EntityState.Modified;
                db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing ", Item.GetType()));
            }
        }

        public Message Delete(int id)
        {
            Item Item = GetItem(id);
            try
            {
                db.Items.Remove(Item);
                db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Deleting", Item.GetType()));
            }
        }
    }
}