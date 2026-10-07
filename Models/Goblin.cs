using System;

namespace GoblinApp.Models;

public class Goblin : Pushable
{
    public string Name { get; }
    public int Strength { get; }
    public int Score { get; private set; }

    public Goblin(string name, int strength) { Name = name; Strength = strength; }

    public override bool TryPush(Direction direction, int force) 
    {
        return false; 
    }
    public void Step(Direction direction)
    {
        var next = Where?.GetNeighbor(direction);
        if (next == null) return;

        var nextPushable = next.Pushable;
        if (nextPushable == null || nextPushable.TryPush(direction, Strength))
        {
            var current = Where!;
            current.Leave(this);
            next.Enter(this);
        }
    }
}
