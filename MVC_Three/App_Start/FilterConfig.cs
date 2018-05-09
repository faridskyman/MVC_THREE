using System.Web;
using System.Web.Mvc;

namespace MVC_Three
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); //redir user to err page if page throws err
            filters.Add(new AuthorizeAttribute()); //make entire app authorized.
        }
    }
}
