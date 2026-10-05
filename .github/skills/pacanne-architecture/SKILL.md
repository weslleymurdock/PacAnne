# Skill: PacAnne Architecture

## Purpose
Keep the MAUI host and Core boundaries clean while extending the game.

## Rules
- `PacAnne.Core` contains gameplay and platform-neutral contracts.
- `PacAnne` contains MAUI Blazor Hybrid UI and integration.
- Platform-specific APIs belong in `src/PacAnne/Platforms` or a clearly isolated host integration layer.
- Preserve DI lifetimes unless there is a documented reason to change them.
- Avoid unrelated refactors during feature work.
- Document architectural changes in `docs/decisions.md`.

## Review checklist
- Does the change introduce a platform dependency into Core?
- Is the new behavior exposed through an existing abstraction where possible?
- Are platform-specific branches isolated?
- Is lifecycle cleanup handled?
- Does the implementation preserve existing game behavior?