using System.Reflection;
using PacAnne;
using PacAnne.Core;
using PacAnne.Core.Audio;
using PacAnne.Core.GameActs;
using PacAnne.Core.Ghosts;
using PacAnne.Core.Requests;
using Microsoft.Extensions.Logging;

namespace PacAnne;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
		IServiceCollection services = builder.Services;

		services.AddSingleton<IGame, Game>();
		services.AddSingleton<IGameStorage, GameStorage>();
		services.AddSingleton<IHumanInterfaceParser, HumanInterfaceParser>();
		services.AddSingleton<ISoundLoader, SoundLoader>();
		services.AddSingleton<IGameSoundPlayer, GameSoundPlayer>();

		services.AddSingleton<IAct, AttractAct>();
		services.AddSingleton<IAct, GameAct>();

		services.AddSingleton<IAct, BigPacChaseAct>();
		services.AddSingleton<IAct, GameOverAct>();
		services.AddSingleton<IAct, GhostTearAct>();
		services.AddSingleton<IAct, LevelFinishedAct>();
		services.AddSingleton<IAct, NullAct>();
		services.AddSingleton<IAct, PacManDyingAct>();
		services.AddSingleton<IAct, PlayerIntroAct>();
		services.AddSingleton<IAct, DemoPlayerIntroAct>();
		services.AddSingleton<IAct, StartButtonAct>();
		services.AddSingleton<IAct, TornGhostChaseAct>();

		services.AddSingleton<IAct, PlayerGameOverAct>();

		services.AddSingleton<IActs, Acts>();

		services.AddSingleton<IGameStats, GameStats>();

		services.AddSingleton<IHaveTheMazeCanvases, MazeCanvases>();

		services.AddSingleton<IGhost, Blinky>();
		services.AddSingleton<IGhost, Pinky>();
		services.AddSingleton<IGhost, Inky>();
		services.AddSingleton<IGhost, Clyde>();

		services.AddSingleton<IPacMan, PacAnne.Core.PacMan>();

		services.AddSingleton<ICoinBox, CoinBox>();

		services.AddSingleton<IFruit, Fruit>();

		services.AddSingleton<IGhostCollection, GhostCollection>();

		services.AddSingleton<IStatusPanel, StatusPanel>();
		services.AddSingleton<IScorePanel, ScorePanel>();

		services.AddSingleton<IMaze, Maze>();

		services.AddLogging();

		services.Add(
			new(
				typeof(IExceptionNotificationService),
				typeof(ExceptionNotificationService),
				ServiceLifetime.Singleton));

		Assembly thisAssembly = Assembly.GetExecutingAssembly();

		Assembly componentsAssembly =
			typeof(ClassThatLivesInGameComponentsActsAsAMarkerForThisAssemblyForReflection).Assembly;

		services.AddMediatR(
			c =>
			{
				c.Lifetime = ServiceLifetime.Singleton;
				c.RegisterServicesFromAssembly(thisAssembly);
				c.RegisterServicesFromAssembly(componentsAssembly);
			});

		services.AddSingleton(new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) });
		return builder.Build();
	}
}
