using Godot;
using OmniLink.Core.Interfaces;
using OmniLink.Core.LogicEngine;
using OmniLink.Core.Models;
using OmniLink.Core.Services;

public partial class PuzzleController : Node2D
{
    private LogicManager _simulation = new();

    private AndGate _andGate;
    private NotGate _notGate;

    public override void _Ready()
    {
        _notGate = new NotGate("Inverter");
        _andGate = new AndGate("FinalLock");

        _simulation.Components.Add(_notGate);
        _simulation.Components.Add(_andGate);

        int emitterCount = 0;

        foreach (Node child in GetChildren())
        {
            if (child is EmitterNode visualEmitter)
            {
                emitterCount++;
                _simulation.Components.Add(visualEmitter.CoreEmitter);
                visualEmitter.PowerToggled += (state) => RequestSimulationUpdate();

                if (emitterCount == 1)
                {
                    var wire1 = new Link("W1") { Source = visualEmitter.CoreEmitter, Target = _notGate };
                    _simulation.Links.Add(wire1);
                }
                else
                {
                    // This handles Emitter 2, 3, etc.
                    var wireExtra = new Link($"W_Extra_{emitterCount}")
                    {
                        Source = visualEmitter.CoreEmitter,
                        Target = _andGate,
                        TargetPinName = $"In{emitterCount}" // Dynamically targets In2, In3...
                    };
                    _simulation.Links.Add(wireExtra);
                }
            }
        }

        var wireFinal = new Link("W_Final") { Source = _notGate, Target = _andGate, TargetPinName = "In1" };
        _simulation.Links.Add(wireFinal);

        RequestSimulationUpdate();
    }

    public void RequestSimulationUpdate()
    {
        _simulation.UpdateSimulation();
        bool result = _andGate.Evaluate();
        GD.Print($"Circuit State: {result}.");
    }
}
