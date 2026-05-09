using System;
using System.Collections.Generic;

namespace Albergue_aspnet_DAS.Models;

public partial class TbProvincia
{
    public int IdProv { get; set; }

    public string? DescripcionProv { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<TbAlbergue> TbAlbergues { get; set; } = new List<TbAlbergue>();
}
