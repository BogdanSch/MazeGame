using MazeGame.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MazeGame.Models
{
    public class LeaderboardManager
    {
        public const string BEST_PLAYERS_SCORES_PATH = "BestPlayerScores.json";
        public const int MAX_PLAYERS_TO_DISPLAY = 12;
        public List<Player> BestPlayersScores { get; private set; } = [];

        public async Task<List<Player>> FetchBestPlayersScores()
        {
            if(!File.Exists(BEST_PLAYERS_SCORES_PATH))
                return BestPlayersScores;

            using StreamReader reader = new(BEST_PLAYERS_SCORES_PATH);
            string json = await reader.ReadToEndAsync();
            BestPlayersScores = JsonSerializer.Deserialize<List<Player>>(json) ?? [];

            return BestPlayersScores;
        }
        public void SaveBestPlayersScores()
        {
            using StreamWriter writer = new(BEST_PLAYERS_SCORES_PATH, false);
            string json = JsonSerializer.Serialize(BestPlayersScores);
            writer.WriteLineAsync(json);
        }
        public void AddNewPlayerScore(Player player)
        {
            Player? existing = BestPlayersScores.FirstOrDefault(p => p.Name == player.Name);

            if (existing == null)
            {
                BestPlayersScores.Add(player);
            }
            else
            {
                if(player.Score > existing.Score)
                {
                    existing.Score = player.Score;
                }
            }
            BestPlayersScores = [..BestPlayersScores.OrderByDescending(p => p.Score).Take(MAX_PLAYERS_TO_DISPLAY)];
        }
    }
}
