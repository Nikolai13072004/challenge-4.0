var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

ConstellationService service = new ConstellationService();

app.MapPost("/api/constellations/restore", (RestoreRequest request) =>
{
    string validationError = ValidateRequest(request);

    if (validationError != "")
    {
        return Results.BadRequest(validationError);
    }

    RestoreResponse response = service.Restore(request.Reference, request.Damaged);
    return Results.Ok(response);
});

app.Run();

string ValidateRequest(RestoreRequest request)
{
    if (request.Reference == null || request.Reference == "")
    {
        return "Поле reference обязательно для заполнения.";
    }

    if (request.Damaged == null || request.Damaged == "")
    {
        return "Поле damaged обязательно для заполнения.";
    }

    for (int i = 0; i < request.Reference.Length; i++)
    {
        if (request.Reference[i] < 'A' || request.Reference[i] > 'Z')
        {
            return "Поле reference должно содержать только латинские буквы от A до Z.";
        }

        for (int j = i + 1; j < request.Reference.Length; j++)
        {
            if (request.Reference[i] == request.Reference[j])
            {
                return "Поле reference должно содержать уникальные символы.";
            }
        }
    }

    for (int i = 0; i < request.Damaged.Length; i++)
    {
        if (request.Damaged[i] < 'A' || request.Damaged[i] > 'Z')
        {
            return "Поле damaged должно содержать только латинские буквы от A до Z.";
        }

        bool symbolExists = false;

        for (int j = 0; j < request.Reference.Length; j++)
        {
            if (request.Damaged[i] == request.Reference[j])
            {
                symbolExists = true;
                break;
            }
        }

        if (!symbolExists)
        {
            return "Поле damaged содержит символ, которого нет в reference.";
        }
    }

    return "";
}

public class RestoreRequest
{
    public string Reference { get; set; } = "";
    public string Damaged { get; set; } = "";
}

public class RestoreResponse
{
    public string MissingSymbols { get; set; } = "";
    public bool IsComplete { get; set; }
}

public class ConstellationService
{
    public RestoreResponse Restore(string reference, string damaged)
    {
        string missingSymbols = "";

        for (int i = 0; i < reference.Length; i++)
        {
            bool symbolExists = false;

            for (int j = 0; j < damaged.Length; j++)
            {
                if (reference[i] == damaged[j])
                {
                    symbolExists = true;
                    break;
                }
            }

            if (!symbolExists)
            {
                missingSymbols += reference[i];
            }
        }

        char[] symbols = missingSymbols.ToCharArray();
        Array.Sort(symbols);
        missingSymbols = new string(symbols);

        RestoreResponse response = new RestoreResponse();
        response.MissingSymbols = missingSymbols;
        response.IsComplete = missingSymbols == "";

        return response;
    }
}
