using System;
using System.Collections.Generic;

namespace Albergue_aspnet_DAS.Models;

public partial class TbDistrito
{
    public int IdDist { get; set; }

    public string? DescripcionDist { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<TbAlbergue> TbAlbergues { get; set; } = new List<TbAlbergue>();
}
