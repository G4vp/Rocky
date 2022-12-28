using Godot;
using System;

public class EntitySpawner : Node2D
{   
    PackedScene WoodScene;
    PackedScene RocksScene;

    PackedScene OrangeBallScene;
    int ObstacleTurn = 0;
    public override void _Ready()
    {
        WoodScene = GD.Load<PackedScene>("res://Scenes/Wood.tscn");
        RocksScene = GD.Load<PackedScene>("res://Scenes/Rocks.tscn");

        OrangeBallScene = GD.Load<PackedScene>("res://Scenes/OrangeBall.tscn");
    }

    public void OnTimerObstacles(){
        ObstacleSpawn();
    }

    public void OnTimerCollectables(){

    }

    public void ObstacleSpawn(){
        switch(ObstacleTurn){
            case 0:
                var WoodInstance = WoodScene.Instance();
                AddChild(WoodInstance);
                ObstacleTurn = 1;
                break;
            case 1:
                var RocksInstance = RocksScene.Instance();
                AddChild(RocksInstance);
                ObstacleTurn = 0;
                break;
        }
    }   

    public void CollectableSpawn(){

    }
}
