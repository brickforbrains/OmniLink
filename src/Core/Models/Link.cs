namespace OmniLink.Core.Models;

using OmniLink.Core.Interfaces;
using System.Security.Cryptography.X509Certificates;

public class Link
{
    public string LinkId { get; init; }
    public ILogicComponent? Source { get; set; }
    public ILogicComponent? Target { get; set; }
    public string TargetPinName { get; set; } = "In1"; //default pin

    // The current signal state of the "wire"
    public bool SignalState { get; private set; }

    public Link(string id) => LinkId = id;

    /// <summary>
    /// Pulls the output from Source and pushes it to the Target's input.
    /// </summary>
    public void Propagate()
    {
        if (Source == null || Target == null) return;

        bool signal = Source.Evaluate();

        if (Target.Inputs.ContainsKey(TargetPinName))
        {
            Target.Inputs[TargetPinName] = signal;
        }
    }
}