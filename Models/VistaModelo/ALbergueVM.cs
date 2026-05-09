using Microsoft.AspNetCore.Mvc.Rendering;

namespace Albergue_aspnet_DAS.Models.VistaModelo
{
    public class ALbergueVM
    {
        public TbAlbergue oAlbergue { get; set; }
        public List<SelectListItem> oListaDistrito { get; set; }
        public List<SelectListItem> oListaProvincia { get; set; }
    }
}
