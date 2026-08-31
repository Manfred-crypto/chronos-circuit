using Godot;
public partial class Player : CharacterBody2D{
	[Export]
	public float Speed { get; set; } = 300.0f;
	public override void _PhysicsProcess(double delta){
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero){
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}
		Velocity = velocity;
		MoveAndSlide();
	}
}
