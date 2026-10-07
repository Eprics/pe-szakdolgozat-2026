using System;

namespace GoblinApp.Models;

public class Boulder : Pushable
{
    public override bool TryPush(Direction direction, int force)
    {
        if (force <= 0) return false;
        var next = Where?.GetNeighbor(direction);
        if (next == null) return false;

        var nextPushable = next.Pushable;
        if (nextPushable == null || nextPushable.TryPush(direction, force - 1))
        {
            var current = Where!;
            current.Leave(this);
            next.Enter(this);
            return true;
        }
        return false;
    }
}
