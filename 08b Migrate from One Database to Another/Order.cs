﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseMigration;

public partial class Order
{
    [Key]

    public int OrderNumber { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly RequiredDate { get; set; }

    public DateOnly? ShippedDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Comments { get; set; }

    public int CustomerNumber { get; set; }

    public virtual Customer CustomerNumberNavigation { get; set; } = null!;

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
