// See https://aka.ms/new-console-template for more information
using Google.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Store;

Console.WriteLine("Hello, World!");

var optionsBuilder = new DbContextOptionsBuilder<VizoContext>();
optionsBuilder.UseSqlServer("Data Source=vizo-sql-server.database.windows.net;Initial Catalog=vizodb; Authentication=Active Directory Default; Encrypt=True;");
var context = new VizoContext(optionsBuilder.Options);

context.Database.Migrate();

