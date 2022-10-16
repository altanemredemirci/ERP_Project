using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WEBUI.Filters
{
    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["person"] == null && HttpContext.Current.Session["customer"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
            }
        }
    }
}