using Microsoft.AspNetCore.Mvc;
using ProductionSystem.Models;

namespace ProductionSystem.Controllers
{
    public class OrdenProduccionController : Controller
    {
        private readonly ProductionSystemContext _db;

        public OrdenProduccionController(ProductionSystemContext db) //carga la base de datos
        {
            _db = db;
        }
        public IActionResult OrdenProduccion() //GET: carga la informacion de las tablas hacia la vista OrdenProduccion
        {

            ViewBag.Colores = _db.Color.ToList();
            ViewBag.Prendas = _db.Prenda.ToList();
            ViewBag.Telas = _db.TipoTelas.ToList();
            ViewBag.Inventario = _db.Inventario.ToList();
            ViewBag.MateriaPrima = _db.MateriaPrima.ToList();
            ViewBag.OrdenProduccion = _db.OrdenProduccion.ToList();
            return View();
        }

        public IActionResult CreateOrdenProduccion() //GET: carga la informacion de las tablas hacia la vista CreateOrdenProduccion
        {
            ViewBag.Colores = _db.Color.ToList();
            ViewBag.Prendas = _db.Prenda.ToList();
            ViewBag.Telas = _db.TipoTelas.ToList();
            ViewBag.Inventario = _db.Inventario.ToList();
            ViewBag.MateriaPrima = _db.MateriaPrima.ToList();
            ViewBag.OrdenProduccion = _db.OrdenProduccion.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST: crea un nuevo objeto OrdenProduccion en _db
        public IActionResult CreateOrdenProduccion(OrdenProduccion obj, Inventario inv, string materiaPrima, string prenda)
        {
            string[] mpId = materiaPrima.Split("-"); //Splitea ("-") la casilla seleccionada en materiaprima
            obj.MateriaPrima = Int32.Parse(mpId[mpId.Length - 1]); //agarra el ulitmo elemento que representa el id de la materia prima

            string[] pId = prenda.Split("-"); //Splitea ("-") la casilla seleccionada en prenda
            obj.Prenda = Int32.Parse(pId[pId.Length - 1]); //agarra el ulitmo elemento que representa el id de la prenda

            var id = 0;

            foreach (var mp in _db.MateriaPrima) //Busca el id de materiaprima para llenar una FK
            {
                if (mp.Id == obj.MateriaPrima)
                {
                    inv.MateriaPrima = obj.MateriaPrima;
                }
            }
            foreach (var i in _db.Inventario) //Busca el id de inventario para llenar asignar un id y una cantidad
            {
                if (i.MateriaPrima == inv.MateriaPrima)
                {
                    id = i.Consecutivo;
                    inv.Cantidad = i.Cantidad;
                }
            }
            foreach (var p in _db.Prenda) //Busca el id de prenda para asignar una nueva cantidad
            {
                if (p.Id == obj.Prenda)
                {
                    double nuevaCantidad = inv.Cantidad - (obj.Unidades * p.ConsumoInvUnd);
                    inv.Cantidad = nuevaCantidad;
                }
            }
            var del = _db.Inventario.Find(id); //Busca el id de inventario para luego se elminado

            _db.Inventario.Remove(del);
            _db.Inventario.Add(inv);
            _db.OrdenProduccion.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("OrdenProduccion");
        }
    }
}
