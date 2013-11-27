﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Classifieds.Domain.Utils;

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