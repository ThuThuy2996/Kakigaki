using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class user
{
    public int id { get; set; }

    public string? google_id { get; set; }

    public string email { get; set; } = null!;

    public string? displayname { get; set; }

    public string? password_hash { get; set; }

    public int? role { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<lesson_session> lesson_sessions { get; set; } = new List<lesson_session>();

    public virtual ICollection<refresh_token> refresh_tokens { get; set; } = new List<refresh_token>();

    public virtual ICollection<user_daily_activity> user_daily_activities { get; set; } = new List<user_daily_activity>();

    public virtual ICollection<user_statistic> user_statistics { get; set; } = new List<user_statistic>();
}
