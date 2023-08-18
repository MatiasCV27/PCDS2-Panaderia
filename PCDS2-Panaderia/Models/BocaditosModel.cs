using Microsoft.Build.Framework;

namespace PCDS2_Panaderia.Models
{
    public class BocaditosModel
    {
        public int idBocaditos { get; set; }
        [Required]
        public string? marcaB { get; set; }
        [Required]
        public string? nombreB { get; set; }
        [Required]
        public string? descripcionB { get; set; }
        [Required]
        public decimal costoB { get; set; }
        [Required]
        public DateTime fechaCreacionB { get; set; }
        [Required]
        public DateTime fechaVencimiB { get; set; }
        [Required]
        public int stockB { get; set; }
        [Required]
        public string? imagenB { get; set; }
    }
}
