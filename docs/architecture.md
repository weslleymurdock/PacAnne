# Architecture Guidelines

## Layers

```text
src/PacAnne.Core
  Gameplay, entities, acts, input abstraction, canvas-facing contracts

src/PacAnne
  MAUI host, Blazor components, JavaScript interop, platform integration

Platforms/*
  Native MAUI platform entry points and platform-specific integration only
```

`PacAnne.Core` must remain independent of MAUI platform APIs. The MAUI host may reference Core, but Core must not reference `Microsoft.Maui.Controls`, platform namespaces, WebView types, or browser-specific APIs.

## Dependency direction

```text
Platform integration -> MAUI host -> PacAnne.Core
```

Gameplay code consumes abstractions such as `IHumanInterfaceParser`; it must not know whether input originated from a finger, mouse, or keyboard.

## Current rendering boundary
`Home.razor` owns the Blazor canvas components and currently forwards browser/JavaScript callbacks into `HumanInterfaceParser`. `Blazor.Extensions.Canvas` remains the rendering mechanism for this migration stage.

## DI
The MAUI host registers Core services in `MauiProgram`. Preserve the singleton lifetime of the stateful input parser unless a task explicitly redesigns it.

## Platform conditionals
Keep `#if ANDROID`, `#if IOS`, `#if WINDOWS`, and `#if MACCATALYST` at the host/integration boundary. Never spread platform conditionals through PacAnne.Core gameplay classes.

## Input flow

```text
Touch / mouse / keyboard
        |
        v
MAUI/Blazor input adapter
        |
        v
IHumanInterfaceParser
        |
        v
Game / PacMan / GameActs / Ghosts
```

The adapter owns event normalization; the game owns interpretation of normalized input.