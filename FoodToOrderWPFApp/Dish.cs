using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrderWPFApp;

[Keyless]
[Table("Dish")]
public partial class Dish
{
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DishName { get; set; } = null!;

    public bool Available { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public int RestaurantId { get; set; }

    public string? ImagePath { get; set; }
}
