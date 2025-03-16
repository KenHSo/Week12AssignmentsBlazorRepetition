using Week12AssignmentsBlazorRepetition;
using Week12AssignmentsBlazorRepetition.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registrer AppState som en Singleton - Dvs. at der kun findes én (som deles) og at der ikke kan laves nye instanser af den.
builder.Services.AddSingleton<AppState>();

builder.Services.AddDbContext<ItemDb>(options =>
{
    options.UseInMemoryDatabase("ItemDb");
});

var app = builder.Build();

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ItemDb>();
    dbContext.Database.EnsureCreated(); // Ensures DB is created and applies seed data
    Console.WriteLine("Database initialized and seeded.");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
