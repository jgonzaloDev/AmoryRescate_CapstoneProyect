using Albergue_aspnet_DAS.Models;
using Albergue_aspnet_DAS.Models.VistaModelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Albergue_aspnet_DAS.Controllers
{
    public class TipoMascotaController : Controller
    {

        private readonly BdAlbergueAspnetContext _BDContext;

        public TipoMascotaController(BdAlbergueAspnetContext context)
        {
            _BDContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> IndexTM()
        {
            //Creamos una lista para cargar los datos de la tabla 
            List<TbTipoMascotum> lista = await _BDContext.TbTipoMascota.ToListAsync();

            return View(lista);

        }

        [HttpGet]
        public async Task<IActionResult> TipoMas_Detalle(int idTipoMas)
        {
             TipoMascotaVM oTipoMascotaVM = new TipoMascotaVM()
            {   
                oTipoMascota = new TbTipoMascotum(),  //Creamos un objeto vacio
             };

            if (idTipoMas != 0)
            {
                oTipoMascotaVM.oTipoMascota = await _BDContext.TbTipoMascota.FindAsync(idTipoMas);
            }
            return View(oTipoMascotaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TipoMas_Detalle(TipoMascotaVM oTipoMascotaVM)
        {
            if (ModelState.IsValid)
            {

                if (oTipoMascotaVM.oTipoMascota.IdTipMas == 0)
                {

                    _BDContext.TbTipoMascota.Add(oTipoMascotaVM.oTipoMascota);
                }
                else
                {
                    _BDContext.TbTipoMascota.Update(oTipoMascotaVM.oTipoMascota);
                }

                await _BDContext.SaveChangesAsync();

            }
            return RedirectToAction(nameof(IndexTM));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int idTipoMas)
        {
            //TbAlbergue oAlbergue = await _BDContext.TbAlbergues.Include(d => d.oDistrito).Include(p => p.oProvincia).Where(a => a.IdAlb == idalbergue).FirstOrDefaultAsync();
            TbTipoMascotum oTipoMascota = await _BDContext.TbTipoMascota.FindAsync(idTipoMas);
            _BDContext.TbTipoMascota.Remove(oTipoMascota);
            await _BDContext.SaveChangesAsync();
            return RedirectToAction(nameof(IndexTM));
        }
    }
}
