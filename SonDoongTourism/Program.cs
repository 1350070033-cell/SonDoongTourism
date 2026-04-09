using Microsoft.EntityFrameworkCore;
using SonDoongTourism.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// --- THÊM ĐOẠN NÀY VÀO ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
    
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

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// --- THÊM ĐOẠN CODE NÀY VÀO TRƯỚC DÒNG app.Run(); ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Gọi hàm tự động nạp dữ liệu
        SonDoongTourism.Models.SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Có lỗi xảy ra khi nạp dữ liệu: " + ex.Message);
    }
}
// ----------------------------------------------------

app.Run(); // Dòng này là dòng cuối cùng có sẵn của file Program.cs
app.Run();
