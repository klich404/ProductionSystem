using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductionSystem.Models;
using System.Diagnostics;

namespace ProductionSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductionSystemContext _db;

        public HomeController(ProductionSystemContext db) //carga la base de datos
        {
            _db = db;
        }

        public IActionResult Index() //carga la informacion de las tablas hacia la vista Index
        {
            ViewBag.Colores = _db.Color.ToList();
            ViewBag.Telas = _db.TipoTelas.ToList();
            ViewBag.MateriasPrimas = _db.MateriaPrima.ToList();
            ViewBag.Prendas = _db.Prenda.ToList();
            return View();
        }


        public IActionResult CreateColor() //GET
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateColor(Color obj) //POST
        {
            _db.Color.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult CreateTela() //GET
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTela(TipoTela obj) //POST
        {
            _db.TipoTelas.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult CreateMateriaPrima() //GET
        {
            ViewBag.Colores = _db.Color.ToList();
            ViewBag.Telas = _db.TipoTelas.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMateriaPrima(MateriaPrima obj) //POST
        {
            foreach (var c in _db.Color)
            {
                if (c.Nombre == obj.Color.ToString())
                {
                    obj.Color = c.Id;
                }
            }
            foreach (var t in _db.TipoTelas)
            {
                if (t.Nombre == obj.Tela.ToString())
                {
                    obj.Tela = t.Id;
                }
            }
            _db.MateriaPrima.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult CreatePrenda() //GET
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePrenda(Prendum obj) //POST
        {
            _db.Prenda.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}