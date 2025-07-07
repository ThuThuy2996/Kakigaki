using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class lesson_translation
{
    public int id { get; set; }

    public int? lesson_detail_id { get; set; }

    public string? language_code { get; set; }

    public string? translation { get; set; }

    public virtual lesson_detail? lesson_detail { get; set; }
}
