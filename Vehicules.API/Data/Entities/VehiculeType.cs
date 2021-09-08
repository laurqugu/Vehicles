using System.ComponentModel.DataAnnotations;

namespace Vehicules.API.Data.Entities
{
    public class VehiculeType
    {
        public int id { get; set; }

        [Display(Name = "Tipo de Vehículo")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }
    }
}
