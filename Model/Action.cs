using System.Collections;
using System.Collections.Generic;

namespace FakeNewsGenerator.Model;

public class Action
{
    public int Id { get; set; }
    public string? Description { get; set; }

    public IEnumerable<Actor>? Actors { get; set; }
    public IEnumerable<Reason>? Reasons { get; set; }
    public IEnumerable<Source>? Sources { get; set; }
    public IEnumerable<Location>? Locations { get; set; }
}