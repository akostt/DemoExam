using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPFApp.Models;

[Table("Order_Products")]
public partial class OrderProduct
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ID_Order")]
    public int IdOrder { get; set; }

    [Column("ID_Product")]
    public int IdProduct { get; set; }

    [Column("ID_Size")]
    public int IdSize { get; set; }

    public int Count { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Price { get; set; }

    [ForeignKey("IdOrder")]
    [InverseProperty("OrderProducts")]
    public virtual Order IdOrderNavigation { get; set; } = null!;

    [ForeignKey("IdProduct")]
    [InverseProperty("OrderProducts")]
    public virtual Product IdProductNavigation { get; set; } = null!;

    [ForeignKey("IdSize")]
    [InverseProperty("OrderProducts")]
    public virtual Size IdSizeNavigation { get; set; } = null!;
}
