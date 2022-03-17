using System.Collections;
using System.Collections.Generic;

namespace FakeNewsGenerator.Model;

public class Actor
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public IEnumerable<Action>? Actions { get; set; }
}