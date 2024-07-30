using System.ComponentModel.DataAnnotations.Schema;
using BookStore.Base.Entity;

namespace BookStore.Data.Domain;

[Table("Book", Schema = "dbo")]
public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
    public decimal Price { get; set; }
}