# Architecture Overview


OmniLink utilizes a Decoupled Logic Architecture. By separating the "Simulation Engine" (Pure C#) from the "Representation Layer" (Godot 4), we ensure that core game rules are verifiable via Unit Tests independent of the frame rate or physics engine.

Key Patterns
Strategy Pattern: 
---

Used for Logic Gate evaluation. Each gate type (AND, OR, XOR) implements a common interface, allowing for hot-swappable logic components.

#### Observer Pattern (Signals):

Leveraging Godot's C# Signals for a reactive UI that responds to changes in the underlying simulation state.

