using Godot;
using System;

public partial class QualityObjectInstance : PathFollow2D {

	private QualityObjectData data;
	private ConveyerController conveyer;

	[Export] private Sprite2D sprite;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		ProgressRatio += (float) delta * conveyer.ConveyerSpeed;

		if (ProgressRatio >= 1) {

			// Apply Effect
			data?.OnReachedEnd(this);

			QueueFree();
		}

	}

	public void OnClick() {

		// Apply Effect
		data?.OnRejected(this);

		QueueFree();
	}

	public void SetInitialData(QualityObjectData data, ConveyerController conveyer) {
		this.conveyer = conveyer;
		this.data = data;

		sprite.Texture = this.data.Sprite;
	}
}
