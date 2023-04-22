using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VShop.Web.Models;

public class ProductViewModel
{
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public long Stock { get; set; }
    [Required]
    public string? ImageUrl { get; set; }
    public string? CategoryName { get; set; }

    [DisplayName("Category")]
    public Guid CategoryId { get; set; }
}