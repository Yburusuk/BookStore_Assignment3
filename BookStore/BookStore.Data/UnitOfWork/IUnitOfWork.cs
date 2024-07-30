using BookStore.Data.Domain;
using BookStore.Data.GenericRepository;

namespace BookStore.Data.UnitOfWork;

public interface IUnitOfWork
{
    Task Complete(); 
    Task CompleteWithTransaction();
    IGenericRepository<Book> BookRepository { get; }
}