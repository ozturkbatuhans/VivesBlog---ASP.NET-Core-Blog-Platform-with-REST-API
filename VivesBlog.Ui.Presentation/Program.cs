using Microsoft.EntityFrameworkCore;
using VivesBlog.Repository;
using VivesBlog.Sdk;
using VivesBlog.Services;
using VivesBlog.Ui.Presentation;
using VivesBlog.Ui.Presentation.ApiServices;
using VivesBlog.Sdk;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// AppSettings
var appSettings = new AppSettings();
builder.Configuration.Bind(nameof(AppSettings), appSettings);
builder.Services.AddSingleton(appSettings);

// SDK
builder.Services.AddVivesBlogSdk(appSettings.ApiBaseUrl);

builder.Services.AddDbContext<VivesBlogDbContext>(options =>
{
    options.UseInMemoryDatabase(nameof(VivesBlogDbContext));
});

// HttpClient
builder.Services.AddScoped<ArticleService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<VivesBlogDbContext>();
    if (dbContext.Database.IsInMemory())
    {
        dbContext.Seed();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<VivesBlogDbContext>();
    if (dbContext.Database.IsInMemory())
    {
        dbContext.Seed();
    }
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
