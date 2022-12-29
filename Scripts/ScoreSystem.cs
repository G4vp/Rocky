using Godot;
using System;

public class ScoreSystem : Node2D
{
    Player PlayerNode;
    Label LabelNode;
    public override void _Ready()
    {
        PlayerNode = GetParent().GetNode<Player>("Player");
        LabelNode = GetNode<Label>("Label");
    }

 // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        ScoreLabelUpdate();
        GD.Print(PlayerNode.PlayerScore);
    }

    public void ScoreLabelUpdate(){
        LabelNode.Text = "Score: " + PlayerNode.PlayerScore.ToString();
    }
}
