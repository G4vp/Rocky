using Godot;
using System;

public class ScoreLabel : Node2D
{
    Player PlayerNode;
    Label LabelNode;
    public override void _Ready()
    {
        PlayerNode = GetParent().GetNode<Player>("Player");
        LabelNode = GetNode<Label>("LabelParent/Label");

        
    }

 // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        ScoreLabelUpdate();
    }

    public void ScoreLabelUpdate(){
        LabelNode.Text = "Score: " + PlayerNode.PlayerScore.ToString();
    }
}
