using IngrEasy.API.Filters;
using IngrEasy.API.Middleware;
using IngrEasy.Application;
using IngrEasy.Infrastructure;
using IngrEasy.Infrastructure.Extensions;
using IngrEasy.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

MigrateDatabase();

app.Run();

void MigrateDatabase()
{

    
    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        DataBaseMigration.DatabaseMigration(serviceProvider);
    }
}

public partial class Program
{
    
}