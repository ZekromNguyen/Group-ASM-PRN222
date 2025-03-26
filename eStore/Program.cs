using Application;
using eStore.Components;
using Infrastructure;
using Infrastructure.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Đăng ký dependency từ các tầng
builder.Services
    .AddInfrastructure(builder.Configuration) // Infrastructure Layer
    .AddApplication();                        // Application Layer

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Map SignalR Hub
app.MapHub<RealTimeHub>("/realtimehub");

app.Run();