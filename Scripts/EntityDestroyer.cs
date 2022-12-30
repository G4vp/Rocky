using Godot;
using System;

public class EntityDestroyer : Area2D
{
    public void ObstacleEntered(PhysicsBody2D body){
        body.QueueFree();
    }
}
