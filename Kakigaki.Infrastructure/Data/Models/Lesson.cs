using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? AudioUrl { get; set; }

    public int? CategoryId { get; set; }

    public int? LevelId { get; set; }

    public int? AccessLevel { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<LessonDetail> LessonDetails { get; set; } = new List<LessonDetail>();

    public virtual ICollection<LessonSession> LessonSessions { get; set; } = new List<LessonSession>();

    public virtual Level? Level { get; set; }
}
