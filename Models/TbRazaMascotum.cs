using System;
using System.Collections.Generic;

namespace Albergue_aspnet_DAS.Models;

public partial class TbRazaMascotum
{
    public int IdRazMas { get; set; }

    public string DescripcionRazMas { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<TbMascotum> TbMascota { get; set; } = new List<TbMascotum>();
}
