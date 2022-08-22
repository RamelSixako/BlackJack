using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Card
    {
        private string Face { get; set; }
        private string Suit { get; set; }
        public Card(string face,string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public void DisplayCardName()
        {
            Console.WriteLine("{0} of {1}", Face, Suit);
        }

        public int GetCardValue( Boolean useAceSpecialValue = false)
        {
            switch(Face) 
            {
                case "Ace":
                    return useAceSpecialValue ? 11 : 1;
                case "Two":
                    return 2;
                case "Three":
                    return 3;
                case "Four":
                    return 4;
                case "Five":
                    return 5;
                case "Six":
                    return 6;
                case "Seven":
                    return 7;
                case "Eight":
                    return 8;
                case "Nine":
                    return 9;
                default:
                    return 10;
            }
        }


    }
}
