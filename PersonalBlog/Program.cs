using Amazon.DynamoDBv2.DataModel;
using PersonalBlog.Interface;
using PersonalBlog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

DynamoServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void DynamoServices(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddScoped<IAuthorize, IpBasedAuthorizer>();
    builder.Services.AddScoped<ProtectorAttribute>();
}