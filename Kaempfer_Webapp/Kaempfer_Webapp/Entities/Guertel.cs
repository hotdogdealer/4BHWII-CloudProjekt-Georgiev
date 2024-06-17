using System;
using System.Collections.Generic;

namespace Kaempfer_Webapp.Entities;

public partial class Guertel
{
    public Guid Guertelid { get; set; }

    public DateOnly? DatumDerPruefung { get; set; }

    public int? Guertelgrad { get; set; }
}
