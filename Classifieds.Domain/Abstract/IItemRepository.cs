using System;
using System.Linq;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.Abstract
{
    public interface IItemRepository
    {
        IQueryable<Item> GetItems { get; }

        Item GetItem(int id);

        Message Create(Item item);

        Message Edit(Item item);

        Message Delete(int id);
    }
}