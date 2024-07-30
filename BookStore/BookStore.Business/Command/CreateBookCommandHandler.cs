using AutoMapper;
using BookStore.Base.Response;
using BookStore.Business.Cqrs;
using BookStore.Data.Domain;
using BookStore.Data.UnitOfWork;
using BookStore.Schema;
using MediatR;

namespace BookStore.Business.Command;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ApiResponse<BookResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<BookResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<BookRequest, Book>(request.Request);
        await unitOfWork.BookRepository.Insert(mapped);
        await unitOfWork.Complete();

        var response = mapper.Map<BookResponse>(mapped);
        return new ApiResponse<BookResponse>(response);
    }
}