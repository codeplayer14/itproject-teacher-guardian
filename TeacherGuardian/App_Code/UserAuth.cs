using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserAuth
/// </summary>
public static class UserAuth
{

    public static void AuthenticateUser(string loginPage,Boolean isAdmin)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];
        if (cookie == null)
        {
            HttpContext.Current.Response.Redirect(loginPage);
            //Redirect
        }

        if (Convert.ToBoolean(cookie["authenticated"].ToString()))
        {
            if (isAdmin == true)
            {
                if (cookie["admin"] == null)
                {

                    HttpContext.Current.Response.Redirect(loginPage);
                }
                if (!Convert.ToBoolean(cookie["admin"].ToString()))
                {

                    HttpContext.Current.Response.Redirect(loginPage);

                }
            }
            return;
        }
        else
        {
            HttpContext.Current.Response.Redirect(loginPage);
        }

    }
}