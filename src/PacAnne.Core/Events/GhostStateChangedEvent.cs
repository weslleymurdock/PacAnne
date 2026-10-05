using PacAnne.Core.Ghosts;

namespace PacAnne.Core.Events;

public readonly struct GhostStateChangedEvent : INotification
{
    public IGhost Ghost { get; }

    public GhostState State { get; }

    public GhostStateChangedEvent(IGhost ghost, GhostState state)
    {
        Ghost = ghost;
        State = state;
    }
}