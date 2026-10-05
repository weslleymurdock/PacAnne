namespace PacAnne.Core;

public interface IStatusPanel
{
    void Update(CanvasTimingInformation timing);

    ValueTask Draw(CanvasWrapper ds);
}