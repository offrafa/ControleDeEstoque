﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeEstoque.Controllers
{
    public class OperacaoController : Controller
    {
        // GET: Operacao
        public ActionResult EntradaEstoque()
        {
            return View();
        }
        public ActionResult SaidaEstoque()
        {
            return View();
        }
        public ActionResult LancPerdaProduto()
        {
            return View();
        }
        public ActionResult SaidaProduto()
        {
            return View();
        }
    }
}