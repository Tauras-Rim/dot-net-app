//using Microsoft.EntityFrameworkCore;
//using dot_net_example.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddDbContext<CustomerContext>(opt =>
//    opt.UseInMemoryDatabase("CustomerList"));
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    //app.UseSwagger();
//    //app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using Microsoft.EntityFrameworkCore;
using dot_net_example.Models;
using dot_net_example.Services.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CustomerContext>(opt =>
    opt.UseInMemoryDatabase("CustomerList"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

//builder.Services.AddScoped<IGetService, GetService>();
//builder.Services.AddScoped<IPostService, PostService>();

//builder.Services.AddGetService();
//builder.Services.AddPostService();
//builder.Services.AddDeleteService();
//builder.Services.AddUpdateService();
builder.Services.AddCustomerService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();