using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class user_statistic
{
    public int id { get; set; }

    public int? user_id { get; set; }

    public int? current_streak_days { get; set; }

    public int? longest_streak_days { get; set; }

    public int? total_lessons_completed { get; set; }

    public int? total_study_time_minutes { get; set; }

    public DateTime? last_login_date { get; set; }

    public virtual user? user { get; set; }
}
