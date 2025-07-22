using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class LessonSession
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? LessonId { get; set; }

    public int? DurationMinutes { get; set; }

    public int? LastSequence { get; set; }

    public int? TotalCompletedTimes { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual User? User { get; set; }
}
