using Microsoft.AspNetCore.Mvc;
using ToDoManagement.Api.DTOs.Categories;
using ToDoManagement.Application.UseCases.Categories.CreateCategory;
using ToDoManagement.Application.Utilities.Mediator;

namespace ToDoManagement.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCategoryDto createCategoryDto)
    {
        var command = new CreateCategoryCommand() { Name = createCategoryDto.Name };
        await _mediator.Send(command);
        return Ok();
    }
}
