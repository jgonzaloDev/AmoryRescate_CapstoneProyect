using System;
using System.Collections.Generic;

namespace Albergue_aspnet_DAS.Models;

public partial class TbMascotum
{
    public int IdMas { get; set; }

    public string? NombreMas { get; set; }

    public int IdTipMas { get; set; }

    public int IdRazMas { get; set; }

    public string SexoMas { get; set; } = null!;

    public string? TamanioMas { get; set; }

    public string? ColorMas { get; set; }

    public DateOnly? FechaNacMas { get; set; }

    public int? EdadMas { get; set; }

    public byte[]? ImagenMas { get; set; }

    public bool Estado { get; set; }

    public int IdAlb { get; set; }

    public virtual TbAlbergue? oAlbergue { get; set; }

    public virtual TbRazaMascotum? oRazaMascota { get; set; }

    public virtual TbTipoMascotum? oTipoMascota { get; set; }

    public virtual ICollection<TbAdopcion> TbAdopcions { get; set; } = new List<TbAdopcion>();

    public virtual ICollection<TbHistorialAtencionMascotum> TbHistorialAtencionMascota { get; set; } = new List<TbHistorialAtencionMascotum>();
}
