using Godot;
using OmniLink.Core.Interfaces;
using OmniLink.Core.LogicEngine;
using OmniLink.Core.Models;
using OmniLink.Core.Services;

public partial class PuzzleController : Node2D
{
    private LogicManager _simulation = new();

    public override void _Ready()
    {
        // Setup a small circuit: Emitter -> NOT -> AND (Input 1)
        var battery = new Emitter("MainPower") { IsPowered = true };
        var inverter = new NotGate("Inverter");
        var andGate = new AndGate("FinalLock");

        // Define the connections
        var wire1 = new Link("W1") { Source = battery, Target = inverter };
        var wire2 = new Link("W2") { Source = inverter, Target = andGate, TargetPinName = "In1" };

        // Register them with the manager
        _simulation.Components.AddRange(new[] { (ILogicComponent)battery, inverter, andGate });
        _simulation.Links.AddRange(new[] { wire1, wire2 });

        // Run the first pulse
        _simulation.UpdateSimulation();

        GD.Print($"Circuit Ready. Lock state: {andGate.Evaluate()}");
    }
}
