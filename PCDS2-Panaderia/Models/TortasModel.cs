using Microsoft.Build.Framework;

namespace PCDS2_Panaderia.Models
{
    public class TortasModel
    {
        public int idTortas { get; set; }
        [Required]
        public string? marcaB { get; set; }
        [Required]
        public string? nombreT { get; set; }
        [Required]
        public string? descripcionT { get; set; }
        [Required]
        public decimal costoT { get; set; }
        [Required]
        public DateTime fechaCreacionT { get; set; }
        [Required]
        public DateTime fechaVencimi { get; set; }
        [Required]
        public int stockT { get; set; }
        [Required]
        public string? imagenT { get; set; }
    }
}
