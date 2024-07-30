using MediatR;
using AutoMapper;
using BookStore.Base.Response;
using BookStore.Business.Cqrs;
using BookStore.Data.UnitOfWork;
using BookStore.Schema;

namespace BookStore.Business.Query;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery,ApiResponse<BookResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetBookByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<BookResponse>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.BookRepository.GetById(request.bookId);
        var mapped = mapper.Map<BookResponse>(entity);
        return new ApiResponse<BookResponse>(mapped);
    }
}