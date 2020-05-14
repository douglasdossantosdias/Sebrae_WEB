using Newtonsoft.Json;
using Sebrae_WEB.Areas.Admin;
using Sebrae_WEB.Areas.Admin.Controllers;
using Sebrae_WEB.Models;
using Sebrae_WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Sebrae_WEB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(Usuario usr)
        {
         
            ViewBag.msg = usr.Frase;
            return View();

        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Authentication authentication = new Authentication();
                    Usuario usr = new Usuario();
                    var token = authentication.Token(model);
                    if (token.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        usr.Frase = "Acesso Negado.Tente novamente";

                        return RedirectToAction("Login", "Login", usr);
                    }
                    var chave = token.Content;

                    var result = authentication.Get(chave);

                    var teste = result.Content;
                    var result2 = JsonConvert.DeserializeObject(teste);
                    usr.Frase = result2.ToString();

                    if (result != null)
                    {
                        CookieHelper newCookieHelper = new CookieHelper(HttpContext.Response);
                        newCookieHelper.SetLoginCookie(model.NomeUsuario, model.SenhaUsuario, true);

                        return RedirectToAction("Index", "Admin/Dashboard", usr);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }


            return View();
        }

    }
}