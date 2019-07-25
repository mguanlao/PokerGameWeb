using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary
{
    /// <summary>
    /// Represents a poker session / table or a set of games
    /// </summary>
    public class PokerSession
    {
        public const int maxPlayers = 4;
        public const int minPlayers = 2;

        public List<PokerSessionGame> gamesPlayed { get; set; }
        public List<Player> sessionPlayers { get; set; }

        public PokerSession(List<Player> addedPlayers)
        {
            if (addedPlayers.Count > maxPlayers || addedPlayers.Count < minPlayers)
            {
                throw new Exception("Invalid player count.");
            }

            sessionPlayers = addedPlayers;
            gamesPlayed = new List<PokerSessionGame>();
        }
    }
}
