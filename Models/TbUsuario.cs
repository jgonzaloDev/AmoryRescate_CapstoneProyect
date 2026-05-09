using System;
using System.Collections.Generic;

namespace Albergue_aspnet_DAS.Models;

public partial class TbUsuario
{
    public int IdUs { get; set; }

    public string? NombreUs { get; set; }

    public string? CorreoUs { get; set; }

    public string? ClaveUs { get; set; }

    public int? IdRol { get; set; }

    public byte[]? ImagenUs { get; set; }

    public virtual TbRolesUsuario? IdRolNavigation { get; set; }

    public virtual ICollection<TbAdopcion> TbAdopcions { get; set; } = new List<TbAdopcion>();
}
