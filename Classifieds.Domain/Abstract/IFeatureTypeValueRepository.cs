using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifieds.Domain.Utils;
using Classifieds.Domain.Entities;

namespace Classifieds.Domain.Abstract
{
    public interface IFeatureTypeValueRepository
    {
        IQueryable<FeatureTypeValue> GetFeatureTypeValues { get; }

        FeatureTypeValue GetFeatureTypeValue(int id);
        Message Create(FeatureTypeValue featuresType);
        Message Edit(FeatureTypeValue featuresType);
        Message Delete(int id);
        
    }
}
