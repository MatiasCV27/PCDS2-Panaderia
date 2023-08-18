using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCDS2_Panaderia.Models
{
    public class PanesModel
    {
        [Required]
        public int idPanes { get; set; }
        [Required]
        public string? marcaP { get; set; }
        [Required]
        public string? nombreP { get; set; }
        [Required]
        public string? descripcionP { get; set; }
        [Required]
        public decimal costoP { get; set; }
        [Required]
        public DateTime fechaCreacionP { get; set; }
        [Required]
        public DateTime fechaVencimiP { get; set; }
        [Required]
        public int stockP { get; set; }
        [Required]
        public string? imagenP { get; set; }
    }
}
