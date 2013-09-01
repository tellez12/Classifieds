using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifieds.Domain.Utils;
using Classifieds.Domain.Entities;

namespace Classifieds.Domain.Abstract
{
    public interface IFeatureTypeRepository
    {
        IQueryable<FeatureType> GetFeatureTypes { get; }
      
        FeatureType GetFeatureType(int id);
        Message Create(FeatureType featuresType);
        Message Edit(FeatureType featuresType);
        Message Delete(int id);
        
    }
}
