using System;
using System.Collections.Generic;

namespace Library_Management.Models.Data;

public partial class BookCopy
{
    public Guid Id { get; set; }

    public string CoverImageUrl { get; set; } = null!;

    public string Condition { get; set; } = null!;

    public string Source { get; set; } = null!;

    public DateTime AddedDate { get; set; }

    public DateTime PulloutDate { get; set; }

    public string PulloutReason { get; set; } = null!;
}
