using System;
using System.Collections.Generic;

namespace Albergue_aspnet_DAS.Models;

public partial class TbTipoMascotum
{
    public int IdTipMas { get; set; }

    public string? DescripcionTipMas { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<TbMascotum> TbMascota { get; set; } = new List<TbMascotum>();
}
