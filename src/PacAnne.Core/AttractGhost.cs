using PacAnne.Core.Ghosts;

namespace PacAnne.Core;

public class AttractGhost : SimpleGhost
{
    public AttractGhost(GhostNickname nickName, Direction direction) : base(nickName, direction)
    {
        Alive = true;
    }

    public void SetFrightened()
    {
        State = GhostState.Frightened;
    }

    public bool Alive { get; set; }
}