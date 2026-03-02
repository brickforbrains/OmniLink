using OmniLink.Core.Interfaces;

namespace OmniLink.Core.Models;

public class BotScout
{
    public required string BotName { get; set; }
    public decimal BaseGenerationRate { get; set; } = 1.0m;

    // This bot's efficiency is tied to a Logic Component (a "Macro")
    public ILogicComponent? OptimizationMacro { get; set; }

    public decimal GetCurrentRate()
    {
        // If the logic circuit is "Solved" (True), the bot works at 2x speed
        bool isOptimized = OptimizationMacro?.Evaluate() ?? false;
        return isOptimized ? BaseGenerationRate * 2 : BaseGenerationRate;
    }
}
