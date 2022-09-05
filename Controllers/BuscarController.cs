using Microsoft.AspNetCore.Mvc;
using ProductionSystem.Models;

namespace ProductionSystem.Controllers
{
    public class BuscarController : Controller
    {
        private readonly ProductionSystemContext _db;

        public BuscarController(ProductionSystemContext db) //carga la base de datos
        {
            _db = db;
        }

        public IActionResult Buscar() //GET: carga la informacion de las tablas hacia la vista Buscar
        {
            ViewBag.Colores = _db.Color.ToList();
            ViewBag.Prendas = _db.Prenda.ToList();
            ViewBag.Telas = _db.TipoTelas.ToList();
            ViewBag.MateriaPrima = _db.MateriaPrima.ToList();
            ViewBag.OrdenProduccion = _db.OrdenProduccion.ToList();

            var c = 0;
            foreach (var obj in ViewBag.OrdenProduccion) //GET: cuenta la cantidad de prendas totales producidas
            {
                for (int i = 0; i < obj.Unidades; i++)
                {
                    c++;
                }
            }
            ViewBag.count = c;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buscar(string tela) //POST: Envia el nombre de la tela a la vista BuscarTela
        {
            return RedirectToAction("BuscarTela", "Buscar", new { data = tela });
        }

        public IActionResult BuscarTela(string data) //GET: carga la informacion de las tablas hacia la vista BuscarTela
        {
            ViewBag.tel = data;
            ViewBag.Colores = _db.Color.ToList();
            ViewBag.Prendas = _db.Prenda.ToList();
            ViewBag.Telas = _db.TipoTelas.ToList();
            ViewBag.MateriaPrima = _db.MateriaPrima.ToList();
            ViewBag.OrdenProduccion = _db.OrdenProduccion.ToList();

            var c = 0;
            //Cuenta la cantidad de prendas con una tela en especifico
            foreach(var obj in ViewBag.OrdenProduccion)
                for(int i = 0; i < obj.Unidades; i++)
                {
                    foreach(var mp in ViewBag.MateriaPrima)
                        if(obj.MateriaPrima == mp.Id)
                            foreach(var t in ViewBag.Telas)
                                if(mp.Tela == t.Id)
                                    if(t.Nombre == ViewBag.tel)
                                        c++;
                
                }
            ViewBag.count = c;

            return View();
        }
    }
}
