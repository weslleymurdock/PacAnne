using PacAnne.Core.Ghosts;

namespace PacAnne.Core.Events;

public readonly struct GhostMovementModeChangedEvent : INotification
{
    public IGhost Ghost { get; }

    public GhostMovementMode Mode { get; }

    public GhostMovementModeChangedEvent(IGhost ghost, GhostMovementMode mode)
    {
        Ghost = ghost;
        Mode = mode;
    }
}