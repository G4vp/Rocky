using Godot;
using System;

public class GameStateLabel : Node2D
{

    Label LabelNode;
    AnimationPlayer AnimationLabelNode;
    Node2D LabelParentNode;
    public override void _Ready()
    {
        LabelParentNode = GetNode<Node2D>("LabelParent");
        LabelNode = GetNode<Label>("LabelParent/Label");
        AnimationLabelNode = GetNode<AnimationPlayer>("LabelParent/AnimationPlayer");
    }

    public void LabelToRestart(){
        LabelNode.Text = "Press \"Space\" To Restart";
        AnimationLabelNode.Play("HeartBeat");
        Position = new Vector2 (Position.x,5);
    }

    public void HideRestartLabel(){

    }
}
