using System.Collections.Generic;

namespace FakeNewsGenerator.Model;

public class Reason
{
    public int Id { get; set; }
    public string? Description { get; set; }

    public IEnumerable<Action>? Actions { get; set; }
}