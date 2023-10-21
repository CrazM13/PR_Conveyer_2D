using Godot;
using System;

public partial class ConveyerController : Node {

	[Export] public float ConveyerSpeed {  get; set; }
	[Export] public float ConveyerAccel {  get; set; }
	[Export] public float ConveyerSpawnRate {  get; set; }

	[Export] private Path2D conveyerPath;

	[Export] private QualityObjectData[] spawnableObjects;
	[Export] private PackedScene prefab;

	private float timeUntilSpawn;

	public QualityObjectInstance RequestSpawn() {

		QualityObjectInstance instance = prefab.Instantiate() as QualityObjectInstance;

		instance.SetInitialData(spawnableObjects[Random.Shared.Next(spawnableObjects.Length)], this);

		return instance;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		ConveyerSpeed += ((float) delta) * ConveyerAccel;

		timeUntilSpawn -= (float) delta * ConveyerSpeed;
		if (timeUntilSpawn <= ConveyerSpawnRate) {
			timeUntilSpawn = 1;

			SpawnObject();
		}
	}

	private void SpawnObject() {
		QualityObjectInstance instance = RequestSpawn();
		conveyerPath.AddChild(instance);
	}

}
