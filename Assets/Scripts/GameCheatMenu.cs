using DELTation.DIFramework.Cheats;
using UnityEngine;

public class GameCheatMenu : CheatMenuBase
{
    protected override void Build()
    {
        CreateButton("Log", () => Debug.Log("Hello from cheats."));
    }
}