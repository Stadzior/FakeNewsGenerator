using System;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FakeNewsGenerator.Model;
using FakeNewsGenerator.Service.Interfaces;

namespace FakeNewsGenerator.Service;

public class FakeNewsService : IFakeNewsService
{
    private readonly string _accessKey;

    public FakeNewsService(string accessKey)
    {
        _accessKey = accessKey;
    }

    public async Task<FakeNews> GenerateFakeNewsAsync()
    {
        const string imageDescription = "Fake News";

        return new FakeNews
        {
            ImageDescription = imageDescription,
            Image = await GetProperImageSourceAsync(imageDescription),
            Title = $"Some Fake News {new Random().Next()}",
            Body = "Lorem Ipsum, Lorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem Ipsum"
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