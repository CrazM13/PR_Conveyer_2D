using Godot;
using System;

public partial class ScreenShake : Camera2D {

	public static ScreenShake instance;

	[Export] private float decay;
	[Export] private Vector2 maxOffset;
	[Export] private float maxRoll;
	[Export] private float traumaPower;

	private float trauma;
	private float noiseY;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		if (instance == null) {
			instance = this;
		}

	}

	protected override void Dispose(bool disposing) {

		if (instance == this) {
			instance = null;
		}

		base.Dispose(disposing);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		trauma = Mathf.Max(trauma - (decay * (float) delta), 0);
		if (trauma > 0) Shake();
	}

	public void AddTrauma(float amount) {
		trauma = Mathf.Min(trauma + amount, 1f);
	}

	private void Shake() {
		noiseY += 1;
		FastNoiseLite noise = new FastNoiseLite();
		float amount = Mathf.Pow(trauma, traumaPower);

		Rotation = maxRoll * amount * noise.GetNoise2D(noise.Seed, noiseY);
		float x = maxOffset.X * amount * noise.GetNoise2D(noise.Seed * 2, noiseY);
		float y = maxOffset.Y * amount * noise.GetNoise2D(noise.Seed * 3, noiseY);

		Position = new Vector2(x, y);
	}

	private void NoiseRange(float min, float max) {
		var noise = new FastNoiseLite();

		
	}

}
