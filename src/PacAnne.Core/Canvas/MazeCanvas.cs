
using Blazor.Extensions.Canvas.Canvas2D;

namespace PacAnne.Core.Canvas;

/// <summary>
/// Represents the maze canvas.  Each Player has their own canvas and when they eat pills
/// etc., their canvas has individual cells cleared.  When the 'main' maze is drawn,
/// the current player's canvas is drawn.
/// </summary>
public class MazeCanvas : CanvasWrapper
{
    public MazeCanvas(Canvas2DContext context) : base(context)
    {
    }

    public async ValueTask Reset()
    {
        int width = (int)Spritesheet.Size.Width;
        int height = (int)Spritesheet.Size.Height;

        var dim = Constants.UnscaledCanvasSize;

        await Clear((int)dim.X, (int)dim.Y);
        Rectangle r = new(0, 0, width, height);

        await DrawImage(
            Spritesheet.Reference,
            new Point(0, 0),
            r);
    }
}
