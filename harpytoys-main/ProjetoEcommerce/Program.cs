using ProjetoEcommerce.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// Sessão
builder.Services.AddSession();

// Repositórios (injeção de dependência)
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<CadProdutoRepositorio>(); // <- ESSENCIAL

var app = builder.Build();

app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();
