using PokerGameLibrary;
using PokerGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerGameWeb
{
    public partial class PokerGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GameStart_OnClick(object sender, EventArgs e)
        {
            // Get the number of the players in the poker session
            List<Player> gamePlayers = new List<Player>();
            Player computerPlayer = new Player(txtComputer1.Text);
            Player humanPlayer = new Player(txtPlayer.Text);
            gamePlayers.Add(computerPlayer);
            gamePlayers.Add(humanPlayer);

            // Initialize poker session and poker game classes
            PokerSession pokerSession = new PokerSession(gamePlayers);
            Session["PokerSession"] = pokerSession;
            StartGame();

            // Disable editing of player names
            txtComputer1.Enabled = txtPlayer.Enabled = false;

            // Hide start button and show game stats
            btnStartGame.Visible = false;

            // Show Evaluate button
            btnEvaluateHands.Visible = true;
        }

        protected void EvaluateHands_OnClick(object sender, EventArgs e)
        {
            PokerSession pokerSession = (PokerSession)Session["PokerSession"];
            List<Player> gameWinners;
            PokerSessionGame currentGame = pokerSession.gamesPlayed.Where(g => g.isActive).SingleOrDefault();
            string strgameWinners = string.Empty;

            try
            {
                gameWinners = PokerHandEvaluator.EvaluateHands(pokerSession.sessionPlayers);

                lblCompHand.Text = EnumHelper.GetDescription(pokerSession.sessionPlayers[0].hand.handCombination);
                lblPlayerHand.Text = EnumHelper.GetDescription(pokerSession.sessionPlayers[1].hand.handCombination);

                foreach (Player winner in gameWinners)
                {
                    strgameWinners = strgameWinners + winner.name + ", ";
                }
                strgameWinners = strgameWinners.Remove(strgameWinners.LastIndexOf(','));
                lblDisplayWinner.Text = "Game Winner/s: " + strgameWinners;

                currentGame.winningHand = EnumHelper.GetDescription(gameWinners.First().hand.handCombination);
                currentGame.gameWinner = strgameWinners;
                currentGame.isActive = false;

                btnEvaluateHands.Visible = false;
                btnNewGame.Visible = true;

                gvSessionStats.DataSource = pokerSession.gamesPlayed;
                gvSessionStats.DataBind();

                for (int i = 1; i <= 5; i++)
                {
                    Button btnComputerRedraw = (Button)ucComputerHand.FindControl("btnRedraw" + i);
                    Button btnPlayerRedraw = (Button)ucPlayerHand.FindControl("btnRedraw" + i);

                    btnComputerRedraw.Enabled = btnPlayerRedraw.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                // General exception catch
                lblDisplayError.Text = "Error occured: " + ex.Message;
            }
        }

        protected void NewGame_OnClick(object sender, EventArgs e)
        {
            // Hide start button and show game stats
            btnNewGame.Visible = false;

            // Show Evaluate button
            btnEvaluateHands.Visible = true;

            lblCompHand.Text = lblPlayerHand.Text = lblDisplayWinner.Text = string.Empty;

            StartGame();
        }

        private void StartGame()
        {
            try
            {
                PokerSession currentPokerSession = (PokerSession)Session["PokerSession"];

                PokerSessionGame newPokerGame = new PokerSessionGame();
                currentPokerSession.gamesPlayed.Add(newPokerGame);
                newPokerGame.gameNumber = currentPokerSession.gamesPlayed.Count;

                // Draw the initial 5 cards for each player
                foreach (Player player in currentPokerSession.sessionPlayers)
                {
                    player.hand = new PokerHand(newPokerGame);
                }

                // Display drawn hands
                ucComputerHand.hand = currentPokerSession.sessionPlayers[0].hand;
                ucPlayerHand.hand = currentPokerSession.sessionPlayers[1].hand;

                ucComputerHand.DisplayPokerHand();
                ucPlayerHand.DisplayPokerHand();

                // Assign current game to user control
                ucComputerHand.currentGame = ucPlayerHand.currentGame = newPokerGame;

                for (int i = 1; i <= 5; i++)
                {
                    Button btnComputerRedraw = (Button)ucComputerHand.FindControl("btnRedraw" + i);
                    Button btnPlayerRedraw = (Button)ucPlayerHand.FindControl("btnRedraw" + i);

                    btnComputerRedraw.Visible = btnPlayerRedraw.Visible = true;
                    btnComputerRedraw.Enabled = btnPlayerRedraw.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                // General exception catch
                lblDisplayError.Text = "Error occured: " + ex.Message;
            }
        }
    }
}