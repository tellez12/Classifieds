using System;
using System.Linq;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.Domain.Abstract
{
    public interface IFeatureTypeRepository
    {
        IQueryable<FeatureType> GetFeatureTypes { get; }

        FeatureType GetFeatureType(int id);

        Message Create(FeatureType feature);

        Message Edit(FeatureType featureType);

        Message Delete(int id);
    }
}