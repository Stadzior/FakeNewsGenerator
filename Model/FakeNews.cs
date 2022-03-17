using System.Windows.Media;

namespace FakeNewsGenerator.Model;

public class FakeNews
{
    public ImageSource? Image { get; set; }
    public string? ImageDescription { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
}