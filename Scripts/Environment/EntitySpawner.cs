using Godot;
using System;

public class EntitySpawner : Node2D
{   
    PackedScene LogsScene;
    PackedScene CrabScene;
    PackedScene ParrotScene;
    PackedScene OrangeBallScene;
    Timer ObstacleTimer;
    Timer CollectableTimer;
    Node2D Entities;
    RandomNumberGenerator rng = new RandomNumberGenerator();
    public override void _Ready()
    {
        rng.Randomize();
        LogsScene = GD.Load<PackedScene>("res://Scenes/Entities/Logs.tscn");
        CrabScene = GD.Load<PackedScene>("res://Scenes/Entities/Crab.tscn");
        ParrotScene = GD.Load<PackedScene>("res://Scenes/Entities/Parrot.tscn");
        OrangeBallScene = GD.Load<PackedScene>("res://Scenes/Entities/OrangeBall.tscn");

        ObstacleTimer = GetNode<Timer>("ObstaclesTimer");
        CollectableTimer = GetNode<Timer>("CollectableTimer");
        Entities = GetNode<Node2D>("Entities");
        
    }

    public void OnTimerObstacles(){
        int WaitTimeRandomized = rng.RandiRange(1,3);
        ObstacleTimer.WaitTime = WaitTimeRandomized;
        ObstacleSpawn();
    }

    public void OnTimerCollectables(){
        CollectableSpawn();
    }

    public void ObstacleSpawn(){
        int MyRandomNumber = rng.RandiRange(0,2);
        
        switch(MyRandomNumber){
            case 0:
                var LogsInstance = LogsScene.Instance();
                Entities.AddChild(LogsInstance);
                break;
            case 1:
                var CrabInstance = CrabScene.Instance();
                Entities.AddChild(CrabInstance);
                break;
            case 2:
                var ParrotInstance = ParrotScene.Instance();
                Entities.AddChild(ParrotInstance);
                break;
        }
    }   

    public void CollectableSpawn(){
        var OrangeBallInstance = OrangeBallScene.Instance();
        Entities.AddChild(OrangeBallInstance);
    }

    public void StopSpawn(){
        ObstacleTimer.Stop();
        CollectableTimer.Stop();
    }

    public void ResetSpawn(){

        ObstacleTimer.Start(3);
        CollectableTimer.Start(1.8f);

        DestroyAllChildrens();
    }

    public void DestroyAllChildrens(){
        for(int i = 0; i < Entities.GetChildCount(); i++){
            Entities.GetChild(i).QueueFree();
        }
    }
}
