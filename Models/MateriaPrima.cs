using System;
using System.Collections.Generic;

namespace ProductionSystem.Models
{
    public partial class MateriaPrima
    {
        public MateriaPrima()
        {
            Inventarios = new HashSet<Inventario>();
            OrdenProduccions = new HashSet<OrdenProduccion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Color { get; set; }
        public int Tela { get; set; }

        public virtual Color ColorNavigation { get; set; } = null!;
        public virtual TipoTela TelaNavigation { get; set; } = null!;
        public virtual ICollection<Inventario> Inventarios { get; set; }
        public virtual ICollection<OrdenProduccion> OrdenProduccions { get; set; }
    }
}
