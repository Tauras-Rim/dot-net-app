using Microsoft.EntityFrameworkCore;
using dot_net_example.Models;
using dot_net_example.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryContext>(opt =>
    opt.UseInMemoryDatabase("CustomerList"));

builder.Services.AddCustomerService();
builder.Services.AddBookService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();