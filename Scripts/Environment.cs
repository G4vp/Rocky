using Godot;
using System;
using System.Collections.Generic;

public class Environment : Node2D
{

    AnimatedSprite FloorAnimation;
    float AnimationSpeed = 0.5f;
    public override void _Ready()
    {
        FloorAnimation = GetNode<AnimatedSprite>("AnimatedSprite");
    }

    public override void _Process(float delta)
    {
        FloorAnimation.SpeedScale = AnimationSpeed;
    }

}