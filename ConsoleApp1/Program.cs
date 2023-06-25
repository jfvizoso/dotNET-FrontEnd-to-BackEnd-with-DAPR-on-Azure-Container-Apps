// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Store.InventoryApi;

Console.WriteLine("Hello, World!");

var optionsBuilder = new DbContextOptionsBuilder<VizoContext>();
//optionsBuilder.UseSqlServer("Data Source=vizo-sql-server.database.windows.net;Initial Catalog=vizodb; Authentication=Active Directory Default; Encrypt=True;");
optionsBuilder.UseSqlServer("Server=tcp:vizo-sql-server.database.windows.net;Authentication=Active Directory Default; Database=vizodb;");
var context = new VizoContext(optionsBuilder.Options);

context.Database.Migrate();

