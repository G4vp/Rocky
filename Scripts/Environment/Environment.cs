using Godot;
using System;
using System.Collections.Generic;

public class Environment : Node2D
{
    AnimatedSprite FloorAnimation;
    AnimatedSprite BackgroundAnimation;

    public override void _Ready()
    {
        FloorAnimation = GetNode<AnimatedSprite>("Floor");
        BackgroundAnimation = GetNode<AnimatedSprite>("Background");
        
    }

    public void StopEnvironment(){
        FloorAnimation.Stop();
        BackgroundAnimation.Stop();
    }

    public void ResetEnvironment(){
        FloorAnimation.Play();
        BackgroundAnimation.Play();
    }
}