using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class LessonTranslation
{
    public int Id { get; set; }

    public int? LessonDetailId { get; set; }

    public string? LanguageCode { get; set; }

    public string? Translation { get; set; }

    public virtual LessonDetail? LessonDetail { get; set; }
}
