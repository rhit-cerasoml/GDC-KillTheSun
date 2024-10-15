using Godot;
using System;

public partial class PlayerMovement : RigidBody3D {

	Vector2 lookDirection = new Vector2(0, 0);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Input.MouseMode = Input.MouseModeEnum.Captured;
		
	}
	
	public override void _Input(InputEvent @event){
		if (@event is InputEventMouseMotion motionEvent){
			lookDirection -= motionEvent.Relative / 1000.0f;

			Transform3D transform = Transform;
			transform.Basis = Basis.Identity;
			Transform = transform;

			RotateObjectLocal(Vector3.Up, lookDirection[0]); 
			RotateObjectLocal(Vector3.Right, lookDirection[1]);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		
	}
}
