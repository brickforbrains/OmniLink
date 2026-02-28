namespace OmniLink.Core.Interfaces;

/// <summary>
/// The fundamental contract for anything the processes logic in the game.
/// </summary>
internal interface ILogicComponent
{
    string ComponentId { get;  }
    bool isActive { get; set; }

    //Taking an input state and returning the resulting output.
    bool Evaluate(bool inputState);
}
