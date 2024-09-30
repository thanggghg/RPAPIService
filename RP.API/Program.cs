using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using RP.API.Routes;

var builder = WebApplication.CreateBuilder(args);

//Add Services
builder.AddApplicationServices();
builder.AddGobalCoreExtension();

//Builder build
var app = builder.Build();
app.AddAppConfigure();

app.UseExceptionHandler(new ExceptionHandlerOptions()
{
    AllowStatusCode404Response = true,
});

//Add Route
app.AddRegisterRoutes();
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = CustomHealthCheckResponseWriter.WriteResponse
});
app.UseStaticFiles();
// Serve DocFX documentation at /docs
app.MapGet("/docs", context =>
{
    context.Response.Redirect("/docs/index.html", permanent: false);
    return Task.CompletedTask;  // Trả về Task.CompletedTask vì không có hành động không đồng bộ
});

//Run app
app.Run();

