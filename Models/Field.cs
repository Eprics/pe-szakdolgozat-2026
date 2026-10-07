using System;
using System.Collections.Generic;

namespace GoblinApp.Models;

public class Field
{
    private Dictionary<Direction, Field> _neighbors = new();

    public Pushable? Pushable { get; private set; }

    public Field? GetNeighbor(Direction d) {return _neighbors.GetValueOrDefault(d); }
    public void SetNeighbor(Direction d, Field f) { _neighbors[d] = f;}

    public void Enter(Pushable p)
    {
        if (Pushable != null) return;
        Pushable = p;
        p.Where = this;
    }

    public void Leave(Pushable p)
    {
        if (Pushable != p) return;
        Pushable = null;
        p.Where = null;
    }
}
