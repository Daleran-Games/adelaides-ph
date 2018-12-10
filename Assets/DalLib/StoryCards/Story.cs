using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.StoryCards
{
    [Serializable]
    public class Story
    {

        Counters gameState;

        ConditionPile inactive;
        TimedPile turnLockedPile;
        WeightedPile drawPile;

        Card hand;

        public Story(IEnumerable<KeyValuePair<string, Counters.MinMaxFilter>> filters, IEnumerable<KeyValuePair<string, int>> initalState, IEnumerable<Card> cards)
        {
            gameState = new Counters(filters,initalState);

            inactive = new ConditionPile(cards);
            turnLockedPile = new TimedPile();
            drawPile = new WeightedPile();

            drawPile.Add(inactive.RemoveAllThatMeetConditions(gameState));
        }

        public Card DrawCard()
        {
            hand = drawPile.Draw();
            return hand;
        }

        public Card.Choice SelectChoice(int choice)
        {
            if (hand != null)
            {
                if (choice >= 0 && choice < hand.Choices.Length)
                {
                    Card selected = hand;
                    AdvanceTurn();
                    return selected.Choices[choice];
                }
            }
            return Card.Choice.Null;
        }

        private void AdvanceTurn()
        {
            turnLockedPile.Add(hand);
            turnLockedPile.Decrement();
            inactive.Add(turnLockedPile.RemoveExpired());
            inactive.Add(drawPile.RemoveAll());
            drawPile.Add(inactive.RemoveAllThatMeetConditions(gameState));
            hand = null;
        }
    }
}


