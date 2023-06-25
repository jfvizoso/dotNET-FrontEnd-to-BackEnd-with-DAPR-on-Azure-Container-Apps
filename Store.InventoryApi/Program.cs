using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Store.InventoryApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache(); // we'll use cache to simulate storage
builder.Services.AddApplicationMonitoring();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/inventory/{productId}", (string productId, IMemoryCache memoryCache) =>
{
    var memCacheKey = $"{productId}-inventory";
    int inventoryValue = -404;
    
    if(!memoryCache.TryGetValue(memCacheKey, out inventoryValue))
    {
        inventoryValue = new Random().Next(1, 100);

        var optionsBuilder = new DbContextOptionsBuilder<VizoContext>();
        optionsBuilder.UseSqlServer("Server=tcp:vizo-sql-server.database.windows.net;Authentication=Active Directory Managed Identity;Encrypt=True;User Id=afc0352b-4272-4162-aa48-69ee65ca1a4b;Database=vizodb;");
        var context = new VizoContext(optionsBuilder.Options);
        inventoryValue = context.Vizo.Count();

        memoryCache.Set(memCacheKey, inventoryValue);
    }

    inventoryValue = memoryCache.Get<int>(memCacheKey);

    return Results.Ok(inventoryValue);
})
.Produces<int>(StatusCodes.Status200OK)
.WithName("GetInventoryCount");

var optionsBuilder = new DbContextOptionsBuilder<VizoContext>();
//optionsBuilder.UseSqlServer("Data Source=vizo-sql-server.database.windows.net;Initial Catalog=vizodb; Authentication=Active Directory Default; Encrypt=True;");
//optionsBuilder.UseSqlServer("Server=tcp:vizo-sql-server.database.windows.net;Authentication=Active Directory Default; Database=vizodb;");
optionsBuilder.UseSqlServer("Server=tcp:vizo-sql-server.database.windows.net;Authentication=Active Directory Managed Identity;Encrypt=True;User Id=afc0352b-4272-4162-aa48-69ee65ca1a4b;Database=vizodb;");
var context = new VizoContext(optionsBuilder.Options);
context.Database.Migrate();

app.Run();