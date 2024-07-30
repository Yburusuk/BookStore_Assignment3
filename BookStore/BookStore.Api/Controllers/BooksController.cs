using BookStore.Base.Response;
using BookStore.Business.Cqrs;
using BookStore.Data.Domain;
using BookStore.Schema;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMediator mediator;
        
    public BooksController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ApiResponse<List<BookResponse>>> Get()
    {
        var operation = new GetAllBookQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("{bookId}")]
    public async Task<ApiResponse<BookResponse>> Get([FromRoute] int bookId)
    {
        var operation = new GetBookByIdQuery(bookId);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<ApiResponse<BookResponse>> Post([FromBody] BookRequest value)
    {
        var operation = new CreateBookCommand(value);
        var result = await mediator.Send(operation);
        return result;
    }
    
    [HttpPut("{bookId}")]
    public async Task<ApiResponse> Put(int bookId, [FromBody] BookRequest value)
    {
        var operation = new UpdateBookCommand(bookId,value);
        var result = await mediator.Send(operation);
        return result;
    }
}