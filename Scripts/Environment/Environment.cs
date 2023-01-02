using Godot;
using System;
using System.Collections.Generic;

public class Environment : Node2D
{

    AnimatedSprite FloorAnimation;

    public override void _Ready()
    {
        FloorAnimation = GetNode<AnimatedSprite>("Floor");
    }

    public void StopEnvironment(){
        FloorAnimation.Stop();
    }

    public void ResetEnvironment(){
        FloorAnimation.Play();
    }
}