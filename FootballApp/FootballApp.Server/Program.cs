using FootballApp.Core.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Отримання рядка підключення з конфігураційного файлу
var connectionString = builder.Configuration.GetConnectionString("ProjectConnection") ?? throw new InvalidOperationException("Connection string 'ProjectConnection' not found.");

// Додавання контексту бази даних та фільтра винятків для розробників
builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(connectionString);
    options.AddDatabaseDeveloperPageExceptionFilter();
});

// Додавання контролерів та інших сервісів
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Додавання ваших репозиторіїв, якщо метод AddRepositories() відповідає за це
builder.Services.AddRepositories();

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
