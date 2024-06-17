using System;
using System.Collections.Generic;

namespace Kaempfer_Webapp.Entities;

public partial class KaempferProTurnier
{
    public Guid KaempferProTurnierid { get; set; }

    public Guid Kaempferid { get; set; }

    public Guid Turnierid { get; set; }

    public virtual Kaempfer Kaempfer { get; set; } = null!;

    public virtual Turnier Turnier { get; set; } = null!;
}
