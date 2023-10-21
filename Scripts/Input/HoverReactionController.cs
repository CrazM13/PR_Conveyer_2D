using Godot;
using System;

public partial class HoverReactionController : Sprite2D {

	private Color hover;
	private Color normal;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		normal = Modulate;
		hover = normal.Darkened(0.25f);

	}

	public override void _Process(double delta) {
		


	}

	private void OnMouseEnter() {
		Modulate = hover;
	}

	private void OnMouseExit() {
		Modulate = normal;
	}

}
