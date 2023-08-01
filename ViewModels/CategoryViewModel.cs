namespace App.ViewModels;

public class CategoryViewModel
{
    public int CategoryId { get; set; }    
    public string CategoryName { get; set; } = default!;
    public int BookCount { get; set; }
    public double AverageBookNumberOfPages { get; set; }
}