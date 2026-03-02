namespace OmniLink.Core.Models;

using OmniLink.Core.Interfaces;
using System.Collections.Generic;

public abstract class BaseLogicComponent : ILogicComponent
{
    public string ComponentId { get; init; }
    public bool IsActive { get; set; } = true;
    public Dictionary<string, bool> Inputs { get; } = new();
    // using virtual so gates like AND can override to 2
    public virtual int MinInputs => 1;

    // cache result for Idle Engine use
    public bool OutputState { get; protected set; }

    protected BaseLogicComponent(string id) => ComponentId = id;

    public abstract bool Evaluate();
}
