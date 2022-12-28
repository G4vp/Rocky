using Godot;
using System;

public class EntitySpawner : Node2D
{   
    PackedScene WoodScene;
    PackedScene RocksScene;

    PackedScene OrangeBallScene;
    RandomNumberGenerator rng = new RandomNumberGenerator();
    public override void _Ready()
    {
        rng.Randomize();
        WoodScene = GD.Load<PackedScene>("res://Scenes/Wood.tscn");
        RocksScene = GD.Load<PackedScene>("res://Scenes/Rocks.tscn");

        OrangeBallScene = GD.Load<PackedScene>("res://Scenes/OrangeBall.tscn");
    }

    public void OnTimerObstacles(){
        ObstacleSpawn();
    }

    public void OnTimerCollectables(){
        CollectableSpawn();
    }

    public void ObstacleSpawn(){
        int MyRandomNumber = rng.RandiRange(0,1);
        
        switch(MyRandomNumber){
            case 0:
                var WoodInstance = WoodScene.Instance();
                AddChild(WoodInstance);
                break;
            case 1:
                var RocksInstance = RocksScene.Instance();
                AddChild(RocksInstance);
                break;
        }
    }   

    public void CollectableSpawn(){
        var OrangeBallInstance = OrangeBallScene.Instance();
        AddChild(OrangeBallInstance);
    }
}
