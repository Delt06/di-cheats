using DELTation.DIFramework;
using DELTation.DIFramework.Cheats;
using DELTation.DIFramework.Containers;

public class CompositionRoot : DependencyContainerBase
{
    protected override void ComposeDependencies(ICanRegisterContainerBuilder builder)
    {
        builder.RegisterCheatMenu<GameCheatMenu>();
    }
}