using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classifieds.WebUI.ViewModels
{
    public class FeatureViewModel
    {
        public int Id { get; set; }
        public String Value { get; set; }
        public bool IsFeatureValue { get; set; }
    }
}