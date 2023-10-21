using Godot;
using System;

public partial class ClickableArea : Area2D {

	[Signal]
	public delegate void OnClickEventHandler();

	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx) {
		if (Input.IsActionJustPressed("mouse_left")) {
			EmitSignal(SignalName.OnClick);
		}
	}
}
