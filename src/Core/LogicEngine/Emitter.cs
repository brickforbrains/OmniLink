namespace OmniLink.Core.LogicEngine;

using OmniLink.Core.Models;

public class Emitter : BaseLogicComponent
{
    // The player can toggle this on/off in the game
    public bool IsPowered { get; set; } = false;

    public Emitter(string id) : base(id) { }

    public override bool Evaluate()
    {
        // An emitter simply outputs its power state
        return IsActive && IsPowered;
    }
}