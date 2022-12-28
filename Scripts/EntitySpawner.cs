using Godot;
using System;

public class EntitySpawner : Node2D
{   
    PackedScene WoodScene;
    PackedScene RocksScene;
    PackedScene ParrotScene;
    PackedScene OrangeBallScene;

    Timer ObstacleTimer;
    RandomNumberGenerator rng = new RandomNumberGenerator();
    public override void _Ready()
    {
        rng.Randomize();
        WoodScene = GD.Load<PackedScene>("res://Scenes/Entities/Wood.tscn");
        RocksScene = GD.Load<PackedScene>("res://Scenes/Entities/Rocks.tscn");
        ParrotScene = GD.Load<PackedScene>("res://Scenes/Entities/Parrot.tscn");

        OrangeBallScene = GD.Load<PackedScene>("res://Scenes/Entities/OrangeBall.tscn");

        ObstacleTimer = GetNode<Timer>("ObstaclesTimer");
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
                var WoodInstance = WoodScene.Instance();
                AddChild(WoodInstance);
                break;
            case 1:
                var RocksInstance = RocksScene.Instance();
                AddChild(RocksInstance);
                break;
            case 2:
                var ParrotInstance = ParrotScene.Instance();
                AddChild(ParrotInstance);
                break;
        }
        GD.Print(MyRandomNumber);
    }   

    public void CollectableSpawn(){
        var OrangeBallInstance = OrangeBallScene.Instance();
        AddChild(OrangeBallInstance);
    }
}
