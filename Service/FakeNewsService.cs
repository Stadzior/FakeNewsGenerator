using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.Loader;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FakeNewsGenerator.Data;
using FakeNewsGenerator.Model;
using FakeNewsGenerator.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FakeNewsGenerator.Service;

public class FakeNewsService : IFakeNewsService
{
    private readonly string _accessKey;
    private readonly IDbContextFactory<FakeNewsContext> _factory;

    public FakeNewsService(string accessKey, IDbContextFactory<FakeNewsContext> factory)
    {
        _accessKey = accessKey;
        _factory = factory;
    }

    public async Task<FakeNews> GenerateFakeNewsAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();

        var action = context.Actions
            .Include(action => action.Actors)
            .Include(action => action.Locations)
            .Include(action => action.Reasons)
            .Include(action => action.Sources)
            .Skip(new Random().Next(context.Actions.Count()))
            .First();

        var actor = action.Actors!
            .Skip(new Random().Next(action.Actors!.Count()))
            .First();

        var location = action.Locations!
            .Skip(new Random().Next(action.Locations!.Count()))
            .First();

        var reason = action.Reasons!
            .Skip(new Random().Next(action.Reasons!.Count()))
            .First();

        var source = action.Sources!
            .Skip(new Random().Next(action.Sources!.Count()))
            .First();

        var imageDescription = new[] { actor.Name, location.Name }[new Random().Next(2)];

        var body = $"{actor.Name} ({actor.Description}) {action.Description}. The reason was {reason.Description}. Source: {source.Name}.";

        Log.Information($"Fake news with the following body has been created: {body}");

        return new FakeNews
        {
            ImageDescription = imageDescription,
            Image = await GetProperImageSourceAsync(imageDescription!),
            Title = $"{actor.Name} {action.Description}!",
            Body = body
        };
    }

    private async Task<ImageSource> GetProperImageSourceAsync(string imageDescription)
    {
        imageDescription = imageDescription.Replace(' ', '+');

        using var client = new HttpClient();
        var response = await client.GetAsync($"https://api.unsplash.com/search/photos?page=1&per_page=20&query={imageDescription}&client_id={_accessKey}");
        var json = await response.Content.ReadAsStringAsync();
        var url = (string) JsonNode.Parse(json)!
            ["results"]!
            [new Random().Next(19)]!
            ["urls"]!
            ["small"]!;

        var image = new BitmapImage(new Uri(url));
        return image;
    }
}