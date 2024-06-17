using System;
using System.Collections.Generic;

namespace Kaempfer_Webapp.Entities;

public partial class Gewichtklasse
{
    public Guid Gewichtklasseid { get; set; }

    public int? Gewicht { get; set; }

    public string? Gewichtklasse1 { get; set; }
}
