namespace Microsoft.AspNetCore.Builder
{
    public static class DebugEndpointExtension
    {
        public static IEndpointConventionBuilder DebugEndpoints(this IEndpointRouteBuilder app)
        {
            return app.MapGet("/debug", async context =>
            {
                var endpointList = app.DataSources
                    .SelectMany(ds => ds.Endpoints)
                    .Select(e => new
                    {
                        DisplayName = e.DisplayName,
                        Path = (e as RouteEndpoint)?.RoutePattern.RawText
                    })
                    .ToList();

                await context.Response.WriteAsJsonAsync(endpointList);
            });
        }
    }
}