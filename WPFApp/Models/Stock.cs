using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPFApp.Models;

[Table("Stock")]
public partial class Stock
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ID_Product")]
    public int IdProduct { get; set; }

    [Column("ID_Size")]
    public int IdSize { get; set; }

    public int Count { get; set; }

    [ForeignKey("IdProduct")]
    [InverseProperty("Stocks")]
    public virtual Product IdProductNavigation { get; set; } = null!;

    [ForeignKey("IdSize")]
    [InverseProperty("Stocks")]
    public virtual Size IdSizeNavigation { get; set; } = null!;
}
