namespace OmniLink.Core.Services;

using OmniLink.Core.Interfaces;
using OmniLink.Core.Models;
using System.Collections.Generic;

public class LogicManager
{
    public List<ILogicComponent> Components { get; } = new();
    public List<Link> Links { get; } = new();

    /// <summary>
    /// world's heartbeat
    /// </summary>
   public void UpdateSimulation()
    {
        // 1. Let all Links move their data from Source to Target
        foreach (var link in Links)
        {
            link.Propagate();
        }

        // for now evaluate everything once per beat, may update to topo sort later 
        foreach (var component in Components)
        {
            component.Evaluate();
        }
    }
}
