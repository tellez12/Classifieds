using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
