using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class UserStatistic
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CurrentStreakDays { get; set; }

    public int? LongestStreakDays { get; set; }

    public int? TotalLessonsCompleted { get; set; }

    public int? TotalStudyTimeMinutes { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public virtual User? User { get; set; }
}
