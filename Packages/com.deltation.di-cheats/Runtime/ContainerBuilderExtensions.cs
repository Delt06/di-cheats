using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DELTation.DIFramework.Cheats
{
    public static class ContainerBuilderExtensions
    {
        [NotNull]
        public static ICanRegisterContainerBuilder RegisterCheatMenu<TCheatMenu>(
            [NotNull] this ICanRegisterContainerBuilder containerBuilder, string cheatCanvasPath = "Cheats/CheatCanvas")
            where TCheatMenu : CheatMenuBase
        {
            if (containerBuilder == null) throw new ArgumentNullException(nameof(containerBuilder));
#if DI_CHEATS_FORCE_IN_RELEASE || UNITY_EDITOR || DEVELOPMENT_BUILD
            return containerBuilder.RegisterFromMethod(() =>
                {
                    var cheatCanvasPrefab = Resources.Load<CheatCanvas>(cheatCanvasPath);
                    var cheatMenuRefs = Object.Instantiate(cheatCanvasPrefab)
                        .GetComponentInChildren<CheatMenuRefs>(true);
                    return cheatMenuRefs.gameObject.AddComponent<TCheatMenu>();
                }
            ).AsInternal();
#else
            return containerBuilder;
#endif
        }
    }
}