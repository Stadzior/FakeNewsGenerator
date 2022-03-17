using System.Collections.Generic;

namespace FakeNewsGenerator.Model;

public class Source
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public IEnumerable<Action>? Actions { get; set; }
}