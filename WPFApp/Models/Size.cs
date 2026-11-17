using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPFApp.Models;

public partial class Size
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("Size", TypeName = "decimal(4, 1)")]
    public decimal Size1 { get; set; }

    [InverseProperty("IdSizeNavigation")]
    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    [InverseProperty("IdSizeNavigation")]
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
