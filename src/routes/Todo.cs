namespace APIRoutes;

public static class TodoEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/todos", async context =>
        {
            await context.Response.WriteAsJsonAsync(new { Message = "All todo items" });
        }).WithDescription("Sample Description");


        app.MapGet("/todos/{id}", async context =>
        {
            await context.Response.WriteAsJsonAsync(new { Message = "One todo item" });
        });
    }
}