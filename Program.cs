var builder = WebApplication.CreateBuilder(args);

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

/// <summary>
/// More specific routes first, generic ones last.
/// </summary>

app.MapControllerRoute(
    name: "FourSegments",
    pattern: "{controller}/{action}/{code}/{idnumber}");

app.MapControllerRoute(
    name: "variable",
    pattern: "query/{name}/{*values}",
    defaults: new { controller = "Home", action = "Process" });

app.MapControllerRoute(
    name: "student",
    pattern: "student/{enumber}",
    defaults: new { controller = "Home", action = "Details" });

/// <summary>
/// 3 segment route
/// {controller}/{action method}/{parameter}
/// home/index/123
/// product/details/345
/// </summary>
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
