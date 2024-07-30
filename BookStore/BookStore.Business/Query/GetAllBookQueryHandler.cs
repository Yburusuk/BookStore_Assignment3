using MediatR;
using AutoMapper;
using BookStore.Base.Response;
using BookStore.Business.Cqrs;
using BookStore.Data.Domain;
using BookStore.Data.UnitOfWork;
using BookStore.Schema;

namespace BookStore.Business.Query;

public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery,ApiResponse<List<BookResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllBookQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    
    public async Task<ApiResponse<List<BookResponse>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        List<Book> entityList = await unitOfWork.BookRepository.GetAll();
        var mappedList = mapper.Map<List<BookResponse>>(entityList);
        return new ApiResponse<List<BookResponse>>(mappedList);
    }
}