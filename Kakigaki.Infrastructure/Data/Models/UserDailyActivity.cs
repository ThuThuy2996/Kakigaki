using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class UserDailyActivity
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? ActivityDate { get; set; }

    public int? LessonsCompleted { get; set; }

    public int? StudyTimeMinutes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
