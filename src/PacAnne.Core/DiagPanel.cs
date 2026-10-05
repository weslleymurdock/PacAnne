// ReSharper disable HeapView.BoxingAllocation



namespace PacAnne.Core;

public class DiagPanel
{
    public async ValueTask Draw(CanvasWrapper ds)
    {
        await ds.SetGlobalAlphaAsync(.5f);

        await ds.FillRect(0, 0, 200, 100, Microsoft.Maui.Graphics.Colors.DarkSlateGray);

        await ds.DrawText($"FPS:{DiagInfo.Fps}", Point.Zero, Colors.White);
        await ds.DrawText($"Tot time:{DiagInfo.TotalTime:c}", new(50, 00), Colors.White);
        await ds.DrawText($"Draw count:{DiagInfo.DrawCount:D}", new(0, 15), Colors.White);

        await ds.DrawText(
            $"Update count:{DiagInfo.UpdateCount:D} ({DiagInfo.UpdateCount - DiagInfo.DrawCount:D} more)",
            new(0, 30),
            Colors.White);

        await ds.DrawText($"Elapsed:{DiagInfo.Elapsed:g}", new(0, 45), Colors.White);

        await ds.DrawText($"loop tm taken:{DiagInfo.GameLoopDurationMs:D}", new(0, 60), Colors.White);
        await ds.DrawText($"max loop tm taken:{DiagInfo.MaxGameLoopDurationMs:D}", new(0, 65), Colors.White);

        await ds.DrawText($"slow frames:{DiagInfo.SlowElapsedCount:D}", new(0, 80), Colors.White);

        await ds.SetGlobalAlphaAsync(1f);
    }
}