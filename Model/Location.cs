using System.Collections.Generic;

namespace FakeNewsGenerator.Model;

public class Location
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? RegionName { get; set; }
    public string? CountryName { get; set; }

    public IEnumerable<Action>? Actions { get; set; }
}