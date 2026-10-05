using PacAnne.Core.Ghosts;

namespace PacAnne.Core.Events;

public readonly struct GhostLeftHouseEvent : INotification
{
    public IGhost Ghost { get; }

    public GhostLeftHouseEvent(IGhost ghost)
    {
        Ghost = ghost;
    }
}