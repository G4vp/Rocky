    using Godot;
using System;

public class GameState : Node2D
{   
    public Player PlayerNode;
    public EntitySpawner EntitySpawnerNode;
    public Environment EnvironmentNode;
    public ScoreLabel ScoreLabelNode;

    public GameStateLabel GameStateLabelNode;

    bool isGameRunning = false;
    bool isGameStarted = false;
    
    public override void _Ready()
    {
        PlayerNode = GetNode<Player>("Player");
        EntitySpawnerNode = GetNode<EntitySpawner>("EntitySpawner");
        EnvironmentNode = GetNode<Environment>("Environment");
        ScoreLabelNode = GetNode<ScoreLabel>("ScoreLabel");
        GameStateLabelNode = GetNode<GameStateLabel>("GameStateLabel");
        

        PlayerNode.StopPlayer();
        EnvironmentNode.StopEnvironment();
    }

    public override void _Process(float delta)
    {   
        GetInput();
        
        if(isGameStarted){
            GameStarted();
        }
        if(PlayerNode.IsGameOver){
            GameOver();
        }
    }
    public void GameOver(){
        PlayerNode.StopPlayer();
        EntitySpawnerNode.StopSpawn();
        ScoreLabelNode.ScoreLabelGameOver();
        GameStateLabelNode.LabelToRestart();


        isGameRunning = false;
        isGameStarted = false;
    }

    public void GameStarted(){
        ScoreLabelNode.Show();
        GameStateLabelNode.HideLabel();
        
        PlayerNode.ResetPlayer();
        EntitySpawnerNode.ResetSpawn();
        ScoreLabelNode.ResetScoreLabel();
        EnvironmentNode.ResetEnvironment();
        isGameStarted = false;

    }

    public void GetInput(){
        if(Input.IsActionJustPressed("jump") && !isGameRunning ){
            isGameStarted = true;
            isGameRunning = true;
        }
    }
}
