using Microsoft.AspNetCore.Mvc;
using ProductionSystem.Models;
using System.Diagnostics;

namespace ProductionSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductionSystemContext _db;

        public HomeController(ProductionSystemContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Colores = _db.Color;
            ViewBag.Telas = _db.TipoTelas;
            ViewBag.MateriasPrimas = _db.MateriaPrima;
            ViewBag.Prendas = _db.Prenda;
            return View();
        }

    }
}