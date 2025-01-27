using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class Theater : Node2D
{
    [Export] public Node2D CreaturesNode;
    [Export] public Node2D ArmchairsNode;

    public PackedScene CreaturePckScn = GD.Load<PackedScene>("res://scenes/creatures/Koala.tscn");
    public List<Armchair> Armchairs = new();

    public override void _Ready()
    {
        base._Ready();
        Input.MouseMode = Input.MouseModeEnum.Hidden;
        foreach (var armchair in ArmchairsNode.GetChildren().Cast<Armchair>())
        {
            Armchairs.Add(armchair);
        }
        Spawn(4);
    }

    public void Spawn(int Amount)
    {
        for (var i = 0; i < Amount; i++)
        {
            var rdm = new Random().Next(0, Armchairs.Count - 1);
            var creatureInstance = CreaturePckScn.Instantiate<Creature>();
            Armchair choosedArmchair;
            while (true)
            {
                choosedArmchair = Armchairs[rdm];
                if (!choosedArmchair.IsFree)
                {
                    rdm++;
                }
                else
                {
                    break;
                }
            }
            choosedArmchair.IsFree = false;
            creatureInstance.GlobalPosition = choosedArmchair.GlobalPosition;
            CreaturesNode.AddChild(creatureInstance);
        }
    }
}
