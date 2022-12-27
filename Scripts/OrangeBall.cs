using Godot;
using System;

public class OrangeBall : KinematicBody2D
{
    private int speed = 50;
    private Vector2 _velocity = new Vector2();
    private RandomNumberGenerator rng = new RandomNumberGenerator();

    public override void _Ready(){
        rng.Randomize();
        int MyRandomNumber = rng.RandiRange(-30,48);
        VerticalRandomPosition(MyRandomNumber);
    }
    
    public override void _PhysicsProcess(float delta)
    {   
        _velocity.x = -(speed * delta);
        MoveAndCollide(_velocity);
    }

    // Function that moves the node in a vertical random position ( -30 <= y <= 48,  from parent node)
    public void VerticalRandomPosition(int y){
        Position = new Vector2(Position.x,y);
    }
}
