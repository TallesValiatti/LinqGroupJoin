using App.Models;

namespace App.Data;

public static class SeedData
{
    public static IApplicationBuilder Seed(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        // Categories
        var categories = new Category[]
        {
            new Category(1, "Fantasy"),
            new Category(2, "Horror")
        };
        
        var books = new Book[]
        {
            new Book(1, categories[0].Id, "The Lord of The Rings", 1178, new DateTime(1954, 7, 29))
        };

        context.Categories.AddRange(categories);
        context.Books.AddRange(books);
        
        context.SaveChanges(); 
        
        return app;
    }      
}