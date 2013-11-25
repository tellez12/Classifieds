using Classifieds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifieds.Domain.Entities
{
    public class Section
    {
        public int Id { get; set;}
        public string Name { get; set; }
        public int Order { get; set; }
        public virtual List<FeatureType> Features { get; set; }

    }
}
