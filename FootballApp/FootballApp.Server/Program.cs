using FootballApp.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ProjectConnection")
    ?? throw new InvalidOperationException("Connection string 'ProjectConnection' not found.");

builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(connectionString);
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Додавання контролерів та інших сервісів
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddRepositories();

var app = builder.Build();

// Налаштування HTTP конвеєра
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
