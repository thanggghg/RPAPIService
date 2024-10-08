﻿using RP.API.Routes;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

//Add Services
builder.AddApplicationServices();
builder.RPExtension();

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

//Run app
app.Run();

