using MediatR;
using BookStore.Base.Response;
using BookStore.Schema;

namespace BookStore.Business.Cqrs;

public record CreateBookCommand(BookRequest Request) : IRequest<ApiResponse<BookResponse>>;
public record UpdateBookCommand(int BookId, BookRequest Request) : IRequest<ApiResponse>;
public record DeleteBookCommand(int BookId) : IRequest<ApiResponse>;

public record GetAllBookQuery() : IRequest<ApiResponse<List<BookResponse>>>;
public record GetBookByIdQuery(int bookId) : IRequest<ApiResponse<BookResponse>>;