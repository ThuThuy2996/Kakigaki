using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string? GoogleId { get; set; }

    public string Email { get; set; } = null!;

    public string? Displayname { get; set; }

    public string? PasswordHash { get; set; }

    public int? Role { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<LessonSession> LessonSessions { get; set; } = new List<LessonSession>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<UserDailyActivity> UserDailyActivities { get; set; } = new List<UserDailyActivity>();

    public virtual ICollection<UserStatistic> UserStatistics { get; set; } = new List<UserStatistic>();
}
