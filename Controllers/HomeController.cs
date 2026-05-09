using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Albergue_aspnet_DAS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Albergue_aspnet_DAS.Models.VistaModelo;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Albergue_aspnet_DAS.Controllers
{
    public class HomeController : Controller
    {
        private readonly BdAlbergueAspnetContext _BDContext;

        public HomeController(BdAlbergueAspnetContext context)
        {
            _BDContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {   //Creamos una lista para cargar los datos de la tabla y con los include cargamos los datos de los objetos relacionados
            List<TbAlbergue> lista = await _BDContext.TbAlbergues.Include(d => d.oDistrito).Include(p => p.oProvincia).ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult> Albergue_Detalle(int idalbergue)
        {
            ALbergueVM oAlbergueVM = new ALbergueVM()
            {    //Creamos un objeto vacio
                oAlbergue = new TbAlbergue(),

                oListaDistrito = await _BDContext.TbDistritos.Select(distrito => new SelectListItem()
                {   //cargamos los datos a la lista despegable 
                    Text = distrito.DescripcionDist,
                    Value = distrito.IdDist.ToString()
                }).ToListAsync(),

                oListaProvincia = await _BDContext.TbProvincias.Select(provincias => new SelectListItem()
                {
                    Text = provincias.DescripcionProv,
                    Value = provincias.IdProv.ToString()
                }).ToListAsync()

            };

            if (idalbergue != 0)
            {
                oAlbergueVM.oAlbergue = await _BDContext.TbAlbergues.FindAsync(idalbergue);
            }
            return View(oAlbergueVM);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Albergue_Detalle(ALbergueVM oAlbergueVM)
        {
            //if (ModelState.IsValid)
            //{
                if (oAlbergueVM.oAlbergue.IdAlb == 0)
                {

                    _BDContext.TbAlbergues.Add(oAlbergueVM.oAlbergue);
                }
                else
                {
                    _BDContext.TbAlbergues.Update(oAlbergueVM.oAlbergue);
                }

                await _BDContext.SaveChangesAsync();

            //}
            return RedirectToAction(nameof(Index));

        }
        

        [HttpGet]
        public async Task<IActionResult> Eliminar(int idalbergue)
        {
           //TbAlbergue oAlbergue = await _BDContext.TbAlbergues.Include(d => d.oDistrito).Include(p => p.oProvincia).Where(a => a.IdAlb == idalbergue).FirstOrDefaultAsync();
            TbAlbergue oAlbergue = await _BDContext.TbAlbergues.FindAsync(idalbergue);
            _BDContext.TbAlbergues.Remove(oAlbergue); 
            await _BDContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }

}
