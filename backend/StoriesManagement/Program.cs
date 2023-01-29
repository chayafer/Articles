using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoriesManagement.Models;
using StoriesManagement.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddControllers();

builder.Services.AddScoped<IArticlesService, ArticlesService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(x => x
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
}

app.UseAuthorization();

app.MapControllers();

app.Run();
