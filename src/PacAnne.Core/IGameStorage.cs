namespace PacAnne.Core;

public interface IGameStorage
{
    ValueTask<int> GetHighScore();

    ValueTask SetHighScore(int highScore);
}