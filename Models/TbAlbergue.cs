using System;
using System.Collections.Generic;

namespace Albergue_aspnet_DAS.Models;

public partial class TbAlbergue
{
    public int IdAlb { get; set; }

    public string? NombreAlb { get; set; }

    public string? DireccionAlb { get; set; }

    public int? IdDist { get; set; }

    public int? IdProv { get; set; }

    public int? CapacidadAlb { get; set; }

    public string? CorreoAlb { get; set; }

    public bool Estado { get; set; }

    public virtual TbDistrito? oDistrito { get; set; }

    public virtual TbProvincia? oProvincia { get; set; }

    public virtual ICollection<TbMascotum> TbMascota { get; set; } = new List<TbMascotum>();
}
