using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class user_daily_activity
{
    public int id { get; set; }

    public int? user_id { get; set; }

    public DateTime? activity_date { get; set; }

    public int? lessons_completed { get; set; }

    public int? study_time_minutes { get; set; }

    public DateTime? created_at { get; set; }

    public virtual user? user { get; set; }
}
