    using Godot;
using System;

public class GameState : Node2D
{   
    public Player PlayerNode;
    public EntitySpawner EntitySpawnerNode;
    public Environment EnvironmentNode;

    public ScoreLabel ScoreLabelNode;
    
    public override void _Ready()
    {
        PlayerNode = GetNode<Player>("Player");
        EntitySpawnerNode = GetNode<EntitySpawner>("EntitySpawner");
        EnvironmentNode = GetNode<Environment>("Environment");
        ScoreLabelNode = GetNode<ScoreLabel>("ScoreLabel");
    }

    public override void _Process(float delta)
    {
        if(PlayerNode.GameOver){
            GameOver();

        }
    }
    public void GameOver(){
        PlayerNode.StopPlayer();
        EntitySpawnerNode.StopSpawn();
        ScoreLabelNode.ScoreLabelGameOver();
    }
}
