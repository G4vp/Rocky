using Godot;
using System;

public class ScoreLabel : Node2D
{
    Player PlayerNode;
    Label LabelNode;
    AnimationPlayer AnimationScoreLabel;
    AnimationPlayer AnimationLabelParent;
    int LastScore = 0;

    bool GameOverAnimationHasPlayed = false;
    public override void _Ready()
    {
        PlayerNode = GetParent().GetNode<Player>("Player");
        LabelNode = GetNode<Label>("LabelParent/Label");

        AnimationScoreLabel = GetNode<AnimationPlayer>("AnimationPlayer");
        AnimationLabelParent = GetNode<AnimationPlayer>("LabelParent/AnimationPlayer");


    }

 // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        ScoreLabelUpdate();
    }

    public void ScoreLabelGameOver(){
        if(!GameOverAnimationHasPlayed){
            AnimationScoreLabel.Play("GameOver");
            AnimationLabelParent.Play("HeartBeat");
            SetProcess(false);
            GameOverAnimationHasPlayed = true;
        }
    }

    public void ScoreLabelUpdate(){
        if(PlayerNode.PlayerScore > LastScore){
            AnimationScoreLabel.Play("UpdateScore");
            LabelNode.Text = "Score: " + PlayerNode.PlayerScore.ToString();
            LastScore = PlayerNode.PlayerScore;
        }
    }

    public void ResetScoreLabel(){
        LabelNode.Text = "Score: 0";
        AnimationScoreLabel.Play("Reset");
        AnimationLabelParent.Stop();

        SetProcess(true);
    }
}
