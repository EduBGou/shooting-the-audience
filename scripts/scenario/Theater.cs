using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class Theater : Node2D
{
    [Export] public Node2D CreaturesNode;
    [Export] public Node2D ArmchairsNode;

    public static PackedScene CreaturePckScn => GD.Load<PackedScene>("res://scenes/creatures/Koala.tscn");
    public static List<Armchair> FreeArmchairs { get; set; } = new();

    public override void _Ready()
    {
        base._Ready();
        Input.MouseMode = Input.MouseModeEnum.Hidden;
        foreach (var armchair in ArmchairsNode.GetChildren().Cast<Armchair>())
        {
            armchair.UpdatedIsFreeFlag += OnUpdatedIsFreeFlag;
            armchair.ChangeFreeFlagTo(true);
        }
        Spawn(10);
    }

    public void Spawn(int Amount)
    {
        if (Amount >= FreeArmchairs.Count) Amount = FreeArmchairs.Count - 1;
        for (var i = 0; i < Amount; i++)
        {
            var creatureInstance = CreaturePckScn.Instantiate<Creature>();
            creatureInstance.PlaceOnArmchair(ChooseRandomArmchair());
            CreaturesNode.AddChild(creatureInstance);
        }
    }

    public static Armchair ChooseRandomArmchair()
    {
        Armchair choosedArmchair;
        var rdm = new Random().Next(FreeArmchairs.Count - 1);
        choosedArmchair = FreeArmchairs[rdm];
        choosedArmchair.ChangeFreeFlagTo(false);
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
