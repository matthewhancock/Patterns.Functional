using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Patterns.Functional.Types;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var _data = new Dictionary<int, string>() { [1] = "First Record" };

// Create OneOf
OneOf<string, NotFound> GetResult(int ID) {
    if (_data.TryGetValue(ID, out string value)) {
        return value;
    } else {
        return new NotFound();
    }
}

app.MapGet("/{ID}", (int ID, HttpContext Context) => GetResult(ID)
.Switch<Task>(
    async v => {
        Context.Response.StatusCode = 200;
        await Context.Response.WriteAsync(v);
    },
    _ => {
        Context.Response.StatusCode = 404;
        return Task.CompletedTask;
    })
);

app.Run();

internal readonly struct NotFound { }