using BuberDinner.Application;
using BuberDinner.Presentation.BuberDinner.Api.Middleware;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
//options => options.Filters.Add<ErrorFilters>());

var app = builder.Build();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

//app.ConfigureCustomExceptionMiddleware();
app.MapControllers();
app.Run();
