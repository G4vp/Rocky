using Godot;
using System;

public class OrangeBall : RigidBody2D
{
    private RandomNumberGenerator rng = new RandomNumberGenerator();

    public override void _Ready(){
        rng.Randomize();
        RandomVerticalPosition();
        RandomAppliedForce();
    }
    

    // Function that moves the node in a vertical random position ( -40 <= y <= 0,  from parent node)
    public void RandomVerticalPosition(){
        int RandomYPosition = rng.RandiRange(-40,0);
        Position = new Vector2(Position.x,RandomYPosition);
    }


    // Function that applied a random force in the X-axis ( -30 <= x <= -15, from parent node)
    public void RandomAppliedForce(){
        int RandomX = rng.RandiRange(-30,-15);
        AppliedForce = new Vector2(RandomX, 0);
    }
}
