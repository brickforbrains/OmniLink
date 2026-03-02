namespace OmniLink.Core.Interfaces;

using System.Collections.Generic;
/// <summary>
/// The fundamental contract for anything the processes logic in the game.
/// </summary>
public interface ILogicComponent
{
    string ComponentId { get;  }
    bool IsActive { get; set; }
    int MinInputs { get; }
    Dictionary<string, bool> Inputs { get; }

    bool Evaluate(); //No longer needs a param; uses LastInputState
}
