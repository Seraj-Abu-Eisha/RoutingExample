var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("map1", async (context) => {
    await context.Response.WriteAsync("In map 1");
});
app.Map("map2", async (context) => {
    await context.Response.WriteAsync("In map 2");
});
app.MapFallback (async (context) =>{
    await context.Response.WriteAsync("Home Page");
});
app.Run();
