var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RentingService rentingService = new RentingService();



app.MapGet("/", () =>
{
    var bookInventory = rentingService.ListAllBooks();
    var booksList = bookInventory.Select(inventoryEntry => inventoryEntry);

    return Results.Ok(booksList);
});


app.Run();
