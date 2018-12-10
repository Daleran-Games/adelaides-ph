using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.StoryCards
{
    [System.Serializable]
    public class TimedPile 
    {
        List<CardTimer> timedCards;

        public int Count { get { return timedCards.Count; } }

        public TimedPile()
        {
            timedCards = new List<CardTimer>();
        }

        public void Add (Card card)
        {
            timedCards.Add(new CardTimer(card,card.TurnLock));
        }

        public void Decrement()
        {
            for (int i = 0; i < timedCards.Count; i++)
            {
                timedCards[i].Decrement();
            }
        }

        public IList<Card> RemoveExpired()
        {
            List<Card> results = new List<Card>();

            for (int i = timedCards.Count-1; i >= 0 ; i--)
            {
                if (timedCards[i].Time < 1)
                {
                    results.Add(timedCards[i].Card);
                    timedCards.RemoveAt(i);
                }
            }

            return results;
        }

        public IList<Card> RemoveAll()
        {
            List<Card> results = new List<Card>();

            for (int i = 0; i < timedCards.Count; i++)
            {
                results.Add(timedCards[i].Card);
            }
            timedCards.Clear();

            return results;
        }

        public class CardTimer
        {
            public Card Card { get; }
            public int Time { get; private set; }

            public CardTimer(Card card, int time)
            {
                Card = card;
                Time = time;
            }

            public void Decrement()
            {
                Time--;
            }
        }

    }
}