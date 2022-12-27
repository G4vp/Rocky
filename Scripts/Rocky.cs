using Godot;
using System;

public class Rocky : KinematicBody2D
{
    private int Jump = -470;
    private int Gravity = 1400;
    private Vector2 _velocity = new Vector2();
    bool Jumped = false;
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

    public void PlayerCollidesBody(PhysicsBody2D body2D){
        
    }

    public void PlayerCollidesArea(){

    }
}
