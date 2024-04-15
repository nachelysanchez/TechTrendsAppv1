using Blazored.Toast;
using Microsoft.EntityFrameworkCore;
using TechTrendsAppv1.BLL.PublicacionesServices;
using TechTrendsAppv1.BLL.Roles;
using TechTrendsAppv1.BLL.RolesServices;
using TechTrendsAppv1.BLL.UsuariosServices;
using TechTrendsAppv1.Components;
using TechTrendsAppv1.DAL;
using TechTrendsAppv1.Sesion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

/* Blazored Toast */
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<SesionDto>();
builder.Services.AddScoped<IRolesService, RolesBLL>();
builder.Services.AddScoped<IUsuariosService, UsuariosBLL>();
builder.Services.AddScoped<IPublicacionesService, PublicacionesBLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
