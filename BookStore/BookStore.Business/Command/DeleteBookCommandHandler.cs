using AutoMapper;
using BookStore.Base.Response;
using BookStore.Business.Cqrs;
using BookStore.Data.Domain;
using BookStore.Data.UnitOfWork;
using BookStore.Schema;
using MediatR;

namespace BookStore.Business.Command;

public class DeleteBookCommandHandler :IRequestHandler<DeleteBookCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public DeleteBookCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.BookRepository.Delete(request.BookId);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
}