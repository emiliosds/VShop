﻿namespace VShop.ProductApi.Models;

public class Category : Entity
{
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}