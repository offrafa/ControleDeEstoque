using ControleDeEstoque.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace ControleDeEstoque.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        [AllowAnonymous]
        public ActionResult Login( string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel login, string ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var achou = UsuarioModel.ValidarUsuario(login.Usuario, login.Senha);

            if (achou)
            {
                FormsAuthentication.SetAuthCookie(login.Usuario, login.LembreMe);
                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    RedirectToAction("Index", "Home");
                }                            
            }
            else
            {
                ModelState.AddModelError("", "Login Invalido");
            }

            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}