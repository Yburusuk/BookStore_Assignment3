namespace BookStore.Schema;

public class BookRequest 
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal Price { get; set; }
}

public class BookResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal Price { get; set; }
}