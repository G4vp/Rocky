using Godot;
using System;

public class ObstacleDestroyer : Area2D
{
    public void ObstacleEntered(PhysicsBody2D body){
        body.QueueFree();
    }
}
