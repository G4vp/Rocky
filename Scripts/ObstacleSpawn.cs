using Godot;
using System;

public class ObstacleSpawn : Node2D
{   
    PackedScene WoodScene;
    PackedScene RocksScene;
    int ObstacleTurn = 0;
    public override void _Ready()
    {
        WoodScene = GD.Load<PackedScene>("res://Scenes/Wood.tscn");
        RocksScene = GD.Load<PackedScene>("res://Scenes/Rocks.tscn");
    }

    public void TimeOut(){
        Spawn();
    }

    public void Spawn(){
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

}
