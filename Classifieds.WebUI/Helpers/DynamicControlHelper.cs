using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Classifieds.Domain.Entities;
using Classifieds.Domain.Utils;

namespace Classifieds.WebUI.Helpers
{
    public class DynamicControlHelper
    {
        public static MvcHtmlString GetControl(HtmlHelper htmlHelper, FeatureType featureType,int cont )
        {
            var builder = new StringBuilder();
            builder.AppendFormat("<input type='hidden' value='{0}' name='feature[{1}].Id' id='feature[{1}].Id'/> ", featureType.Id, cont);
            switch (featureType.ControlType)
            {
                case ControlType.CheckBox:
                    builder.AppendLine("CheckBox Not Implemented");
                    break;

                case ControlType.TextBoxInt:
                    builder.AppendLine(string.Format("<input type=\"number\" step=\"1\" name='feature[{0}].Value' id='feature[{0}].Value'/>",cont));
                    break;

                case ControlType.TextBoxReal:
                    builder.AppendLine(string.Format("<input type=\"number\" step=\"any\" name='feature[{0}].Value' id='feature[{0}].Value'/>", cont));
                    break;

                case ControlType.TextBox:

                    builder.AppendLine(string.Format("<input type=\"text\"name='feature[{0}].Value' id='feature[{0}].Value'/>", cont));
                    break;

                case ControlType.Date:

                    builder.AppendLine(string.Format("<input type=\"date\" name='feature[{0}].Value' id='feature[{0}].Value'/>", cont));
                    break;

                case ControlType.TextArea:

                    builder.AppendLine(string.Format("​<textarea id=\"txtArea\" rows=\"5\" name='feature[{0}].Value' id='feature[{0}].Value'/>", cont));
                    break;

                case ControlType.TextBoxEmail:

                    builder.AppendLine(string.Format("<input type=\"email\" name='feature[{0}].Value' id='feature[{0}].Value'/>", cont));
                    break;

                case ControlType.DropDown:
                    builder.AppendLine(GetDropDownControl(featureType,cont));
                    break;

                default:
                    builder.AppendLine("Not Implemented");
                    break;
            }

            return MvcHtmlString.Create(builder.ToString());
        }

        private static string GetDropDownControl(FeatureType featureType,int cont )
        {
            var builder = new StringBuilder();
            builder.AppendFormat("<Select name='feature[{0}].Value' id='feature[{0}].Value/>",cont);

            foreach (var value in featureType.Values)
            {
                builder.AppendFormat("<option value='{0}'>{1}</option>",value.Id,value.Value);
            }
            return builder.ToString();
        }
    }
}