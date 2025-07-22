using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class RefreshToken
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? RefreshToken1 { get; set; }

    public DateTime? IssuedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public bool? Revoked { get; set; }

    public virtual User? User { get; set; }
}
