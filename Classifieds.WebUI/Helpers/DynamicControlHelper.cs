using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Classifieds.Domain.Entities;

namespace Classifieds.WebUI.Helpers
{
    public class DynamicControlHelper
    {
        public static MvcHtmlString GetControl(HtmlHelper htmlHelper, FeatureType featureType)
        {
            var builder = new StringBuilder();
            switch (featureType.ControlType)
            {
                case Classifieds.Domain.Utils.ControlType.CheckBox:
                    builder.AppendLine("CheckBox Not Implemented");
                    break;

                case Classifieds.Domain.Utils.ControlType.TextBoxInt:
                    builder.AppendLine(string.Format("<input type=\"number\" step=\"1\" />"));
                    break;

                case Classifieds.Domain.Utils.ControlType.TextBoxReal:
                    builder.AppendLine(string.Format("<input type=\"number\" step=\"any\" />"));
                    break;

                case Classifieds.Domain.Utils.ControlType.TextBox:

                    builder.AppendLine(string.Format("<input type=\"text\"/>"));
                    break;

                case Classifieds.Domain.Utils.ControlType.Date:

                    builder.AppendLine(string.Format("<input type=\"date\" />"));
                    break;

                case Classifieds.Domain.Utils.ControlType.TextArea:

                    builder.AppendLine(string.Format("​<textarea id=\"txtArea\" rows=\"5\"  />"));
                    break;

                case Classifieds.Domain.Utils.ControlType.TextBoxEmail:

                    builder.AppendLine(string.Format("<input type=\"email\"  />"));
                    break;

                case Classifieds.Domain.Utils.ControlType.DropDown:
                    builder.AppendLine("DropDown Not Implemented");
                    break;

                default:
                    builder.AppendLine("Not Implemented");
                    break;
            }

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}