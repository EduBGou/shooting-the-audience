using Godot;
using System;

public partial class Spawner : Node
{
    /// <summary>
    /// Spawn creatures, you need to give the amount of them and their node parent.
    /// </summary>
    /// <param name="amount">How much cretures you want to spawn.</param>
    /// <param name="parent">The parent that the creatures must be childs.</param>
    public static void Spawn(Node2D parent, int amount = 1)
    {
        if (amount > Theater.FreeArmchairs.Count)
        {
            amount = Theater.FreeArmchairs.Count - 1;
        }
        for (var i = 0; i < amount; i++)
        {
            var creatureInstance = Theater.CreaturePckScn[0].Instantiate<Creature>();
            creatureInstance.PlaceOnArmchair(Theater.FreeArmchairs[0]);
            parent.AddChild(creatureInstance);
        }
    }
}
