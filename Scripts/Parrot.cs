using Godot;
using System;

public class Parrot : KinematicBody2D
{

    private float speed = 30.0f;
    private Vector2 _velocity = new Vector2();
    private RandomNumberGenerator rng = new RandomNumberGenerator();

    public override void _Ready(){
        rng.Randomize();
        int MyRandomNumber = rng.RandiRange(-30,40);
        VerticalRandomPosition(MyRandomNumber);
    }
    
    public override void _PhysicsProcess(float delta)
    {   
        _velocity.x -= speed * delta;
        MoveAndSlide(_velocity);
    }

    // Function that moves the node in a vertical random position ( -30 <= y <= 40,  from parent node)
    public void VerticalRandomPosition(int y){
        Position = new Vector2(Position.x,y);
    }

}
