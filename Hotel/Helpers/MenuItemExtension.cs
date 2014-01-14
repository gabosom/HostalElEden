using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelEden.Helpers
{
    public static class MenuItemExtensions
    {
        public static MvcHtmlString MenuItem(this HtmlHelper htmlHelper, string text,string action,string controller){
            var li = new TagBuilder("li");
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");
            if (string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase) &&
            string.Equals(currentController, controller, StringComparison.OrdinalIgnoreCase))
            {
                li.AddCssClass("selected");
            }

            var link = new TagBuilder("a");
            link.Attributes.Add("href", "/"+controller + "/" + action);
            link.SetInnerText(text);

            
            
            li.InnerHtml = link.ToString();
            return MvcHtmlString.Create(li.ToString());
        }
    }
}