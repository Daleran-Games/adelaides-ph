using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.StoryCards
{
    [System.Serializable]
    public class WeightedPile
    {
        WeightedList<Card> cards;

        public int Count { get { return cards.Count; } }
        

        public WeightedPile()
        {
            cards = new WeightedList<Card>();
        }

        public Card Draw()
        {
            Card result = cards.GetRandom();
            cards.Remove(result);
            return result;
        }

        public void Add(Card card)
        {
            cards.Add(card);
        }

        public void Add(IEnumerable<Card> cards)
        {
            foreach (Card c in cards)
            {
                Add(c);
            }
        }

        public IList<Card> RemoveAll()
        {
            IList<Card> removedCards = cards;
            cards.Clear();
            return removedCards;
        }

    }
}

