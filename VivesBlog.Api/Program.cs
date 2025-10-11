using Microsoft.EntityFrameworkCore;
using VivesBlog.Repository;
using VivesBlog.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<VivesBlogDbContext>(options =>
{
    options.UseInMemoryDatabase(nameof(VivesBlogDbContext));
});

// Services
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<ArticleService>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Seed data
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<VivesBlogDbContext>();
    if (dbContext.Database.IsInMemory())
    {
        dbContext.Seed();
    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();