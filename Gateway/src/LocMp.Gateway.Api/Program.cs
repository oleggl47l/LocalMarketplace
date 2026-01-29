using LocMp.Gateway.Api.Extensions;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();


builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: false,
    reloadOnChange: true);

builder.Host.AddSerilogLogging();

builder.Services.ConfigureOptions(builder.Configuration);
builder.Services.AddCorsConfiguration();
builder.Services.AddJwtAuthentication();
builder.Services.AddGateway(builder.Configuration);
builder.Services.AddDocumentation(builder.Configuration);

var app = builder.Build();

app.UseCors();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerForOcelotUI();
}

app.UseRouting();
app.MapControllers();

await app.UseOcelot();

await app.RunAsync();