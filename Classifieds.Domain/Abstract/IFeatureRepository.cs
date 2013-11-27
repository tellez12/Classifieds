using System;
using System.Linq;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

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