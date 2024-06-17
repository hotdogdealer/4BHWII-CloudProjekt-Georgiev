using System;
using System.Collections.Generic;

namespace Kaempfer_Webapp.Entities;

public partial class Kaempfer
{
    public Guid Kaempferid { get; set; }

    public string Vorname { get; set; } = null!;

    public string Nachname { get; set; } = null!;

    public DateOnly? Geburtsdatum { get; set; }

    public virtual ICollection<KaempferProTurnier> KaempferProTurnier { get; set; } = new List<KaempferProTurnier>();
}
