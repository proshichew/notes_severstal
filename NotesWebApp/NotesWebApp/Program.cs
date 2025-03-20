using NotesWebApp.Components;
using NotesWebApp.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddControllers();

builder.Services.AddScoped<NoteService>();

var apiSettings = builder.Configuration.GetSection("ApiSettings");
var baseUrl = apiSettings["BaseUrl"];
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(NotesWebApp.Client._Imports).Assembly);



app.Run();
