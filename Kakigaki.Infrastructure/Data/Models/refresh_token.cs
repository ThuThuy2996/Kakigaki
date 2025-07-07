using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class refresh_token
{
    public int id { get; set; }

    public int? user_id { get; set; }

    public string? refresh_token1 { get; set; }

    public DateTime? issued_at { get; set; }

    public DateTime? expires_at { get; set; }

    public bool? revoked { get; set; }

    public virtual user? user { get; set; }
}
