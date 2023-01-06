using Godot;
using System;

public class GameState : Node2D
{   
	public Player PlayerNode;
	public EntitySpawner EntitySpawnerNode;
	public Environment EnvironmentNode;
	public ScoreLabel ScoreLabelNode;
	public GameStateLabel GameStateLabelNode;
	public AudioStreamPlayer2D IntroSong;
	public AudioStreamPlayer2D RunningSong;
	bool isGameRunning = false;
	bool WasGameStarted = false;
	
	public override void _Ready()
	{
		PlayerNode = GetNode<Player>("Player");
		EntitySpawnerNode = GetNode<EntitySpawner>("EntitySpawner");
		EnvironmentNode = GetNode<Environment>("Environment");
		ScoreLabelNode = GetNode<ScoreLabel>("ScoreLabel");
		GameStateLabelNode = GetNode<GameStateLabel>("GameStateLabel");
		IntroSong = GetNode<AudioStreamPlayer2D>("Songs/IntroSong");
		RunningSong = GetNode<AudioStreamPlayer2D>("Songs/RunningSong");

		PlayerNode.StopPlayer();
		EnvironmentNode.StopEnvironment();

		IntroSong.Play();
	}

	public override void _Process(float delta)
	{   
		GetInput();
		
		if(WasGameStarted){
			GameStarted();
		}
		if(PlayerNode.IsGameOver && isGameRunning){
			GameOver();
		}
	}
	public void GameOver(){
		PlayerNode.StopPlayer();
		
		EntitySpawnerNode.StopSpawn();
		ScoreLabelNode.ScoreLabelGameOver();
		GameStateLabelNode.LabelToRestart();

		RunningSong.Stop();
		IntroSong.Play();

		isGameRunning = false;
		WasGameStarted = false;
	}

	public void GameStarted(){
		ScoreLabelNode.Show();
		GameStateLabelNode.HideLabel();

		IntroSong.Stop();
		RunningSong.Play();
		
		PlayerNode.ResetPlayer();
		EntitySpawnerNode.ResetSpawn();
		ScoreLabelNode.ResetScoreLabel();
		EnvironmentNode.ResetEnvironment();
		WasGameStarted = false;

	}

	public void GetInput(){
		if(Input.IsActionJustPressed("jump") && !isGameRunning ){
			WasGameStarted = true;
			isGameRunning = true;
		}
	}
}
