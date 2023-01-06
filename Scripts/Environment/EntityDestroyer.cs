using Godot;
using System;

public class EntityDestroyer : Area2D
{
    // This function will delete obstacle when they left the screen.
    public void ObstacleEntered(PhysicsBody2D body){
        body.QueueFree();
    }
}
