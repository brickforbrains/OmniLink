using OmniLink.Core.Models;

namespace OmniLink.Core.LogicEngine;

public class XorGate : BaseLogicComponent
{
    public XorGate(string id) : base(id)
    {
        Inputs.Add("In1", false);
        Inputs.Add("In2", false);
    }

    public override bool Evaluate()
    {
        if (!IsActive) return OutputState = false;

        bool in1 = Inputs.GetValueOrDefault("In1");
        bool in2 = Inputs.GetValueOrDefault("In2");

        OutputState = in1 ^ in2;
        return OutputState;
    }
}