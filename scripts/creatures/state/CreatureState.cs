using Godot;
using System;

[GlobalClass]
public partial class CreatureState : Node
{
    public virtual void Enter() { }
    public virtual void Update(double delta) { }
    public virtual void Exit() { }
}
