using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classifieds.Domain.Entities
{
    public class FeatureTypeValue
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public FeatureType Type { get; set; }
    }
}