using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classifieds.Domain.Utils;
using Classifieds.Domain.Entities;


namespace Classifieds.Domain.Abstract
{
    public interface IFeatureRepository
    {
        IQueryable<Feature> GetFeatures { get; }

        Feature GetFeature(int id);
        Message Create(Feature feature);
        Message Update(Feature feature);
        Message Delete(int id);
        
    }
}
