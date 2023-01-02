using Godot;
using System;

public class OrangeBall : RigidBody2D
{
    private Vector2 _velocity = new Vector2();
    private RandomNumberGenerator rng = new RandomNumberGenerator();

    public override void _Ready(){
        rng.Randomize();
        int MyRandomNumber = rng.RandiRange(-40,0);
        VerticalRandomPosition(MyRandomNumber);
    }
    
    public override void _PhysicsProcess(float delta)
    {   
        int MyRandomNumber = rng.RandiRange(-30,-15);
        _velocity.x = MyRandomNumber;
        AppliedForce = _velocity;
    }

    // Function that moves the node in a vertical random position ( -40 <= y <= 0,  from parent node)
    public void VerticalRandomPosition(int y){
        Position = new Vector2(Position.x,y);
    }
}
