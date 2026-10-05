# Project Guidelines

## Scope
PacAnne is a platform port of a browser Pac-Man-style game into .NET MAUI Blazor Hybrid. Preserve existing game behavior while adapting host concerns to MAUI.

## General rules
- Make the smallest coherent change required by the current stage.
- Preserve gameplay timing, collision, movement, and state semantics.
- Do not rename established Core abstractions without a migration reason.
- Avoid browser-only assumptions in platform input code.
- Keep UI code responsible for UI concerns and Core responsible for game rules.
- Prefer explicit, testable translation methods for input events.

## Input matrix

| Platform | Touch gestures | Mouse/pointer | Keyboard |
|---|---:|---:|---:|
| Android | Yes | N/A | No |
| iOS | Yes | N/A | No |
| Mac Catalyst | Yes | Yes | Yes |
| Windows | Yes | Yes | Yes |

## Event semantics
The existing Core parser exposes directional state and transient events including tap, long press, key press/release, and swipe/pan. New adapters must preserve those semantics instead of introducing gameplay-specific commands.

## Build discipline
A platform change is incomplete if it builds only for the developer's current target. Compile each supported target when the environment makes that possible; otherwise document unvalidated targets.

## Do not
- Add a JavaScript keyboard listener as the only input implementation.
- Add Android/iOS keyboard code.
- Put MAUI gesture recognizer types in `PacAnne.Core`.
- Change the game loop to compensate for input handling.
- Introduce a second mutable input state store without a clear synchronization strategy.