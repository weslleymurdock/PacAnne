
using Microsoft.AspNetCore.Components;

namespace PacAnne.Core;

public static class Spritesheet
{
    private static ElementReference? _reference;

    public static ElementReference Reference => _reference ?? throw new InvalidOperationException("Nothing set yet!");

    public static void SetReference(ElementReference reference)
    {
        _reference = reference;
    }

    public static Size Size => new(225, 248);
}