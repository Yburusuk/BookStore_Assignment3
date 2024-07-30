using AutoMapper;
using BookStore.Base.Response;
using BookStore.Business.Cqrs;
using BookStore.Data.Domain;
using BookStore.Data.UnitOfWork;
using BookStore.Schema;
using MediatR;

namespace BookStore.Business.Command;

public class UpdateBookCommandHandler :IRequestHandler<UpdateBookCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<BookRequest, Book>(request.Request);
        mapped.Id = request.BookId;
        unitOfWork.BookRepository.Update(mapped);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
}