using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class LessonDetail
{
    public int Id { get; set; }

    public int? LessonId { get; set; }

    public int? LessonIdSeq { get; set; }

    public int? StartTimeSeconds { get; set; }

    public int? EndTimeSeconds { get; set; }

    public string? Transcript { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual ICollection<LessonTranslation> LessonTranslations { get; set; } = new List<LessonTranslation>();
}
