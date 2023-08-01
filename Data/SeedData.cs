using App.Models;

namespace App.Data;

public static class SeedData
{
    public static IApplicationBuilder Seed(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        DeleteData(context);
        CreateData(context);
        
        return app;
    }

    private static void CreateData(AppDbContext context)
    {
        // Categories
        var categories = new Category[]
        {
            new Category(1, "Fantasy"),
            new Category(2, "Horror")
        };
        
        context.Categories.AddRange(categories);

        // Books
        var books = new Book[]
        {
            new Book(1, categories[0].Id, "The Lord of The Rings", 1178, new DateTime(1954, 7, 29)),
            new Book(2, categories[0].Id, "The Hobbit", 320, new DateTime(1937, 9, 21)),
            new Book(3, categories[1].Id, "The Shining", 688, new DateTime(1977, 1, 28))
        };

        context.Books.AddRange(books);
        
        context.SaveChanges(); 
    }

    private static void DeleteData(AppDbContext context)
    {
        context.Books.RemoveRange(context.Books);
        context.Categories.RemoveRange(context.Categories);
        
        context.SaveChanges(); 
    }
}