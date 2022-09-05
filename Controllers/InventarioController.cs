using Microsoft.AspNetCore.Mvc;
using ProductionSystem.Models;

namespace ProductionSystem.Controllers
{
    public class InventarioController : Controller
    {
        private readonly ProductionSystemContext _db;

        public InventarioController(ProductionSystemContext db) //carga la base de datos
        {
            _db = db;
        }

        public IActionResult Inventario() //GET: carga la informacion de las tablas hacia la vista Inventario
        {
            ViewBag.Colores = _db.Color.ToList();
            ViewBag.Telas = _db.TipoTelas.ToList();
            ViewBag.Inventario = _db.Inventario.ToList();
            ViewBag.MateriaPrima = _db.MateriaPrima.ToList();
            return View();
        }

        public IActionResult IngresarInventario() //GET: carga la informacion de las tablas hacia la vista IngresarInventario
        {
            ViewBag.Colores = _db.Color.ToList();
            ViewBag.Telas = _db.TipoTelas.ToList();
            ViewBag.Inventario = _db.Inventario.ToList();
            ViewBag.MateriaPrima = _db.MateriaPrima.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IngresarInventario(Inventario obj, string materiaPrima) //POST: crea un nuevo objeto Inventario en _db
        {
            string[] mpId = materiaPrima.Split("-"); //Splitea ("-") la casilla seleccionada en materiaprima
            obj.MateriaPrima = Int32.Parse(mpId[mpId.Length - 1]); //agarra el ulitmo elemento que representa el id de la materia prima

            _db.Inventario.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Inventario");
        }
    }
}
