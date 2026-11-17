using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPFApp.Models;

[Table("Subcategory")]
public partial class Subcategory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(200)]
    public string Name { get; set; } = null!;

    [InverseProperty("IdSubcategoryNavigation")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
