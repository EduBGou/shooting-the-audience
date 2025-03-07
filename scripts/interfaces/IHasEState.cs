using Godot;
using System;

public interface IHasEState<TEnum> where TEnum : Enum
{
    TEnum EState { get; }
}
