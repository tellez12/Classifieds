using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Classifieds.Domain.Entities
{
    public class ItemType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<FeatureType> FeatureTypes { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}