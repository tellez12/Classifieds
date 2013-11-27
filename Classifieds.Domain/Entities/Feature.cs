using System;

namespace Classifieds.Domain.Entities
{
    // Is the actual value of a FeatureType for an item.
    public class Feature
    {
        public int Id { get; set; }

        public virtual FeatureType FeatureType { get; set; }

        public string StringValue { get; set; }

        public virtual FeatureTypeValue Value { get; set; }
    }
}