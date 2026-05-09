using Albergue_aspnet_DAS.Models;
using Albergue_aspnet_DAS.Models.VistaModelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Albergue_aspnet_DAS.Controllers
{
    public class RazaMascotasControllers : Controller
    {
        private readonly BdAlbergueAspnetContext _BDContext;

        public RazaMascotasControllers(BdAlbergueAspnetContext context)
        {
            _BDContext = context;
        }

        public async Task<IActionResult> IndexRM()
        {
            //Creamos una lista para cargar los datos de la tabla y con los include cargamos los datos de los objetos relacionados
            List<TbRazaMascotum> lista = await _BDContext.TbRazaMascota.ToListAsync();

            return View(lista);
            
        }

        [HttpGet]
        public async Task<IActionResult> Razas_Detalle(int idRasaMascota)
        {
            RazaMazcotasVM oRazaMascotasVM = new RazaMazcotasVM()
            {    //Creamos un objeto vacio
                oRazaMascota = new TbRazaMascotum(),
            };

            if (idRasaMascota != 0)
            {
                oRazaMascotasVM.oRazaMascota = await _BDContext.TbRazaMascota.FindAsync(idRasaMascota);
            }
            return View(oRazaMascotasVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Razas_Detalle(RazaMazcotasVM oRazaMascotasVM)
        {
            if (ModelState.IsValid) {

                if (oRazaMascotasVM.oRazaMascota.IdRazMas == 0)
                {

                    _BDContext.TbRazaMascota.Add(oRazaMascotasVM.oRazaMascota);
                }
                else
                {
                    _BDContext.TbRazaMascota.Update(oRazaMascotasVM.oRazaMascota);
                }

                await _BDContext.SaveChangesAsync();

            }
            return RedirectToAction(nameof(IndexRM));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int idRasaMascota)
        {
            //TbAlbergue oAlbergue = await _BDContext.TbAlbergues.Include(d => d.oDistrito).Include(p => p.oProvincia).Where(a => a.IdAlb == idalbergue).FirstOrDefaultAsync();
            //TbRazaMascotum oRazaMascotas = await _BDContext.TbRazaMascota.FindAsync(idRasaMascota);
            //_BDContext.TbRazaMascota.Remove(oRazaMascotas);
            await _BDContext.SaveChangesAsync();
            return RedirectToAction(nameof(IndexRM));
        }

    }
}
