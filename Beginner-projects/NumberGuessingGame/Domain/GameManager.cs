using System.Reflection.Metadata;

namespace NumberGuessingGame.Domain;

public class GameManager
{
    private readonly IGamesRepo _gamesRepo;
    private readonly List<Game> _games;

    private const int easy = 10;
    private const int medium = 8;
    private const int hard = 5;

    public GameManager(IGamesRepo gamesRepo)
    {
        _gamesRepo = gamesRepo;
        _games = _gamesRepo.LoadGames();
    }

    public Game StartGame()
    {
        Game game = new Game()
        {
            Id = _games.Count() > 0 ? _games.Max(x => x.Id) : 1,
            StartDate = DateTime.Now
        };
        ManageGameMode(game);
        return game;
    }

    public void StopGame(Game game)
    {
        switch (game.Mode)
        {
            case Game.GameMode.Easy: game.Attempts = game.Attempts != 0 ? easy - 1 - game.Lives : 0; break;
            case Game.GameMode.Medium: game.Attempts = game.Attempts != 0 ? medium - 1 - game.Lives : 0; break;
            case Game.GameMode.Hard: game.Attempts = game.Attempts != 0 ? hard - 1 - game.Lives : 0; break;
        }
        _games.Add(game);
        _gamesRepo.SaveGames(_games);
    }

    public void ShowAllGames()
    {
        foreach (var game in _games)
        {
            if (game.Result)
                Console.WriteLine($"Game Id: {game.Id}\n" +
                                  $"Game Mode: {game.Mode}\n" +
                                  $"Attempts: {game.Attempts}\n" +
                                  $"Result: you won\n" +
                                  $"Game Started on: {game.StartDate.Date} at {game.StartDate.TimeOfDay}\n" +
                                  $"Game Ended on: {game.EndDate.Date} at {game.EndDate.TimeOfDay}\n" +
                                  $"Game Duration: {game.GameDuration}");
            else
                Console.WriteLine($"Game Id: {game.Id}\n" +
                                  $"Game Mode: {game.Mode}\n" +
                                  $"Attempts: {game.Attempts}\n" +
                                  $"Result: you lost\n" +
                                  $"Game Started on: {game.StartDate.Date} at {game.StartDate.TimeOfDay}\n" +
                                  $"Game Ended on: {game.EndDate.Date} at {game.EndDate.TimeOfDay}\n" +
                                  $"Game Duration: {game.GameDuration}");
        }
    }

    public void ShowAllGamesWon()
    {
        foreach (var game in _games.Where(x => x.Result == true))
            Console.WriteLine($"Game Id: {game.Id}\n" +
                              $"Game Mode: {game.Mode}\n" +
                              $"Attempts: {game.Attempts}\n" +
                              $"Game Started on: {game.StartDate.Date} at {game.StartDate.TimeOfDay}\n" +
                              $"Game Ended on: {game.EndDate.Date} at {game.EndDate.TimeOfDay}\n" +
                              $"Game Duration: {game.GameDuration}");
    }

    public void ShowAllGamesLost()
    {
        foreach (var game in _games.Where(x => x.Result == false))
            Console.WriteLine($"Game Id: {game.Id}\n" +
                              $"Game Mode: {game.Mode}\n" +
                              $"Attempts: {game.Attempts}\n" +
                              $"Game Started on: {game.StartDate.Date} at {game.StartDate.TimeOfDay}\n" +
                              $"Game Ended on: {game.EndDate.Date} at {game.EndDate.TimeOfDay}\n" +
                              $"Game Duration: {game.GameDuration}");
    }
    public void ShowGameById(int id)
    {
        foreach (var game in _games.Where(x => x.Id == id))
        {
            if (game.Result)
                Console.WriteLine($"Game Id: {game.Id}\n" +
                                  $"Game Mode: {game.Mode}\n" +
                                  $"Attempts: {game.Attempts}\n" +
                                  $"Result: you won\n" +
                                  $"Game Started on: {game.StartDate.Date} at {game.StartDate.TimeOfDay}\n" +
                                  $"Game Ended on: {game.EndDate.Date} at {game.EndDate.TimeOfDay}\n" +
                                  $"Game Duration: {game.GameDuration}");
            else
                Console.WriteLine($"Game Id: {game.Id}\n" +
                                  $"Game Mode: {game.Mode}\n" +
                                  $"Attempts: {game.Attempts}\n" +
                                  $"Result: you lost\n" +
                                  $"Game Started on: {game.StartDate.Date} at {game.StartDate.TimeOfDay}\n" +
                                  $"Game Ended on: {game.EndDate.Date} at {game.EndDate.TimeOfDay}\n" +
                                  $"Game Duration: {game.GameDuration}");
        }
    }

    public void DeleteAll()
    {
        _games.Clear();
        _gamesRepo.DeleteGames(_games);
    }

    private static void ManageGameMode(Game game)
    {
        while (true)
        {
            Console.WriteLine("Insert a game mode (easy, medium, hard): ");
            string gameMode = Console.ReadLine()?.ToLower();
            switch (gameMode)
            {
                case "easy":
                    {
                        game.Lives = 10;
                        game.Mode = Game.GameMode.Easy;
                    }; break;
                case "medium":
                    {
                        game.Lives = 7;
                        game.Mode = Game.GameMode.Medium;

                    }; break;
                case "hard":
                    {
                        game.Lives = 5;
                        game.Mode = Game.GameMode.Hard;
                    }; break;
                default:
                    {
                        Console.WriteLine("Incorrect game mode inserted. Please enter 'easy', 'medium', or 'hard'.");
                        continue;
                    }
            }
            break;
        }
        Console.WriteLine($"Game mode set to {game.Mode}. You have {game.Lives} lives.");
    }
}
