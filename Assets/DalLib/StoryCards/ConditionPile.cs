using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.StoryCards
{
    [System.Serializable]
    public class ConditionPile
    {
        List<Card> cards;

        public int Count { get { return cards.Count; } }

        public ConditionPile()
        {
            cards = new List<Card>();
        }

        public ConditionPile(IEnumerable<Card> cards)
        {
            cards = new List<Card>();
            Add(cards);
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

        public IList<Card> RemoveAllThatMeetConditions(Counters counters)
        {
            List<Card> results = new List<Card>();

            for (int i = cards.Count - 1; i >= 0; i--)
            {
                if (counters.TestCard(cards[i]))
                {
                    results.Add(cards[i]);
                    results.RemoveAt(i);
                }
            }

            return results;
        }

        public IList<Card> RemoveAll()
        {
            IList<Card> removedCards = cards;
            cards.Clear();
            return removedCards;
        }
    }
}