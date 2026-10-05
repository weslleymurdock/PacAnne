# Development Stages

## Current baseline
The MAUI Blazor Hybrid application builds and launches. Known gameplay/UI bugs may remain and are outside the scope of the input migration unless they directly prevent input validation.

## Input platform upgrade
**Goal:** replace browser-centric input assumptions with MAUI-native gesture input and desktop keyboard support.

### Definition of Done
- [ ] Android uses MAUI gesture recognizers for touch input.
- [ ] iOS uses MAUI gesture recognizers for touch input.
- [ ] Windows supports gesture/pointer input and keyboard input.
- [ ] Mac Catalyst supports gesture/pointer input and keyboard input.
- [ ] Android/iOS do not register the desktop keyboard path.
- [ ] Existing `IHumanInterfaceParser` semantics remain intact.
- [ ] Input event subscriptions are cleaned up with the owning UI lifecycle.
- [ ] No MAUI/platform references are introduced into `PacAnne.Core`.
- [ ] All supported target projects compile after the change where the build environment permits.
- [ ] The agent documents any platform that could not be physically validated.
