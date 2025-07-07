using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class lesson_detail
{
    public int id { get; set; }

    public int? lesson_id { get; set; }

    public int? lesson_id_seq { get; set; }

    public int? start_time_seconds { get; set; }

    public int? end_time_seconds { get; set; }

    public string? transcript { get; set; }

    public virtual lesson? lesson { get; set; }

    public virtual ICollection<lesson_translation> lesson_translations { get; set; } = new List<lesson_translation>();
}
