using System;
using System.Text;
using System.Web.Mvc;

namespace Classifieds.WebUI.Helpers
{
      public class MenuHelper
    {
        public static MvcHtmlString AdminMenu(HtmlHelper htmlHelper)
        {
            var builder = new StringBuilder();
            builder.AppendLine("<div id='cssmenu'> ");
            builder.AppendLine("<ul>");
            builder.AppendLine(MenuItem(htmlHelper, "Currency"));
            builder.AppendLine(MenuItem(htmlHelper,"Section"));
            builder.AppendLine(MenuItem(htmlHelper, "Item"));
            builder.AppendLine(MenuItem(htmlHelper, "ItemType", "Item Type"));
            builder.AppendLine(MenuItem(htmlHelper, "FeatureType","Feature Type"));
            builder.AppendLine(MenuItem(htmlHelper, "FeatureTypeValue", "Feature Type Value"));
  
            builder.AppendLine("</ul>");
            builder.AppendLine("</div>");     

            return MvcHtmlString.Create(builder.ToString());
        }

        public static string MenuItem(HtmlHelper htmlHelper, string controller, string nombre = "")
        {
            if (nombre == "")
                nombre= controller;
            
                var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
                var url = urlHelper.Action("",controller);
                return String.Format("<li><a href='{0}'><span>{1}</span></a> </li>", url, nombre);
   
        }

    }
}