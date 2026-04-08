

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Se configura Acceso a variables de sesión en la aplicación a ser creada
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MySessionCookie";
});

var equiposURI = builder.Configuration.GetSection("Services:Equipos").Value;
System.Console.Error.WriteLine(equiposURI);
builder.Services.AddHttpClient<IEquiposService, EquiposService>(client =>
{    
    client.BaseAddress = new Uri(equiposURI);
    client.DefaultRequestHeaders.Add("Accept", "application/json");    
});
var IAMURI = builder.Configuration.GetSection("Services:IAM").Value;
builder.Services.AddHttpClient<IIdentidadService, IdentidadService>(client =>
{    
    client.BaseAddress = new Uri(IAMURI);
    client.DefaultRequestHeaders.Add("Accept", "application/json");    
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();



app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.UseSession();
app.Run();
