using Godot;
using System;

public class AerialObstacles : KinematicBody2D
{

    private float speed = 35.0f;
    private Vector2 _velocity = new Vector2();
    private RandomNumberGenerator rng = new RandomNumberGenerator();

    public override void _Ready(){
        rng.Randomize();
        VerticalRandomPosition();
    }
    
    public override void _PhysicsProcess(float delta)
    {   
        _velocity.x -= speed * delta;
        MoveAndSlide(_velocity);
    }

    // This function changes the aerial obstacles Y position into a random one. 
    public void VerticalRandomPosition(){
        int RandomYPosition = rng.RandiRange(-30,35);
        Position = new Vector2(Position.x,RandomYPosition);
    }

}
