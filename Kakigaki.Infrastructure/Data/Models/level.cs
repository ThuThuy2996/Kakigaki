using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class level
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? description { get; set; }

    public virtual ICollection<lesson> lessons { get; set; } = new List<lesson>();
}
