using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class Theater : Node2D
{
    public static List<Armchair> FreeArmchairs { get; set; } = [];

    public override void _Ready()
    {
        base._Ready();
        Input.MouseMode = Input.MouseModeEnum.Hidden;
        foreach (var armchair in GlobalVars.ArmchairsNode.GetChildren().OfType<Armchair>())
        {
            armchair.UpdatedIsFreeFlag += OnUpdatedIsFreeFlag;
            armchair.ChangeFreeFlagTo(true);
        }
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
