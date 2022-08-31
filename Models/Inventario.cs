using System;
using System.Collections.Generic;

namespace ProductionSystem.Models
{
    public partial class Inventario
    {
        public int Consecutivo { get; set; }
        public int MateriaPrima { get; set; }
        public double Cantidad { get; set; }

        public virtual MateriaPrima MateriaPrimaNavigation { get; set; } = null!;
    }
}
