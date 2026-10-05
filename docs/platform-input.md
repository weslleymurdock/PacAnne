# Platform Input Specification

## Goal
Provide native-feeling input across MAUI targets while preserving the existing Core input contract.

## Platform matrix

| Target | Gesture recognizers | Mouse/pointer | Keyboard |
|---|---|---|---|
| Android | Required | Not required | Forbidden |
| iOS | Required | Not required | Forbidden |
| Mac Catalyst | Required | Required | Required |
| Windows | Required | Required | Required |

Gesture recognition should be implemented at the MAUI host surface that owns the game canvas. `PacAnne.Core` must not reference MAUI controls.

## Direction mapping
- Swipe/pan left -> `Keys.Left`
- Swipe/pan right -> `Keys.Right`
- Swipe/pan up -> `Keys.Up`
- Swipe/pan down -> `Keys.Down`
- Tap -> `TapHappened()`
- Long press -> `LongPressHappened()`

The retention behavior in `HumanInterfaceParser` remains authoritative.

## Desktop keyboard
Windows and Mac Catalyst support the existing directional keys and other controls already defined by `Keys`. Keyboard events translate into `KeyDown` and `KeyUp` and do not bypass `IHumanInterfaceParser`.

Keyboard handling must be compiled/registered only for Windows and Mac Catalyst. Android and iOS must not install or expose a keyboard input path for this feature.

## Desktop pointer
Windows and Mac Catalyst retain gesture interaction. Pointer/mouse interaction may be translated into the same tap/pan/press semantics used by touch.

## Focus
Keyboard input requires a focusable game surface or equivalent host-level focus strategy. Focus acquisition must be explicit and must not steal focus from unrelated controls.

## Lifecycle
Input subscriptions must be removed/disposed when the owning component/view is disposed or detached. Do not accumulate event handlers across navigation or component recreation.

## Compatibility
Do not remove the existing `OnGesture`, `KeyDown`, or `KeyUp` callbacks until the replacement path is proven equivalent. If the new implementation supersedes them, remove dead paths rather than maintaining two competing sources of truth.