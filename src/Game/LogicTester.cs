using Godot;
using OmniLink.Core.Models;
using OmniLink.Core.LogicEngine;

public partial class LogicTester : Node2D
{
    public override void _Ready()
    {
        GD.Print("FINAL PRE-COMMIT SANITY CHECK...");

        // 1. Setup (Using our new Dictionary-based pins)
        var batteryA = new Emitter("BAT_A") { IsPowered = true };
        var batteryB = new Emitter("BAT_B") { IsPowered = true };
        var andGate = new AndGate("AND_01");

        // 2. Wiring (Using TargetPinName)
        var wire1 = new Link("W1") { Source = batteryA, Target = andGate, TargetPinName = "In1" };
        var wire2 = new Link("W2") { Source = batteryB, Target = andGate, TargetPinName = "In2" };

        // 3. Simulation
        wire1.Propagate();
        wire2.Propagate();

        // 4. Verification
        bool result = andGate.Evaluate();
        GD.Print($"Verification: {andGate.ComponentId} Result is {result}");

        if (result)
        {
            GD.Print("✅ ALL SYSTEMS NOMINAL. READY FOR COMMIT.");
        }
        else
        {
            GD.Print("❌ WARNING: Logic mismatch. Check Dictionary Keys!");
        }
    }
}