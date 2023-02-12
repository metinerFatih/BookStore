using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public virtual List<Book>? Books { get; set; }
}