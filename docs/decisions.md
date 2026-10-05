# Architecture Decisions

## ADR-001: Keep input normalization in the existing Core abstraction

**Status:** Accepted

`IHumanInterfaceParser` remains the gameplay-facing input contract. Platform adapters translate physical events into its existing methods and state. This prevents game entities and acts from becoming coupled to MAUI or a particular device.

## ADR-002: Use MAUI gesture recognizers for touch

**Status:** Accepted

Android and iOS input should be driven by MAUI gesture recognizers rather than browser-only JavaScript gesture handling. This makes touch input native to the MAUI host.

## ADR-003: Desktop supports both pointer gestures and keyboard

**Status:** Accepted

Windows and Mac Catalyst support gesture/pointer interaction and keyboard input. Keyboard is an additional input path, not a replacement for pointer interaction.

## ADR-004: Keyboard is desktop-only

**Status:** Accepted

Keyboard handling is compiled and registered only for Windows and Mac Catalyst. Android and iOS do not receive keyboard handlers as part of the game input implementation.

## ADR-005: Preserve the existing event vocabulary

**Status:** Accepted

The migration maps gestures to `TapHappened`, `LongPressHappened`, and `Swiped` and maps keyboard press/release to `KeyDown`/`KeyUp`. Gameplay classes should not understand platform event types.

## ADR-006: Avoid platform conditionals in PacAnne.Core

**Status:** Accepted

Platform conditionals belong at the MAUI host boundary. The Core assembly remains portable and platform-agnostic.