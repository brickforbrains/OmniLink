using OmniLink.Core.Models;

namespace OmniLink.Core.LogicEngine;

public class NotGate : BaseLogicComponent
{
    public NotGate(string id) : base(id) 
    {
        Inputs.Add("In1", false);
    }

    public override bool Evaluate()
    {
        // If the gate is disabled, it always returns false
        if (!IsActive) return false;

        return !Inputs["In1"];
    }
}
