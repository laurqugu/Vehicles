using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicules.API.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetCombosDocumentTypes();

        IEnumerable<SelectListItem> GetCombosProcedures();

        IEnumerable<SelectListItem> GetCombosVehiclesTypes();

        IEnumerable<SelectListItem> GetCombosBrands();
    }
}
