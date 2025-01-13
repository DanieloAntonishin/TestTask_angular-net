using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["MsSql:ConnectionString"]; // Connection string to DB
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MySqlDbContext>(options => options.UseSqlServer(connectionString))       // Connection to DB 
    .AddTransient<IUserRepositories, UserRepositories>()                                               // DI for entity
    .AddTransient<IShortenerRepositories, ShortenerRepositories>();                                    // DI for entity


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
