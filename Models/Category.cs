using System.Collections.ObjectModel;

namespace App.Models;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public ICollection<Book> Books { get; private set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
        Books = new Collection<Book>();
    }
}