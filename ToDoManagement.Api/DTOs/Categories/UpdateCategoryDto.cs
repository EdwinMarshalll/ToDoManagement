using System.ComponentModel.DataAnnotations;

namespace ToDoManagement.Api.DTOs.Categories;

public class UpdateCategoryDto
{
    [Required]
    [StringLength(150)]
    public required string Name { get; set; }
}
