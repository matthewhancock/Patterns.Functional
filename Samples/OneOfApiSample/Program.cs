using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Patterns.Functional.Types;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var _data = new Dictionary<int, string>() { [1] = "First Record" };

// Create OneOf
OneOf<string, NoResult> GetResult(int ID) {
    if (_data.TryGetValue(ID, out string value)) {
        return value;
    } else {
        return new NoResult();
    }
}

app.MapGet("/{ID}", (int ID) => GetResult(ID)
.Switch<IResult>(
    v => Results.Text(v),
    _ => Results.NotFound())
);

app.Run();

internal readonly struct NoResult { }