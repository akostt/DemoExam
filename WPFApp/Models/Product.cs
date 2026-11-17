using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WPFApp.Models;

public partial class Product
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ID_Category")]
    public int IdCategory { get; set; }

    [Column("ID_Subcategory")]
    public int IdSubcategory { get; set; }

    [StringLength(260)]
    public string Image { get; set; } = null!;

    [StringLength(300)]
    public string Name { get; set; } = null!;

    [Column("ID_Manufacturer")]
    public int IdManufacturer { get; set; }

    public string Description { get; set; } = null!;

    public string Structure { get; set; } = null!;

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Price { get; set; }

    [ForeignKey("IdCategory")]
    [InverseProperty("Products")]
    public virtual Category IdCategoryNavigation { get; set; } = null!;

    [ForeignKey("IdManufacturer")]
    [InverseProperty("Products")]
    public virtual Manufacturer IdManufacturerNavigation { get; set; } = null!;

    [ForeignKey("IdSubcategory")]
    [InverseProperty("Products")]
    public virtual Subcategory IdSubcategoryNavigation { get; set; } = null!;

    [InverseProperty("IdProductNavigation")]
    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    [InverseProperty("IdProductNavigation")]
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
