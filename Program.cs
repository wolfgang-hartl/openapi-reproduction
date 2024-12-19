using APIRoutes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.DebugEndpoints();



app.MapGet("/", () => "Hello World!");
app.MapGet("/hello/{id}", (int id) => "Hello World!");

TodoEndpoints.Map(app);



app.Run();
