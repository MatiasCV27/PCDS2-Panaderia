using Microsoft.Build.Framework;

namespace PCDS2_Panaderia.Models
{
    public class PanesModel
    {
        public int idPanes { get; set; }
        [Required]
        public int idMarca { get; set; }
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
    }
}
