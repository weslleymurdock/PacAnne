using Microsoft.JSInterop;

namespace PacAnne.Core;

public interface ISoundLoader
{
    SoundEffect GetSoundEffect(SoundName name);

    IEnumerable<SoundEffect> AllSounds { get; }

    ValueTask LoadAll(IJSRuntime runtime);
}