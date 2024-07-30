using AutoMapper;
using BookStore.Data.Domain;
using BookStore.Schema;

namespace BookStore.Business.Mapper;

public class MapperConfig : Profile
{

    public MapperConfig()
    {
        CreateMap<Book, BookResponse>();
        CreateMap<BookRequest, Book>();
    }
}