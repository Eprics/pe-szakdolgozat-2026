using System;

namespace GoblinApp.Models;

public abstract class Pushable
{
    public Field? Where {get; internal set;}
    public abstract bool TryPush(Direction direction, int force);
}