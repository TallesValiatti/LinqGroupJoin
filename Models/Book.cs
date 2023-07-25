namespace App.Models;
public class Book
{
    public int Id { get; private set; }
    public int CategoryId { get; private set; }
    public string Name { get; private set; }
    public int NumberOfPages { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public Category Category { get; private set; } = default!;
    
    public Book(int id, int categoryId , string name, int numberOfPages, DateTime releaseDate)
    {
        Id = id;   
        CategoryId = categoryId;
        Name = name;
        NumberOfPages = numberOfPages;
        ReleaseDate = releaseDate;
    }
}