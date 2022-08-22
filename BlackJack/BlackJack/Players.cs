using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Players
    {
        private string Name { get; set; }
        private Boolean IsDealer { get; set; }
        private ArrayList Cards = new ArrayList();
        
        public Players(string name, Boolean isDealer = false)
        {
            this.Name = name;
            this.IsDealer = isDealer;
        }

      

        public ArrayList GetUserCards()
        {
            return Cards;
        }

        public void AddNewCard(Card card)
        {
            Cards.Add(card);
        }

        public void ResetUserDeck()
        {
            Cards.Clear();
        }

        public Boolean CheckIsDealer()
        {
            return IsDealer;
        }

        public int GetCurrentScore()
        {
            int sum = 0;
            foreach (Card playersCard in GetUserCards())
            {
                Boolean useAceSpecialValue = true;
                if (sum + 11 >= 21)
                {
                    useAceSpecialValue = false;
                }
                sum += playersCard.GetCardValue(useAceSpecialValue);
            }
            return sum;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
