using Godot;
using System;

public class Player : KinematicBody2D
{
    private int Jump = -470;
    private bool Jumped = false;
    private int Gravity = 1400;
    private Vector2 _velocity = new Vector2();
    public int PlayerScore = 0;
    public bool IsGameOver = false;
    public AnimatedSprite PlayerAnimatedSprite;
    public Particles2D ParticlesExplosion;
    public Area2D Area;
    public override void _Ready()
    {
        PlayerAnimatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
        Area = GetNode<Area2D>("PlayerArea2D");
        ParticlesExplosion = GetNode<Particles2D>("Particles/ParticlesExplosion");
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        _velocity.x = 0;
        _velocity.y += Gravity * delta;
        if(Jumped && IsOnFloor()){
            _velocity.y += Jump;
            Jumped = false;
        }

        if(IsOnFloor()){
            PlayerAnimatedSprite.Play("Running");
        }
        else{
            PlayerAnimatedSprite.Play("Jumping"); 
        }
    
        _velocity = MoveAndSlide(_velocity,Vector2.Up);
    }
    public void GetInput(){
        if(Input.IsActionPressed("jump") && IsOnFloor()){
            Jumped = true;           
        }
    }

    // If the player collides with a collectable ( Orange Ball ) it destroy it and increases the score
    public void PlayerCollidesArea(Area2D area){
        if(area.Name == "OrangeBallArea2D"){
            area.GetParent().QueueFree();
            PlayerScore++;
        }

        // If player collides with obstacles
        if(area.CollisionLayer == 4 && !IsGameOver){
            PlayerExplosion();
            IsGameOver = true;
        }
    }

    public void StopPlayer(){
        SetPhysicsProcess(false);
        PlayerAnimatedSprite.Stop();
    }
    
    public void ResetPlayer(){
        SetPhysicsProcess(true);
        PlayerAnimatedSprite.Show();
        PlayerAnimatedSprite.Play("default");
        PlayerScore = 0;
        IsGameOver = false;   
        Area.SetCollisionMaskBit(4,true);  //Enable collision with ball
    }
    
    // PlayerExplosion Function calls 'explosion' particles after the player collides with a physicsbody2D
    public void PlayerExplosion(){
        PlayerAnimatedSprite.Hide();
        ParticlesExplosion.Emitting = true;
        Area.SetCollisionMaskBit(4,false); // Disable CollisionMask with ball
    }
}
