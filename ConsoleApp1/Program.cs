// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Store.InventoryApi;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

Console.WriteLine("Hello, World!");

var optionsBuilder = new DbContextOptionsBuilder<VizoContext>();
//optionsBuilder.UseSqlServer("Data Source=vizo-sql-server.database.windows.net;Initial Catalog=vizodb; Authentication=Active Directory Default; Encrypt=True;");
optionsBuilder.UseSqlServer("Server=tcp:vizo-sql-server.database.windows.net;Authentication=Active Directory Default; Database=vizodb;");
// CAN'T TO THIS
// optionsBuilder.UseSqlServer("Server=tcp:vizo-sql-server.database.windows.net;Authentication=Active Directory Managed Identity;Encrypt=True;User Id=afc0352b-4272-4162-aa48-69ee65ca1a4b;Database=vizodb;");

var context = new VizoContext(optionsBuilder.Options);

context.Database.Migrate();

