    using Godot;
using System;

public class GameState : Node2D
{   
    public Player PlayerNode;
    
    public override void _Ready()
    {
        PlayerNode = GetNode<Player>("Player");
    }

    public override void _Process(float delta)
    {
        if(PlayerNode.GameOver){
            GameOver();
        }
    }
    public void GameOver(){
        PlayerNode.StopPlayer();

    }
}
