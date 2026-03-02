namespace OmniLink.Core.LogicEngine;

using OmniLink.Core.Models;
using System.Linq;

public class AndGate : BaseLogicComponent
{
    public AndGate(string id) : base(id)
    {
        Inputs.Add("In1", false);
        Inputs.Add("In2", false);
    }

    public override bool Evaluate()
    {
        if (!IsActive)
        {
            OutputState = false;
            return false;
        }
        // ALL inputs must be true
        OutputState = Inputs.Values.All(v => v == true);
        return OutputState;
    }
}
