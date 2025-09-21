using Microsoft.EntityFrameworkCore;
using MoodPlaylist.SQLite.Repository;
using MoodPlaylist.SQLite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext with SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register PlaylistService
builder.Services.AddScoped<PlaylistService>();

builder.Services.AddDbContext<PlaylistDbContext>(options =>
    options.UseSqlite("Data Source=playlist.db"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

//app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Playlist}/{action=Index}/{id?}");
    //.WithStaticAssets();


app.Run();
