using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Sebrae_WEB.Services
{
  public sealed class CookieHelper
  {
      private HttpResponseBase _response;
   
      public CookieHelper(HttpResponseBase response)
      {
          _response = response;
      }
   
     public void SetLoginCookie(string userName, string password, bool isPermanentCookie)
     {
         if (_response != null)
         {
             if (isPermanentCookie)
             {
                 FormsAuthenticationTicket userAuthTicket = new FormsAuthenticationTicket(
                            1,
                            userName,
                            DateTime.Now,
                            DateTime.MaxValue,
                            true,
                            password,
                            FormsAuthentication.FormsCookiePath);
  
                 string encUserAuthTicket = FormsAuthentication.Encrypt(userAuthTicket);
                 HttpCookie userAuthCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encUserAuthTicket);
                 if (userAuthTicket.IsPersistent) userAuthCookie.Expires = userAuthTicket.Expiration;
  
                 userAuthCookie.Path = FormsAuthentication.FormsCookiePath;
                 _response.Cookies.Add(userAuthCookie);
             }
             else
             {
                 FormsAuthentication.SetAuthCookie(userName, isPermanentCookie);
             }
         }
     }
 }
}