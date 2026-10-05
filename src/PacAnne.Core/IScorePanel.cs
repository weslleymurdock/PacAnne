namespace PacAnne.Core;

public interface IScorePanel
{
    void Update(CanvasTimingInformation timingInformation);

    ValueTask Draw(CanvasWrapper ds);
}