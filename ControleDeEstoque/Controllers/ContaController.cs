using ControleDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleDeEstoque.Controllers
{
    public class ContaController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(login);

            }
            var achou = (UsuarioModel.ValidarUsuario(login.Usuario,login.Senha));
            if (achou)
            {
                FormsAuthentication.SetAuthCookie(login.Usuario, login.LembrarMe);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                RedirectToAction("index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login invalido.");

            }

            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
           return RedirectToAction("index", "Home");
        }
    }

}