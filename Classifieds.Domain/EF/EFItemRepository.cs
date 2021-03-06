﻿using System;
using System.Data.Entity;
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
            get { return Db.Items; }
        }

        public Item GetItem(int id)
        {
            return Db.Items.Find(id);
        }

        public Message Create(Item item)
        {
            try
            {
                Db.Items.Add(item);
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Creating {0}", item.GetType()));
            }
        }

        public Message Edit(Item item)
        {
            try
            {
                Db.Entry(item).State = EntityState.Modified;
                Db.SaveChanges();
                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Editing {0}", item.GetType()));
            }
        }

        public Message Delete(int id)
        {
            var item = GetItem(id);
            try
            {
                Db.Items.Remove(item);
                Db.SaveChanges();

                return new Message();
            }
            catch (Exception e)
            {
                return new Message(e, string.Format("Error Deleting {0}", item.GetType()));
            }
        }
    }
}