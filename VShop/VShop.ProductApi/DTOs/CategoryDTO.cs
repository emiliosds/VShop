using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VShop.ProductApi.DTOs;

public class CategoryDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "The name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [JsonIgnore]
    public ICollection<ProductDTO>? Products { get; set; }
}