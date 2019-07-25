using PokerGameLibrary;
using PokerGameLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PokerGameWeb
{
    public partial class PlayerHand : System.Web.UI.UserControl
    {
        public PokerHand hand { get; set; }
        public PokerSessionGame currentGame { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DisplayPokerHand()
        {
            int index = 1;

            foreach (Card card in hand.cardHands)
            {
                Label topNumber = (Label)this.FindControl("topNumber" + index.ToString());
                Label botNumber = (Label)this.FindControl("botNumber" + index.ToString());
                Label topSuit = (Label)this.FindControl("topSuit" + index.ToString());
                Label midSuit = (Label)this.FindControl("midSuit" + index.ToString());
                Label botSuit = (Label)this.FindControl("botSuit" + index.ToString());
                HtmlControl divCard = (HtmlControl)this.FindControl("divCard" + index.ToString());

                topNumber.Text = botNumber.Text = EnumHelper.GetDescription(card.cardNumber);

                switch (card.suit)
                {
                    case Suit.Club:
                        topSuit.Text = midSuit.Text = botSuit.Text = "&clubs;";
                        divCard.Style.Add("color", "black");
                        break;
                    case Suit.Diamond:
                        topSuit.Text = midSuit.Text = botSuit.Text = "&diams;";
                        divCard.Style.Add("color", "red");
                        break;
                    case Suit.Heart:
                        topSuit.Text = midSuit.Text = botSuit.Text = "&hearts;";
                        divCard.Style.Add("color", "red");
                        break;
                    case Suit.Spade:
                        topSuit.Text = midSuit.Text = botSuit.Text = "&spades;";
                        divCard.Style.Add("color", "black");
                        break;
                }
                index++;
            }
        }

        protected void btnRedraw_Click(object sender, EventArgs e)
        {
            // Get the order number of the card to redraw
            Button senderButton = (Button)sender;
            string buttonID = senderButton.ID;
            int sortOrder = Convert.ToInt32(buttonID.Substring(buttonID.Length - 1, 1));

            PokerSession pokerSession = (PokerSession)Session["PokerSession"];
            PokerSessionGame currentGame = pokerSession.gamesPlayed.Where(g => g.isActive).FirstOrDefault();

            Card drawnCard = currentGame.gameCardDeck.GetCardsFromDeck(1)[0];

            // Redraw from computer hand
            if (senderButton.Parent.ID.ToLower().Contains("computer"))
            {
                pokerSession.sessionPlayers[0].hand.cardHands[sortOrder - 1] = drawnCard;
                this.hand = pokerSession.sessionPlayers[0].hand;
            }
            else if (senderButton.Parent.ID.ToLower().Contains("player"))
            {
                pokerSession.sessionPlayers[1].hand.cardHands[sortOrder - 1] = drawnCard;
                this.hand = pokerSession.sessionPlayers[1].hand;
            }

            senderButton.Visible = false;
            this.hand.redrawCount++;

            if (this.hand.redrawCount == 3)
            {
                for (int i = 1; i <= 5; i++)
                {
                    this.FindControl("btnRedraw" + i).Visible = false;
                }
            }

            DisplayPokerHand();
        }
    }
}