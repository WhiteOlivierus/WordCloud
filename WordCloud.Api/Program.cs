using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;
using WordCloud.Api.Features.WordCloud;
using WordCloud.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IWordCloudService, WordCloudService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapPost("/process-text", ([FromBody] string text, IWordCloudService wordCloudService) =>
{
    if (text is null)
    {
        return Results.BadRequest("There was no text provided");
    }

    try
    {
        IEnumerable<DropletModel> wordCloud = wordCloudService
            .Generate(text)
            .Select(d => new DropletModel(d.Word, d.Amount));

        return Results.Ok(wordCloud);
    }
    catch (ArgumentNullException)
    {
        return Results.InternalServerError("Something went terribly wrong, there was no words object initialized.");
    }
});

app.MapPost("/process-words", ([FromBody] IEnumerable<string> words, IWordCloudService wordCloudService) =>
{
    if (words is null || !words.Any())
    {
        return Results.BadRequest("There where no words provided");
    }

    try
    {
        IEnumerable<DropletModel> wordCloud = wordCloudService
            .Generate(words)
            .Select(d => new DropletModel(d.Word, d.Amount));

        return Results.Ok(wordCloud);
    }
    catch (ArgumentNullException)
    {
        return Results.InternalServerError("Something went terribly wrong, there was no words object initialized.");
    }
});

app.Run();