# Skill: PacAnne Validation

## Purpose
Validate changes without masking platform-specific compile errors.

## Build matrix
The project targets Android, iOS, Mac Catalyst, and Windows. Validate all targets available in the agent environment.

## Input validation
| Platform | Expected |
|---|---|
| Android | touch gestures; no keyboard path |
| iOS | touch gestures; no keyboard path |
| Mac Catalyst | touch/pointer gestures + keyboard |
| Windows | touch/pointer gestures + keyboard |

## Regression guardrails
- Do not modify gameplay rules solely to make input work.
- Do not add a second parser or mutable event buffer.
- Do not leave event handlers subscribed after component disposal.
- Record unvalidated platform/device combinations explicitly rather than claiming success.