using Microsoft.AspNetCore.Mvc;
using ToDoManagement.Api.DTOs.Categories;
using ToDoManagement.Application.UseCases.Categories.CreateCategory;
using ToDoManagement.Application.UseCases.Categories.Queries.GetDetailCategory;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<DetailCategoryDTO>> Get(Guid id)
    {
        var query = new GetDetailCategoryQuery() { Id = id};
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCategoryDto createCategoryDto)
    {
        var command = new CreateCategoryCommand() { Name = createCategoryDto.Name };
        await _mediator.Send(command);
        return Ok();
    }
}
