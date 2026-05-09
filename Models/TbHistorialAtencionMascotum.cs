using System;
using System.Collections.Generic;

namespace Albergue_aspnet_DAS.Models;

public partial class TbHistorialAtencionMascotum
{
    public int IdHis { get; set; }

    public int IdMas { get; set; }

    public string? NombreMed { get; set; }

    public string? ApellidosMed { get; set; }

    public string? CodColegiatura { get; set; }

    public string? ConsultaMedica { get; set; }

    public string? Observacion { get; set; }

    public virtual TbMascotum IdMasNavigation { get; set; } = null!;
}
