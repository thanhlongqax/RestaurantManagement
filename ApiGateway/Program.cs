using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Config/ocelot.json", optional: false, reloadOnChange: true);
// Đăng ký CORS với policy cho phép localhost:3000
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:3000")
                     .AllowAnyHeader()
                     .AllowAnyMethod();
    });
});
// Đăng ký Ocelot
builder.Services.AddOcelot();

var app = builder.Build();
// Áp dụng middleware CORS trước khi Ocelot
app.UseCors("AllowLocalhost3000");
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
});
app.UseOcelot().Wait();

app.Run();
