using System;
using System.Collections.Generic;

namespace Albergue_aspnet_DAS.Models;

public partial class TbAdopcion
{
    public int IdAdop { get; set; }

    public int? IdUs { get; set; }

    public string? DniUs { get; set; }

    public string? TelefonoUs { get; set; }

    public string? DireccionUs { get; set; }

    public int? IdMas { get; set; }

    public DateOnly? FechaAdop { get; set; }

    public string? Obs1Adop { get; set; }

    public string? Obs2Adop { get; set; }

    public string? Obs3Adop { get; set; }

    public string? Obs4Adop { get; set; }

    public string? Obs5Adop { get; set; }

    public string? Obs6Adop { get; set; }

    public string? Obs7Adop { get; set; }

    public string? Obs8Adop { get; set; }

    public string? Obs9Adop { get; set; }

    public string? Obs10Adop { get; set; }

    public virtual TbMascotum? IdMasNavigation { get; set; }

    public virtual TbUsuario? IdUsNavigation { get; set; }
}
