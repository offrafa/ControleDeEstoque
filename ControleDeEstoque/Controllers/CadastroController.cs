using ControleDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeEstoque.Controllers
{
    public class CadastroController : Controller
    {
        private static List<GrupoProdutoModel> _ListaGrupoDeProduto = new List<GrupoProdutoModel>()
        {
            new GrupoProdutoModel() {Id = 1, Nome = "Livros", Ativo = true},
            new GrupoProdutoModel() {Id = 2, Nome = "Mouse",  Ativo = true},
            new GrupoProdutoModel() {Id = 3, Nome = "Monitores", Ativo = false},
        };


        // GET: Cadastro
        [Authorize]
        public ActionResult GrupoPedido()
        {
            return View(_ListaGrupoDeProduto);
        }


        [HttpPost]
        [Authorize]
        public ActionResult RecuperarGrupoProduto(int id)
        {
            return Json(_ListaGrupoDeProduto.Find(x => x.Id == id));
        }



        [HttpPost]
        [Authorize]
        public ActionResult ExcluirGrupoProduto(int id)
        {
            var Ret = false;
            var RegistroDB = _ListaGrupoDeProduto.Find(x => x.Id == id);
            if(RegistroDB != null)
            {
                _ListaGrupoDeProduto.Remove(RegistroDB);
                Ret = true;
            }

            return Json(Ret);
        }




        [HttpPost]
        [Authorize]
        public ActionResult SalvarGrupoProduto(GrupoProdutoModel model)
        {
            var RegistroDB = _ListaGrupoDeProduto.Find(x =>x.Id == model.Id);
            if( RegistroDB == null)
            {
                RegistroDB = model;
                RegistroDB.Id = _ListaGrupoDeProduto.Max(x => x.Id) + 1;

                _ListaGrupoDeProduto.Add(RegistroDB);
            }
            else
            {
                RegistroDB.Nome = model.Nome;
                RegistroDB.Ativo = model.Ativo;
            }
            return Json(RegistroDB);
        }




        [Authorize]
        public ActionResult MarcaProduto()
        {
            return View();
        }

        [Authorize]
        public ActionResult LocaisProduto()
        {
            return View();
        }

        [Authorize]
        public ActionResult UnidadesMedidas()
        {
            return View();
        }

        [Authorize]
        public ActionResult Produto()
        {
            return View();
        }

        [Authorize]
        public ActionResult Pais()
        {
            return View();
        }

        [Authorize]
        public ActionResult Estado()
        {
            return View();
        }

        [Authorize]
        public ActionResult Cidade()
        {
            return View();
        }

        [Authorize]
        public ActionResult Fornecedor()
        {
            return View();
        }

        [Authorize]
        public ActionResult PerfilUsuario()
        {
            return View();
        }

        [Authorize]
        public ActionResult Usuario()
        {
            return View();
        }

    }
}