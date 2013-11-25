using Classifieds.Domain.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifieds.Domain.Entities
{   //Model, Color , Price
    public class FeatureType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Required { get; set; }
        public string RequiredText { get; set; }
        public ControlType ControlType { get; set; }
        public int Order { get; set; }
        public int SectionId { get; set; }
        [ForeignKey("SectionId")]
        public Section Section { get; set; }
        //virtual public List<FeatureTypeValue> Values { set; get; }
        
    }
}
