using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrderWPFApp;

[Keyless]
public partial class Restaurant
{
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string RestaurantName { get; set; } = null!;

    public bool Open { get; set; }

    public int UserId { get; set; }
}
