using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /*
     * Please note that the program  has three class (Players class , Card class and the deck class and the main class)
     * Only input is to continue to draw more cards 
     * 
     * **/
    internal class Program
    {
        //Names of players
        private static readonly string[] playerNames = new string[] { "Billy","Andrew","Lemmy","Carla", "Dealer" };
        //Dealers final score
        private static int dealerScore = 0;
        //Check if dealer defeated every player.
        private static Boolean dealerWins = true;
        
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the BlackJack21 game");
            
            Players[] players = GeneratePlayers();
            // Create new deck and shuffle cards
            Deck deck = new Deck();
            deck.ShuffleDeck();
            ArrayList finalDeck = deck.getDeck();

            // Provide two cards to each player
            InitializeUserHand(players, finalDeck);
          
            //step 2 player draws
            foreach (Players player in players)
            {
                DrawCard(player, finalDeck);
            }

            DisplayResult(players);
            Console.ReadKey();
        }

        private static void DisplayResult(Players[] players)
        {
            //step results
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------Results------------------------------------------------------");
            foreach (Players player in players)
            {
                string result;
                Console.WriteLine();
                Console.WriteLine("---------------------{0} \'{1}\' has the following cards-------------------------------",player.CheckIsDealer() ? "Dealer" : "Player", player.GetName());
                foreach (Card playersCard in player.GetUserCards())
                {
                    playersCard.DisplayCardName();
                }
                Console.WriteLine("{0} \'{1}\' score = {2}", player.CheckIsDealer() ? "Dealer" : "Player",player.GetName(), player.GetCurrentScore());
                if (!player.CheckIsDealer())
                {
                    int count = player.GetUserCards().Count;
                    if ((player.GetCurrentScore() == 21) || (player.GetUserCards().Count >= 5 && player.GetCurrentScore() < 21) || (player.GetCurrentScore() < 21 && player.GetCurrentScore() >= dealerScore))
                    {
                        result = string.Format("Player \'{0}\' beats dealer", player.GetName());
                        dealerWins = false;
                    }
                    else
                    {
                        result = string.Format("Player \'{0}\' loses", player.GetName());
                    }
                }
                else
                {
                    if (dealerWins)
                    {
                        result = string.Format("{0}  Wins",player.GetName());
                    }
                    else
                    {
                        result = string.Format("{0}  Loses",player.GetName());
                    }
                }
                Console.WriteLine(result);
                player.ResetUserDeck();
            }
        }

        private static void DrawCard(Players player, ArrayList finalDeck)
        {
            int drawCard = 0;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("------------------------{0}'s Cards----------------------",player.GetName());
                foreach (Card playersCard in player.GetUserCards())
                {
                    playersCard.DisplayCardName();
                }
                Console.WriteLine("Current hand score => {0}",player.GetCurrentScore());
                Console.WriteLine("------------------------{0} End of  List----------------------", player.GetName());
                Console.WriteLine();
                if (CheckScore(player))
                {
                    break;
                }
                if (!player.CheckIsDealer())
                {
                    Console.Write("enter 1 to draw and 0 to stop: ");
                    drawCard = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                if(drawCard == 1 || player.CheckIsDealer())
                {
                    Card card = (Card)finalDeck[0];
                    player.AddNewCard(card);
                    finalDeck.RemoveAt(0);
                    Console.WriteLine("Drew a ......");
                    card.DisplayCardName();
                }
                else
                {
                    break;
                }
                if (CheckScore(player))
                {
                    break;
                }

            }
        }

        private static Boolean CheckScore(Players player)
        {
            if (player.CheckIsDealer())
            {
                dealerScore = player.GetCurrentScore();
            }
            if (player.GetCurrentScore() == 21)
            {
                Console.WriteLine("Player \'{0}\' gets a value of 21 . It's a Black Jack!!!", player.GetName());
                return true;
            }

            if (player.GetCurrentScore() > 21)
            {
                Console.WriteLine("Player \'{0}\' went over 21 . It's a burst!!!", player.GetName());
                return true;
            }

            if (player.CheckIsDealer() && player.GetCurrentScore() >= 18)
            {
                return true;
            }
            return false;
        }

        private static void InitializeUserHand(Players[] players, ArrayList finalDeck)
        {
            //step 1 give every  player  two  cards
            for (int j = 0; j < 2; j++)
            {

                foreach (Players player in players)
                {
                    Card card = (Card)finalDeck[0];
                    player.AddNewCard(card);
                    if (player.CheckIsDealer() && j == 1)
                    {
                        Console.Write("Dealer's second card is:..");
                        card.DisplayCardName();
                        Console.WriteLine();
                    }
                    finalDeck.RemoveAt(0);
                }

            }
        }

        private static Players[] GeneratePlayers()
        {
            int numberOfPlayers = playerNames.Length;
            Players[] players = new Players[numberOfPlayers];
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Boolean isDealer = i == numberOfPlayers - 1;
                players[i] = new Players(playerNames[i], isDealer);
            }
            return players;
        }
    }
}
