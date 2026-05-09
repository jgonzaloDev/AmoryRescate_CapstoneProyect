using Albergue_aspnet_DAS.Models;
using Albergue_aspnet_DAS.Models.VistaModelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Albergue_aspnet_DAS.Controllers
{
    public class Pestanias : Controller
    {
        private readonly BdAlbergueAspnetContext _BDContext;
        public Pestanias(BdAlbergueAspnetContext Context)
        {
            _BDContext = Context;
        }
        public IActionResult Inicio()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Perros()
        {
            List<TbMascotum> lista = await _BDContext.TbMascota
                                    .Include(t => t.oTipoMascota)
                                    .Where(m => m.oTipoMascota.DescripcionTipMas.ToLower() == "perro")
                                    .ToListAsync();
            return View(lista);
        }
        [HttpGet]
        public async Task<IActionResult> Gatos()
        {
            List<TbMascotum> lista = await _BDContext.TbMascota
                                    .Include(t => t.oTipoMascota)
                                    .Where(m => m.oTipoMascota.DescripcionTipMas.ToLower() == "gato")
                                    .ToListAsync();
            return View(lista);
        }
        [HttpGet]
        public async Task<IActionResult> Otros()
        {
            List<TbMascotum> lista = await _BDContext.TbMascota
                                    .Include(t => t.oTipoMascota)
                                    .Where(m => m.oTipoMascota.DescripcionTipMas.ToLower() == "otros")
                                    .ToListAsync();
            return View(lista);
        }
        public IActionResult ComoAdoptar()
        {
            return View();
        }
        public async Task<IActionResult> Adopciones()
        {
            List<TbMascotum> lista = await _BDContext.TbMascota.ToListAsync();
            return View(lista);
        }
        public async Task<IActionResult> Adopciones_Detalles(int idMascota)
        {
            TbMascotum Mascota = new TbMascotum();
            if (idMascota != 0)
            {
                Mascota = await _BDContext.TbMascota.FindAsync(idMascota);
            }
            return View(Mascota);
        }

        // ============================================
        // BUSCAR MASCOTAS
        // ============================================
        [HttpGet]
        public async Task<IActionResult> Buscar(string q)
        {
            ViewData["BusquedaActual"] = q;

            if (string.IsNullOrWhiteSpace(q))
            {
                return View(new List<TbMascotum>());
            }

            var busqueda = q.Trim().ToLower();

            List<TbMascotum> resultados = await _BDContext.TbMascota
                .Include(t => t.oTipoMascota)
                .Include(t => t.oRazaMascota)
                .Where(m =>
                    m.NombreMas.ToLower().Contains(busqueda) ||
                    (m.oTipoMascota != null && m.oTipoMascota.DescripcionTipMas.ToLower().Contains(busqueda)) ||
                    (m.oRazaMascota != null && m.oRazaMascota.DescripcionRazMas.ToLower().Contains(busqueda)) ||
                    (m.SexoMas != null && m.SexoMas.ToLower().Contains(busqueda)) ||
                    (m.TamanioMas != null && m.TamanioMas.ToLower().Contains(busqueda))
                )
                .ToListAsync();

            return View(resultados);
        }
    }
}