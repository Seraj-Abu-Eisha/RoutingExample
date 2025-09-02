var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("files/{filename}.{extenson}", async context =>
{
   string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
    await context.Response.WriteAsync("In files");
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

    await context.Response.WriteAsync($"In files - {filename} - {extension}");
});

app.Map("map1", async (context) => {
    await context.Response.WriteAsync("In map 1");
});
app.Map("map2", async (context) => {
    await context.Response.WriteAsync("In map 2");
});
app.MapFallback (async (context) =>{
    await context.Response.WriteAsync($"Request at {context.Request.Path}");
});

app.Map("employee/profile/{employeename}", async context =>
{
    string? employeeName = Convert.ToString
        (context.Request.RouteValues["employeename"]);
    await context.Response.WriteAsync
        ($"In Employee profile - {employeeName}");
});
app.Run();
