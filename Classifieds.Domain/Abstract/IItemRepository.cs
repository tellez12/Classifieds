using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifieds.Domain.Utils;
using Classifieds.Domain.Entities;

namespace Classifieds.Domain.Abstract
{
    public interface IItemRepository
    {
        IQueryable<Item> GetItems { get; }
      
        Item GetItem(int id);
        Message Create(Item featuresType);
        Message Update(Item featuresType);
        Message Delete(int id);
        
    }
}
