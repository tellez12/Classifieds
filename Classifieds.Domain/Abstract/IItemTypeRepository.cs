using System;
using System.Linq;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.Abstract
{
    public interface IItemTypeRepository
    {
        IQueryable<ItemType> GetItemTypes { get; }

        ItemType GetItemType(int id);

        Message Create(ItemType itemType);

        Message Edit(ItemType itemType);

        Message Delete(int id);
    }
}