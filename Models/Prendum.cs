using System;
using System.Collections.Generic;

namespace ProductionSystem.Models
{
    public partial class Prendum
    {
        public Prendum()
        {
            OrdenProduccions = new HashSet<OrdenProduccion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public double ConsumoInvUnd { get; set; }

        public virtual ICollection<OrdenProduccion> OrdenProduccions { get; set; }
    }
}
