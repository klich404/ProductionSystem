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
        public IActionResult OrdenProduccion()
        {

            ViewBag.Colores = _db.Color.ToList();
            ViewBag.Prendas = _db.Prenda.ToList();
            ViewBag.Telas = _db.TipoTelas.ToList();
            ViewBag.Inventario = _db.Inventario.ToList();
            ViewBag.MateriaPrima = _db.MateriaPrima.ToList();
            ViewBag.OrdenProduccion = _db.OrdenProduccion.ToList();
            return View();
        }

        public IActionResult CreateOrdenProduccion() //GET
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
        public IActionResult CreateOrdenProduccion(OrdenProduccion obj, Inventario inv, string materiaPrima, string prenda) //POST
        {
            string[] mpId = materiaPrima.Split("-");
            obj.MateriaPrima = Int32.Parse(mpId[mpId.Length - 1]);

            string[] pId = prenda.Split("-");
            obj.Prenda = Int32.Parse(pId[pId.Length - 1]);

            foreach (var i in _db.Inventario)
            {
                if (i.Consecutivo == obj.MateriaPrima)
                {
                    inv.Consecutivo = i.Consecutivo;
                    inv.MateriaPrima = i.Consecutivo;
                }
            }
            foreach (var p in _db.Prenda)
            {
                if (p.Id == obj.Prenda)
                {
                    System.Diagnostics.Debug.WriteLine(inv.Cantidad);
                    System.Diagnostics.Debug.WriteLine("------------------------------------");
                    double nuevaCantidad = inv.Cantidad - (obj.Unidades * p.ConsumoInvUnd);
                    inv.Cantidad = nuevaCantidad;
                }
            }

            System.Diagnostics.Debug.WriteLine(inv.Consecutivo);
            System.Diagnostics.Debug.WriteLine(inv.MateriaPrima);
            System.Diagnostics.Debug.WriteLine(inv.Cantidad);
            System.Diagnostics.Debug.WriteLine("------------------------------------");

            _db.Inventario.Update(inv);
            _db.OrdenProduccion.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("OrdenProduccion");
        }
    }
}
