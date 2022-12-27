using Godot;
using System;

public class OrangeBall : KinematicBody2D
{
    private int speed = 50;
    private Vector2 _velocity = new Vector2();


    
    public override void _PhysicsProcess(float delta)
    {   
        _velocity.x = -(speed * delta);
        MoveAndCollide(_velocity);
    }

    public void SpawnRandomPosition(){

    }
}
