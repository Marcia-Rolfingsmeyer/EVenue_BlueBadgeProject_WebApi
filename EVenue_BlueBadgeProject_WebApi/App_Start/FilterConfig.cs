using System.Web;
using System.Web.Mvc;

namespace EVenue_BlueBadgeProject_WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
