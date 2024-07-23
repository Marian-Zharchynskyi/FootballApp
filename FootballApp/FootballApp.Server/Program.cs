using FootballApp.Core.Context;
using FootballApp.Core.Entities;
using FootballManager.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// ��������� ����� �'������� � ������������
var connectionString = builder.Configuration.GetConnectionString("ProjectConnection")
    ?? throw new InvalidOperationException("Connection string 'ProjectConnection' not found.");

// ��������� ��������� ���� �����
builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(connectionString);
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ��������� ���������� �� ����� ������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ��������� ����������
builder.Services.AddScoped<IRepository<Match, Guid>, Repository<Match, Guid>>();
builder.Services.AddScoped<IRepository<Player, Guid>, Repository<Player, Guid>>();
builder.Services.AddScoped<IRepository<Statistics, Guid>, Repository<Statistics, Guid>>();
builder.Services.AddScoped<IRepository<Team, Guid>, Repository<Team, Guid>>();
builder.Services.AddScoped<IRepository<Tournament, Guid>, Repository<Tournament, Guid>>();
builder.Services.AddScoped<IRepository<Transfer, Guid>, Repository<Transfer, Guid>>();


var app = builder.Build();

// ������������ HTTP �������
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
