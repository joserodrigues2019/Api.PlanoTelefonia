using System.Web;
using System.Web.Mvc;

namespace Api.PlanoTelefonia.ApplicationService
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
