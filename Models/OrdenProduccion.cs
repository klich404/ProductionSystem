using System;
using System.Collections.Generic;

namespace ProductionSystem.Models
{
    public partial class OrdenProduccion
    {
        public int Consecutivo { get; set; }
        public int MateriaPrima { get; set; }
        public int Prenda { get; set; }
        public int Unidades { get; set; }

        public virtual MateriaPrima MateriaPrimaNavigation { get; set; } = null!;
        public virtual Prendum PrendaNavigation { get; set; } = null!;
    }
}
