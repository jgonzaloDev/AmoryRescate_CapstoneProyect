using Albergue_aspnet_DAS.Models.VistaModelo;
using Albergue_aspnet_DAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Albergue_aspnet_DAS.Controllers
{
    public class MascotaController : Controller
    {
        private readonly BdAlbergueAspnetContext _BDContext;

        public MascotaController(BdAlbergueAspnetContext context)
        {
            _BDContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> IndexMas()
        {
            //Creamos una lista para cargar los datos de la tabla y con los include cargamos los datos de los objetos relacionados
            List<TbMascotum> lista = await _BDContext.TbMascota.Include(t => t.oTipoMascota).Include(r => r.oRazaMascota).Include(a => a.oAlbergue).ToListAsync();
            return View(lista);
        }


        [HttpGet]
        public async Task<IActionResult> Filtros(string sexo = "todos", string tamanio = "todos")
        {
            //Creamos una lista para cargar los datos de la tabla y con los include cargamos los datos de los objetos relacionados
            var consulta = _BDContext.TbMascota
                            .Include(t => t.oTipoMascota)
                            .Include(r => r.oRazaMascota)
                            .Include(a => a.oAlbergue)
                            .AsQueryable();//Utilizamos AsQueryable() para construir dinámicamente la consulta en función de los filtros
                                           //seleccionados. Esto permite aplicar varios filtros en la misma consulta sin tener que hacer
                                           //varias peticiones a la base de datos.

            // Filtro por sexo (macho, hembra)
            if (sexo != "todos")
            {
                consulta = consulta.Where(m => m.SexoMas.ToLower() == sexo.ToLower());
            }

            // Filtro por tamaño (pequeño, mediano, grande)
            if (tamanio != "todos")
            {
                consulta = consulta.Where(m => m.TamanioMas.ToLower() == tamanio.ToLower());
            }

            List<TbMascotum> lista = await consulta.ToListAsync();

            return PartialView("_MascotasTarjetas",lista);
        }
    

        [HttpGet]
        public async Task<IActionResult> Mascota_Detalle(int idMascota)
        {
            MascotaVM oMascotaVM = new MascotaVM()
            {    //Creamos un objeto vacio
                oMascota = new TbMascotum(),

                //Cargamos estos objetos al 
                oListaTiposMascotas = await _BDContext.TbTipoMascota.Select(tipoMascota => new SelectListItem()
                {   //cargamos los datos a la lista despegable 
                    Text = tipoMascota.DescripcionTipMas,
                    Value = tipoMascota.IdTipMas.ToString()
                }).ToListAsync(),

                oListaRazaMascotas = await _BDContext.TbRazaMascota.Select(razas => new SelectListItem()
                {
                    Text = razas.DescripcionRazMas,
                    Value = razas.IdRazMas.ToString()
                }).ToListAsync(),

                oListaALbergues = await _BDContext.TbAlbergues.Select(albergues => new SelectListItem()
                {
                    Text = albergues.NombreAlb,
                    Value = albergues.IdAlb.ToString()
                }).ToListAsync()

            };
        
            //Si es verdadero se carga el objeto a la vista 
            if (idMascota != 0)
            {
                oMascotaVM.oMascota = await _BDContext.TbMascota.FindAsync(idMascota);
            }
            return View(oMascotaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Mascota_Detalle(MascotaVM oMascotaVM, IFormFile ImagenMas)
        {
           //if (ModelState.IsValid)
           //{
                if (ImagenMas != null && ImagenMas.Length > 0)
                {
                    using var memorystream = new MemoryStream(); //Almacenamos temporalmente los datos en archivo de memoria
                    await ImagenMas.CopyToAsync(memorystream);   //Copiamos los datos a memoria
                    oMascotaVM.oMascota.ImagenMas = memorystream.ToArray(); // Asignar los bytes al campo ImagenMas en la entidad `TbMascotum`.
                }
              

                if (oMascotaVM.oMascota.IdMas == 0)
                {
                    //Creo la mascota
                    _BDContext.TbMascota.Add(oMascotaVM.oMascota);
                }
                else
                {
                //Actualizo la mascota
                _BDContext.TbMascota.Update(oMascotaVM.oMascota);
                }

                await _BDContext.SaveChangesAsync();

            //}
            return RedirectToAction(nameof(IndexMas));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int idMascota)
        {
            //TbAlbergue oAlbergue = await _BDContext.TbAlbergues.Include(d => d.oDistrito).Include(p => p.oProvincia).Where(a => a.IdAlb == idalbergue).FirstOrDefaultAsync();
            TbMascotum oMascota = await _BDContext.TbMascota.FindAsync(idMascota);
            _BDContext.TbMascota.Remove(oMascota);
            await _BDContext.SaveChangesAsync();
            return RedirectToAction(nameof(IndexMas));
        }
    }
}
