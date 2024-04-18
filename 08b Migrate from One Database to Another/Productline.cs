using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseMigration;

public partial class Productline
{
    [Key]

    public string ProductLine1 { get; set; } = null!;

    public string? TextDescription { get; set; }

    public string? HtmlDescription { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
