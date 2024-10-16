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
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		Camera3D camera = GetNodeOrNull<Camera3D>("PlayerCam");
		
		Transform3D cameraTransform = camera.Transform;
		cameraTransform.Basis = Basis.Identity;
		camera.Transform = cameraTransform;

		camera.RotateObjectLocal(Vector3.Right, lookDirection[1]);
	}

	public override void _IntegrateForces(PhysicsDirectBodyState3D state)
	{
		Transform3D transform = state.Transform;
		transform.Basis = Basis.Identity;
		state.Transform = transform.RotatedLocal(Vector3.Up, lookDirection[0]);
	}
}
