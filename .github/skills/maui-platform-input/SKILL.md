# Skill: MAUI Platform Input

## Purpose
Guide changes that adapt PacAnne input to Android, iOS, Mac Catalyst, and Windows without coupling gameplay to platform APIs.

## Required approach
1. Read `docs/platform-input.md` and `docs/architecture.md` first.
2. Locate the current `IHumanInterfaceParser` implementation and all consumers before changing input.
3. Keep the parser as the single gameplay-facing state/event store.
4. Use MAUI gesture recognizers for touch gestures.
5. Add keyboard handling only for Windows and Mac Catalyst.
6. Keep pointer/mouse gesture support on Windows and Mac Catalyst.
7. Use platform conditionals only at the host/platform boundary.
8. Dispose event subscriptions with the component/view lifecycle.

## Mapping
- directional swipe/pan -> `Swiped(Keys.*)`
- tap -> `TapHappened()`
- long press -> `LongPressHappened()`
- keyboard down -> `KeyDown(...)`
- keyboard up -> `KeyUp(...)`

## Guardrails
Do not add MAUI references to `PacAnne.Core`. Do not create a second input state machine. Do not add keyboard handlers to Android/iOS. Do not alter game-loop timing to solve input delivery.

## Validation
Build every supported target that can be built in the current environment. Confirm the platform matrix in `docs/platform-input.md` and update `docs/stages.md` only after the implementation meets the definition of done.