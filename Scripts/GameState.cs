    using Godot;
using System;

public class GameState : Node2D
{   
    public Player PlayerNode;
    public EntitySpawner EntitySpawnerNode;
    public Environment EnvironmentNode;
    public ScoreLabel ScoreLabelNode;

    public GameStateLabel GameStateLabelNode;

    bool isGameStarted = false;
    
    public override void _Ready()
    {
        PlayerNode = GetNode<Player>("Player");
        EntitySpawnerNode = GetNode<EntitySpawner>("EntitySpawner");
        EnvironmentNode = GetNode<Environment>("Environment");
        ScoreLabelNode = GetNode<ScoreLabel>("ScoreLabel");
        GameStateLabelNode = GetNode<GameStateLabel>("GameStateLabel");
        
        ScoreLabelNode.Hide();
    }

    public override void _Process(float delta)
    {   
        GetInput();
        
        if(isGameStarted){
            GameStarted();
        }
        if(PlayerNode.GameOver){
            GameOver();
        }
    }
    public void GameOver(){
        PlayerNode.StopPlayer();
        EntitySpawnerNode.StopSpawn();
        ScoreLabelNode.ScoreLabelGameOver();
        GameStateLabelNode.LabelToRestart();

        isGameStarted = false;
    }

    public void GameStarted(){
        ScoreLabelNode.Show();
        GameStateLabelNode.HideLabel();
        
        PlayerNode.ResetPlayer();
    }

    public void GetInput(){
        if(Input.IsActionJustPressed("ui_accept")){
            isGameStarted = true;
        }
    }
}
