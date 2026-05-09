using Microsoft.AspNetCore.Mvc.Rendering;

namespace Albergue_aspnet_DAS.Models.VistaModelo
{
    public class MascotaVM
    {
        public TbMascotum oMascota { get; set; }
        public List<SelectListItem> oListaTiposMascotas { get; set; }
        public List<SelectListItem> oListaRazaMascotas { get; set; }
        public List<SelectListItem> oListaALbergues { get; set; }
    }
}
