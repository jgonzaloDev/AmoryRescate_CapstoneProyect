using System;
using System.Collections.Generic;

namespace Albergue_aspnet_DAS.Models;

public partial class TbRolesUsuario
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public virtual ICollection<TbUsuario> TbUsuarios { get; set; } = new List<TbUsuario>();
}
