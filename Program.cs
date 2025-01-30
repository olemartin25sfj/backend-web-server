var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RentingService rentingService = new RentingService();



app.MapGet("/books", () =>
{
    var bookInventory = rentingService.ListAllBooks();
    var booksList = bookInventory.Select(inventoryEntry => inventoryEntry);

    return Results.Ok(booksList);
});

app.MapPost("/borrow", (BorrowRequest borrowRequest) =>{
    BorrowReceipt? receipt = rentingService.BorrowBook(borrowRequest.BookTitle);

   if (receipt == null)
   {
return Results.BadRequest("Not Available");
   } else
   {
    // return Results.Accepted($"Borrowed book: {receipt.BookTitle}");
    return Results.Ok(receipt);
   }
});

app.Run();
