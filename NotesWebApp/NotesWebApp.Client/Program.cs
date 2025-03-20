using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NotesWebApp.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<NoteService>();

await builder.Build().RunAsync();
