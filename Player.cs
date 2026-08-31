using Godot;

public partial class Player : CharacterBody2D{
	[Export]
	public float Speed { get; set; } = 300.0f;
	public override void _PhysicsProcess(double delta){
		Vector2 velocity = Velocity;
		if (!IsOnFloor()){
			velocity.Y += 980.0f * (float)delta;
		}
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor()){
			velocity.Y = -400.0f;
		}
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "", "");
		if (direction != Vector2.Zero){
			velocity.X = direction.X * Speed;
		}
		else{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		Velocity = velocity;
		MoveAndSlide();
	}
}
