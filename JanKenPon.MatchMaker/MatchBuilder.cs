using System.Collections.Generic;
using System.Linq;
using JanKenPon.Common;

namespace JanKenPon.MatchMaker
{
    public class MatchBuilder
    {
        private bool hasWinner = false;
        private string outputString = string.Empty;

        public string Build(Dictionary<string, ISignal> players)
        {
            outputString = string.Empty;
            for (int i = 0; i < players.Count; i++)
            {
                if (i == players.Count - 1)
                {
                    rps_game_winner(players.ElementAt(i), players.ElementAt(0));
                    if (!hasWinner)
                        continue;

                    return outputString;
                }
                rps_game_winner(players.ElementAt(i), players.ElementAt(i + 1));

                if (hasWinner)
                    return outputString;
            }
            return "Draw!";
        }

        private void rps_game_winner(KeyValuePair<string, ISignal> p1, KeyValuePair<string, ISignal> p2)
        {
            if (p1.Value.Do.Any(p=> p2.Value.LosesTo.ToList().Contains(p)))
            {
                outputString = $"{p1.Value.Name} {p1.Value.Do.First()} {p2.Value.Name} - {p1.Key} Wins";
                hasWinner = true;
            }
        }
    }
}
