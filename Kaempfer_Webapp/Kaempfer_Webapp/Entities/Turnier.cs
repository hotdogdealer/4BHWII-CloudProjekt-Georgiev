using System;
using System.Collections.Generic;

namespace Kaempfer_Webapp.Entities;

public partial class Turnier
{
    public Guid Turnierid { get; set; }

    public string Ort { get; set; } = null!;

    public DateOnly? Turnierdatum { get; set; }

    public virtual ICollection<KaempferProTurnier> KaempferProTurnier { get; set; } = new List<KaempferProTurnier>();
}
