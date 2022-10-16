using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI_Reconocimiento.Models.ApplicationModel
{
    public class PatenteModel
    {
        [Key, Required]
        public int IdPatente { get; set; }
        [MaxLength(10), Column(TypeName = "nvarchar")]
        public string? Patente { get; set; }
        [Column(TypeName = "bit")]
        public bool Active { get; set; }
        [Column(TypeName = "datetime"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaAlta { get; set; }
    }
}