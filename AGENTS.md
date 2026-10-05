# PacAnne Agent Instructions

## Project
PacAnne is a .NET 10 .NET MAUI Blazor Hybrid game port based on the original PacManBlazor project. The game core is shared C# code; the MAUI host provides platform integration, rendering host integration, and platform-specific input.

## Target platforms
- Android (`net10.0-android`)
- iOS (`net10.0-ios`)
- Mac Catalyst (`net10.0-maccatalyst`)
- Windows (`net10.0-windows10.0.19041.0`)

Do not add support for other platforms unless explicitly requested.

## Architecture rules
- Keep gameplay rules in `PacAnne.Core` and avoid MAUI/UI dependencies there.
- `src/PacAnne` is the MAUI Blazor Hybrid host and owns platform/UI integration.
- Composition/host code may reference Core; Core must remain platform-agnostic.
- Treat `IHumanInterfaceParser` as the gameplay-facing input abstraction. Platform adapters translate physical input into this abstraction.
- Prefer small platform adapters/services over `#if` branches spread through gameplay code.
- Use conditional compilation only at the MAUI/platform boundary when a platform API genuinely requires it.

## Input policy
- Android/iOS: touch gestures through MAUI `GestureRecognizers`.
- Windows/Mac Catalyst: mouse/pointer gestures and keyboard input.
- Keyboard input is Windows and Mac Catalyst only.
- Directional swipe/pan, tap, and long-press semantics must map to the existing parser concepts.
- Do not introduce keyboard support on Android or iOS.

## Coding rules
- .NET 10 and nullable reference types remain enabled.
- Prefer async APIs where an operation is asynchronous.
- Keep public APIs documented when introducing new public types/members.
- Use en-US for source comments and documentation.
- Do not introduce unrelated refactors.
- Do not replace the existing canvas implementation unless required by the task.

## Validation
Build affected projects, verify platform-specific compilation, verify event translation reaches `IHumanInterfaceParser`, and verify Android/iOS do not register keyboard handlers. See `docs/architecture.md`, `docs/platform-input.md`, `docs/decisions.md`, and `.github/skills/*/SKILL.md` before modifying the project.