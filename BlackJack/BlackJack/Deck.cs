using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {

        private String[] Suits = new  string[] { "Clubs", "Hearts", "Spades", "Diamonds" };
        private String[] Faces = new string[] { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        private ArrayList CardList = new ArrayList();
        public Deck()
        {
            GenerateDeck();
        }

        private void GenerateDeck()
        {
            CardList.Clear();
            foreach (String suit in Suits)
            {
               foreach(String face in Faces)
                {
                    CardList.Add(new Card(face,suit));
                }
            }
        }

        public void ShuffleDeck()
        {
            ArrayList  count = new ArrayList();
            ArrayList shuffleDeck = new ArrayList();
            Random random = new Random();
            int counter = 0;
            while(counter < CardList.Count)
            {
                int result = random.Next(0, CardList.Count);
                if (!count.Contains(result))
                {
                    count.Add(result);
                    shuffleDeck.Add(CardList[result]);
                    counter++;
                }
               
            }
            CardList = shuffleDeck;
        }

        public ArrayList getDeck()
        {
            return CardList;
        }
    }
}
