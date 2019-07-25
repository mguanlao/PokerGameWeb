using NUnit.Framework;
using PokerGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameLibrary.UnitTests
{
    [TestFixture]
    public class PokerSessionTest
    {
        private PokerSession CreatePokerSession(List<Player> addedPlayers)
        {
            return new PokerSession(addedPlayers);
        }

        [Test]
        public void PokerSession_ValidateAddPlayers()
        {
            List<Player> minplayerList = CreatePlayerList(PokerSession.minPlayers);
            PokerSession minPlayerPokerSession = CreatePokerSession(minplayerList);

            Assert.AreEqual(PokerSession.minPlayers, minPlayerPokerSession.sessionPlayers.Count);
            Assert.AreNotEqual(PokerSession.maxPlayers, minPlayerPokerSession.sessionPlayers.Count);

            List<Player> maxPlayerlist = CreatePlayerList(PokerSession.maxPlayers);
            PokerSession maxPlayerPokerSession = CreatePokerSession(maxPlayerlist);
            Assert.AreEqual(PokerSession.maxPlayers, maxPlayerPokerSession.sessionPlayers.Count);
        }

        [Test]
        public void PokerSesession_Should_Throw_If_Exceeds_Max_Players()
        {
            List<Player> overMaxPlayerlist = CreatePlayerList(PokerSession.maxPlayers);
            Player extraPlayer = new Player("new player");
            overMaxPlayerlist.Add(extraPlayer);

            TestDelegate testDelegate = () => CreatePokerSession(overMaxPlayerlist);

            Assert.That(testDelegate, Throws.TypeOf<Exception>());
        }

        private List<Player> CreatePlayerList(int listCount)
        {
            List<Player> playerList = new List<Player>();

            for (int i = 0; i < listCount; i++)
            {
                Player newPlayer = new Player("new player" + i.ToString());
                playerList.Add(newPlayer);
            }

            return playerList;
        }
    }
}
