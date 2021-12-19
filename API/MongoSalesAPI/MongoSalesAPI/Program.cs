using MongoSalesAPI.Models;
using MongoSalesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add the confgiration section for the mongoDB into the services
builder.Services.Configure<SalesDatabaseSettings>(builder.Configuration.GetSection("SalesDatabase"));

// Add to the Dependency Injection container. This creates the singleton instance upfront and will be shared when required
builder.Services.AddSingleton<SalesService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
