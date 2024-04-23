using System;
using System.Collections.Generic;

namespace UnitOfWorkPractise.Models;

public partial class HomemoStatus
{
    public string? BranchCode { get; set; }

    public byte? TrMonth { get; set; }

    public byte? TrYear { get; set; }

    public string Status { get; set; } = null!;

    public byte PreparedBy { get; set; }

    public DateTime PreparedDate { get; set; }

    public byte SentBy { get; set; }

    public DateTime SentDate { get; set; }
}
