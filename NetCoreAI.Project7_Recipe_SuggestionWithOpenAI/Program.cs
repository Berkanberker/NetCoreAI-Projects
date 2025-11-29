using NetCoreAI.Project7_Recipe_SuggestionWithOpenAI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Program.cs dosyanýzda builder bölümüne ekleyin:
builder.Services.AddScoped<GeminiService>();
// Veya HttpClient factory kullanýyorsanýz: builder.Services.AddHttpClient<GeminiService>();  
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
