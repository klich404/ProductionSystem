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

        public IActionResult Inventario() //carga la informacion de las tablas hacia la vista Index
        {
            ViewBag.Colores = _db.Color.ToList();
            ViewBag.Telas = _db.TipoTelas.ToList();
            ViewBag.Inventario = _db.Inventario.ToList();
            ViewBag.MateriaPrima = _db.MateriaPrima.ToList();
            return View();
        }
    }
}
