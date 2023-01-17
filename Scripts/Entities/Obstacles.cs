using Godot;
using System;

public class Obstacles : KinematicBody2D
{
	private float speed = 30.0f;
	private int gravity = 1400;
	private Vector2 _velocity = new Vector2();
	public override void _PhysicsProcess(float delta)
	{   
		_velocity.y += gravity * delta;
		_velocity.x -= speed * delta;
		_velocity = MoveAndSlide(_velocity,Vector2.Up);
	}

}
