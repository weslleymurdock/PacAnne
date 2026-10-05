using PacAnne.Core.Ghosts;

namespace PacAnne.Core;

public interface IGhostCollection
{
    IGhost GetGhost(GhostNickname nickName);

    IGhost[] Ghosts { get; }

    ValueTask DrawAll(CanvasWrapper canvas);

    ValueTask Update(CanvasTimingInformation timing);
}