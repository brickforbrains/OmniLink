using Godot;
using OmniLink.Core.LogicEngine;
using OmniLink.Core.Models;

public partial class EmitterNode : Area2D
{
	public Emitter CoreEmitter { get; private set; }

	[Export] public string EmitterId = "BAT_01";
    [Export] public bool StartingPower = false;

	[Signal] public delegate void PowerToggledEventHandler(bool newState);

    public override void _Ready()
	{
		// initialize core obj
		CoreEmitter = new Emitter(EmitterId) { IsPowered = StartingPower };

        InputEvent += OnInputEvent;

		UpdateVisuals();
	}

	private void OnInputEvent(Node viewport, InputEvent @event, long shapeIdx)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)
		{
			TogglePower();
		}
	}

	public void TogglePower()
	{ 
		CoreEmitter.IsPowered = !CoreEmitter.IsPowered;
		GD.Print($"{EmitterId} is now {(CoreEmitter.IsPowered ? "ON" : "OFF")}");

		//GetTree().CallGroup("Simulation", "RequestSimulationUpdate");
		EmitSignal(SignalName.PowerToggled, CoreEmitter.IsPowered);

        UpdateVisuals();
    }

	private void UpdateVisuals()
	{
		Modulate = CoreEmitter.IsPowered ? Colors.Yellow : Colors.DimGray;
	}
}
