using System;
using System.Collections.Generic;

namespace Kakigaki.Infrastructure.Data.Models;

public partial class lesson_session
{
    public int id { get; set; }

    public int? user_id { get; set; }

    public int? lesson_id { get; set; }

    public int? duration_minutes { get; set; }

    public int? last_sequence { get; set; }

    public int? total_completed_times { get; set; }

    public virtual lesson? lesson { get; set; }

    public virtual user? user { get; set; }
}
