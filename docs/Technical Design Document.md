# Technical Design Document: OmniLink (Systems Archeologist)

###### Version: 1.1 (Phase 1 Focused)

###### Status: Architecture Design

###### Target Framework: .NET 8/10 (Godot 4.6.1 .NET Edition)

###### \_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 1\. Architectural Overview



To satisfy the professional goal of high testability and clean code, the project is divided into three strictly decoupled layers.



#### 1.1 The Domain Layer (OmniLink.Core)

 	• **Responsibility**: Pure business logic.

 	• **Content**: Logic gate evaluation, math calculations, and state definitions.

 	• **Constraints**: Zero dependencies on Godot namespaces. This ensures the engine can be swapped or the logic can be run in a console app for lightning-fast unit testing.



#### 1.2 The Infrastructure Layer (OmniLink.Core)

 	• **Responsibility**: Data persistence and external services.

 	• **Content**: JSON Serialization (System.Text.Json), Save/Load managers, and the IAdProvider interface.



#### 1.3 The Presentation Layer (OmniLink.Godot)

 	• **Responsibility**: User input and visual feedback.

 	• **Content**: Godot Scenes, Sprite management, and "Bridge" scripts that pass inputs from the player to the Core.

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 2\. Component Design: The Logic Engine

#### 2.1 The Interface Contract

We use the Strategy Pattern to ensure the engine is "Open-Closed" (Open for extension, closed for modification).
the interface ILogicComponent will have the following members:
 	• **string ComponentId**
 	• **Dictionary<string, bool> Inputs**
 	• **int MinInputs { get; }**

 	• **bool Evaluate()**

### 2.2 Phase 1 Implementations

 	• **AndGate.cs**: inputs.All(x => x)

 	• **OrGate.cs**: inputs.Any(x => x)

 	• **NotGate.cs**: !inputs.First()

 	• **XorGate.cs**: inputs.Count(x => x) % 2 != 0

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 3\. The Bridge: Signal-Driven Interaction

To keep the UI from becoming "spaghetti code," we use an Event-Bus or Signal pattern.

 	• **Trigger**: Player toggles a physical lever in a DungeonScene.

 	• **Action**: The lever script emits a LeversChanged signal.

 	• **Processing**: A PuzzleController (Bridge) catches the signal, feeds the current state of all levers into the Core.Evaluator, and receives a result.

 	• **Feedback**: If result == true, the PuzzleController invokes a Door.Unlock() method via an interface.

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 4\. Persistence \& Metadata

Levels are defined in JSON to allow for easy content expansion without recompiling the code.



Schema Example (LevelData):

 	• string LevelId

 	• List<GateData> InitialGates

 	• Dictionary<string, bool> TargetState

 	• float IdleResourceRate (For the future 'Command Prompt' idle mode)

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 5\. Monetization Middleware (Phase 3)

To demonstrate professional API handling, we will not call AdMob/Google Play directly from the game logic.

 	• **Interface**: IMonetizationService

 	• **Methods**: RequestAdSync(), IsPremiumUser(), VerifySubscription()

 	• **Implementation**: A GooglePlayService.cs class that handles the actual Android-specific calls.

 	• **Testing**: A MockMonetizationService.cs that allows you to play the game without ads during development.

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 6\. Testing Strategy (TDD)

 	• **Tool**: GDUnit4 / NUnit.

 	• **Core** **Tests**: Every gate implementation must have 100% branch coverage (Testing all combinations of True/False).

 	• **Level Tests**: Validating that every JSON level in the /assets folder is logically "solvable."

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

### 7\. Roadmap to "Functional First"

1. **Commit 1**: Project scaffolding and ILogicGate interface.
2. **Commit 2**: Basic And/Or/Not implementations with passing Unit Tests.
3. **Commit 3**: A Godot scene where a character can walk to a terminal and toggle a boolean state.
