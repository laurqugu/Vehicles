using System;
using System.ComponentModel.DataAnnotations;

namespace Vehicules.API.Data.Entities
{
    public class VehiclePhoto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: Fix the correct Path
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
          ? $"https://localhost:44334/images/noimage.png"
          : $"https://vehicleslaurqugu.blob.core.windows.net/vehicles/{ImageId}";

    }
}
