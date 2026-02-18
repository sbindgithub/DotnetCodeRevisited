var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

string progressPath = Path.Combine(app.Environment.WebRootPath, "architect-progress.xml");

// Ensure XML file exists at startup
if (!File.Exists(progressPath))
{
    var initialXml = "<Plan startDate=\"\"></Plan>";
    File.WriteAllText(progressPath, initialXml);
}

app.MapGet("/progress", () =>
{
    var xml = File.ReadAllText(progressPath);
    return Results.Content(xml, "application/xml");
});

app.MapPost("/progress", async (HttpRequest request) =>
{
    using var reader = new StreamReader(request.Body);
    var xml = await reader.ReadToEndAsync();

    await File.WriteAllTextAsync(progressPath, xml);

    return Results.Ok();
});

app.Run();
