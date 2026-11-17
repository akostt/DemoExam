using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPFApp.Models;

public partial class Order
{
    [Key]
    [Column("ID_Order")]
    public int IdOrder { get; set; }

    public DateOnly CreatedData { get; set; }

    [Column("User_ID")]
    public int UserId { get; set; }

    [InverseProperty("IdOrderNavigation")]
    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User User { get; set; } = null!;
}
