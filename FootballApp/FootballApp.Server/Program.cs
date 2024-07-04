using FootballApp.Core.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ��������� ����� ���������� � ���������������� �����
var connectionString = builder.Configuration.GetConnectionString("ProjectConnection") ?? throw new InvalidOperationException("Connection string 'ProjectConnection' not found.");

// ��������� ��������� ���� ����� �� ������� ������� ��� ����������
builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(connectionString);
    options.AddDatabaseDeveloperPageExceptionFilter();
});

// ��������� ���������� �� ����� ������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ��������� ����� ����������, ���� ����� AddRepositories() ������� �� ��
builder.Services.AddRepositories();

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
