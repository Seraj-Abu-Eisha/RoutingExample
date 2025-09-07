var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Files
app.Map("files/{filename}.{extenson}", async context =>
{
   string? filename = Convert.ToString
    (context.Request.RouteValues["filename"]);
    await context.Response.WriteAsync("In files");
    string? extension = Convert.ToString
    (context.Request.RouteValues["extension"]);

    await context.Response.WriteAsync($"In files - {filename} - {extension}");
});

//dateTime
app.Map("daily-digest-report/{reportdate:datetime}", async context =>
{
    DateTime reportDate = Convert.ToDateTime
        (context.Request.RouteValues["reportDate"]);
    await context.Response.WriteAsync
        ($"In daily-digest-report-{reportDate.ToShortDateString()}");
});
//Cities Id Map
app.Map("cities/{cityId:guid}", async (context) =>
{
    Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityId"])!);
    await context.Response.WriteAsync($"City information - {cityId}");
});

//some maps for fun
app.Map("map1", async (context) => {
    await context.Response.WriteAsync("In map 1");
});
app.Map("map2", async (context) => {
    await context.Response.WriteAsync("In map 2");
});

//Products Id Map
app.Map("products/details/{id:int?}", async context =>
{
    int id =Convert.ToInt32(context.Request.RouteValues["id"]);
    await context.Response.WriteAsync($"Product detail - {id}");
   });

//employee's Names Map
app.Map("employee/profile/{employeename=scott}", async context =>
{
    string? employeeName = Convert.ToString
        (context.Request.RouteValues["employeename"]);
    await context.Response.WriteAsync
        ($"In Employee profile - {employeeName}");
});

//expection Map
app.MapFallback (async (context) =>{
    await context.Response.WriteAsync($"Request at {context.Request.Path}");
});

app.Run();