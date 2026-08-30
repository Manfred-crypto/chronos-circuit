using Godot;
using System.Collections.Generic;
public partial class Player : CharacterBody2D{
	[Export] private float Speed=300.0f;
	[Export] private float JumpVelocity=-400.0f;
	private struct FrameInput{
		public float MoveDirection;
		public bool JumpPressed;
	}
	private List<FrameInput> _recordedInputs=new List<FrameInput>();
	private bool _isRecording=true;
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity=Velocity;
		if (!IsOnFloor()){
			velocity+= GetGravity() * (float)delta;
		}
		bool jumpPressed=false;
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor()){
			velocity.Y=JumpVelocity;
			jumpPressed=true;
		}
		float direction=Input.GetAxis("ui_left", "ui_right");
		if (direction != 0){
			velocity.X=direction * Speed;
		}
		else{
			velocity.X=Mathf.MoveToward(Velocity.X, 0, Speed * 0.2f);
		}
		Velocity=velocity;
		MoveAndSlide();
		if (_isRecording){
			_recordedInputs.Add(new FrameInput { MoveDirection=direction, JumpPressed=jumpPressed });
		}
	}
}
