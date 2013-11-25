using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifieds.Domain.Entities
{
    // Is the actual value of a FeatureType for an item. 
    public class Feature
    {
        public int Id { get; set; }
        public string StringValue { get; set; }
        public virtual FeatureTypeValue Value { get; set; }

    }
}
