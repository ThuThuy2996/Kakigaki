using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class lesson
{
    public int id { get; set; }

    public string? title { get; set; }

    public string? content { get; set; }

    public string? audio_url { get; set; }

    public int? category_id { get; set; }

    public int? level_id { get; set; }

    public int? access_level { get; set; }

    public DateTime? created_at { get; set; }

    public virtual category? category { get; set; }

    public virtual ICollection<lesson_detail> lesson_details { get; set; } = new List<lesson_detail>();

    public virtual ICollection<lesson_session> lesson_sessions { get; set; } = new List<lesson_session>();

    public virtual level? level { get; set; }
}
