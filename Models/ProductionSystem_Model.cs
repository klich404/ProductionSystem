using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionSystem.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class TipoTela
    {
        [Key]
        public int TelaId { get; set; }
        public string Nombre { get; set; }
    }

    public class Prenda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float ConsumoInvUnd { get; set; }
    }

    public class MateriaPrima
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("")]
        public int FK_Tela { get; set; }
        public int FK_Color { get; set; }
    }

    public class Inventario
    {
    }

    public class OrdenProduccion
    {
    }
}
