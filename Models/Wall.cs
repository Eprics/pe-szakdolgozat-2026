using System;

namespace GoblinApp.Models;

public class Wall : Pushable
{
    public override bool TryPush(Direction direction, int force) 
    {
        return false;
    }
}
