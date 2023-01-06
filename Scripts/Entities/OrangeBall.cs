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
    

    // This function changes the ball's Y position into a random one. 
    public void RandomVerticalPosition(){
        int RandomYPosition = rng.RandiRange(-40,0);
        Position = new Vector2(Position.x,RandomYPosition);
    }


    // This function changes the force of how the ball is moving in the X-axis.
    public void RandomAppliedForce(){
        int RandomX = rng.RandiRange(-30,-15);
        AppliedForce = new Vector2(RandomX, 0);
    }

    // This functions deletes the ball when is called.
    public void Destroy(){
        this.QueueFree();
    }
}
