using Godot;
using System;

public class Rocky : KinematicBody2D
{
    private int Jump = -470;
    private bool Jumped = false;

    private int Gravity = 1400;
    private Vector2 _velocity = new Vector2();
    
    public int PlayerScore = 0;

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        _velocity.x = 0;
        _velocity.y += Gravity * delta;
        if(Jumped && IsOnFloor()){
            _velocity.y += Jump;
            Jumped = false;
        }
        _velocity = MoveAndSlide(_velocity,Vector2.Up);
    }
    public void GetInput(){
        if(Input.IsActionPressed("jump") && IsOnFloor()){
            Jumped = true;           
        }
    }

    public void PlayerCollidesBody(PhysicsBody2D body){
        
    }

    // If the player collides with a collectable ( Orange Ball ) it destroy it and increases the score
    public void PlayerCollidesArea(Area2D area){
        if(area.Name == "OrangeBallArea2D"){
            area.GetParent().QueueFree();
            PlayerScore++;
        }
    }
}
