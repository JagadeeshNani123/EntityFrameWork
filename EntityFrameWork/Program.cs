using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EntityFrameWork.Data;
using EntityFrameWork.Controllers;
 
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EntityFrameWorkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EntityFrameWorkContext") ?? throw new InvalidOperationException("Connection string 'EntityFrameWorkContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.MapStudentEndpoints();

app.Run();
