using Godot;
using System;

public class Obstacles : KinematicBody2D
{
    private float speed = 30.0f;
    private int gravity = 1400;
    private Vector2 _velocity = new Vector2();
    public override void _Ready()
    {   
        
    }
    public override void _PhysicsProcess(float delta)
    {   
        _velocity.y += gravity * delta;
        _velocity.x -= speed * delta;
        GD.Print(_velocity.x);
        _velocity = MoveAndSlide(_velocity,Vector2.Up,false,4,0.785398f,false);
    }

}
