#  DI Cheats

[![Version](https://img.shields.io/github/v/release/Delt06/di-cheats?sort=semver)](https://github.com/Delt06/di-cheats/releases)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A cheat system for [DI Framework](https://github.com/Delt06/di-framework).

> Developed and tested with Unity 2020.3.16f1

## Table of contents

- [Installation](#installation)
- [Usage](#usage)

## Installation

Before proceeding, please make sure you have the following dependencies installed:
- [DI Framework](https://github.com/Delt06/di-framework)
- [TextMeshPro](https://docs.unity3d.com/Manual/com.unity.textmeshpro.html)

### Option 1
- Open Package Manager through Window/Package Manager
- Click "+" and choose "Add package from git URL..."
- Insert the URL: https://github.com/Delt06/di-cheats.git?path=Packages/com.deltation.di-cheats

### Option 2  
Add the following line to `Packages/manifest.json`:
```
"com.deltation.di-cheats": "https://github.com/Delt06/di-cheats.git?path=Packages/com.deltation.di-cheats",
```

## Usage

Create a cheat menu:
```csharp
using DELTation.DIFramework.Cheats;
using UnityEngine;

public class GameCheatMenu : CheatMenuBase
{
    protected override void Build()
    {
        CreateButton("Log", () => Debug.Log("Hello from cheats."));
    }
}
```

Create or modify existing dependency container:
```csharp
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
```

Define `DI_CHEATS_FORCE_IN_RELEASE` if you want to have cheats in a release build.
