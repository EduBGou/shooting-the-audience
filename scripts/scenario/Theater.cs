using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class Theater : Node2D
{
    [Export] public int SpawnAmount = 1;
    [Export] public Node2D CreaturesNode;
    [Export] public Node2D ArmchairsNode;

    public static List<Armchair> FreeArmchairs { get; set; } = [];
    public static List<PackedScene> CreaturePckScn =>
        [
            GD.Load<PackedScene>("res://scenes/creatures/Koala.tscn"),
            GD.Load<PackedScene>("res://scenes/creatures/Frog.tscn")
        ];

    public override void _Ready()
    {
        base._Ready();
        Input.MouseMode = Input.MouseModeEnum.Hidden;
        foreach (var armchair in ArmchairsNode.GetChildren().Cast<Armchair>())
        {
            armchair.UpdatedIsFreeFlag += OnUpdatedIsFreeFlag;
            armchair.ChangeFreeFlagTo(true);
        }
        Spawner.Spawn(CreaturesNode, SpawnAmount);
    }

    public static Armchair ChooseRandomArmchair()
    {
        if (FreeArmchairs.Count == 0) return null;
        Armchair choosedArmchair;
        var rdm = new Random().Next(FreeArmchairs.Count);
        choosedArmchair = FreeArmchairs[rdm];
        return choosedArmchair;
    }

    private void OnUpdatedIsFreeFlag(Armchair armchair, bool isFree)
    {
        if (isFree)
            FreeArmchairs.Add(armchair);
        else
            FreeArmchairs.Remove(armchair);
    }
}
