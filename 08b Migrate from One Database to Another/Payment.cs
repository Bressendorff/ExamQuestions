using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseMigration;

public partial class Payment
{
    [Key]

    public int CustomerNumber { get; set; }

    public string CheckNumber { get; set; } = null!;

    public DateOnly PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public virtual Customer CustomerNumberNavigation { get; set; } = null!;
}
