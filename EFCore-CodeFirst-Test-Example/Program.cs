using EFCore_CodeFirst_Test_Example.Infrastructure;
using EFCore_CodeFirst_Test_Example.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi(); // Natywne rozwiązanie .NET
builder.Services.AddScoped<IDbService, DbService>();

builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        x => x.MigrationsHistoryTable("EFCore_Migrations", builder.Configuration["DB:DefaultSchema"])
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();