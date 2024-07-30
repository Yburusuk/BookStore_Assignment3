using BookStore.Data.Context;
using BookStore.Data.Domain;
using BookStore.Data.GenericRepository;

namespace BookStore.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly BookDbContext dbContext;
    
    public IGenericRepository<Book> BookRepository { get; }

    public UnitOfWork(BookDbContext dbContext)
    {
        this.dbContext = dbContext;

        BookRepository = new GenericRepository<Book>(this.dbContext);
    }

    public void Dispose()
    {
    }

    public async Task Complete()
    {
        await dbContext.SaveChangesAsync();
    }
    
    public async Task CompleteWithTransaction()
    {
        using (var dbTransaction = await dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await dbContext.SaveChangesAsync();
                await dbTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await dbTransaction.RollbackAsync();
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}