using System;
using System.Collections.Generic;

namespace ProductionSystem.Models
{
    public partial class Color
    {
        public Color()
        {
            MateriaPrimas = new HashSet<MateriaPrima>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<MateriaPrima> MateriaPrimas { get; set; }
    }
}
