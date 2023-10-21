using Godot;
using System;

public partial class QualityObjectData : Resource {

	[Export] public Texture2D Sprite { get; private set; }

	[Export] public bool IsQuality {  get; private set; }

	public virtual void OnReachedEnd(QualityObjectInstance _) { /*MT*/ }
	public virtual void OnRejected(QualityObjectInstance _) { /*MT*/ }

}
