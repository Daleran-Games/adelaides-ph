using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.StoryCards
{
    [Serializable]
    public class Card : IWeightedItem
    {
        public string ID { get; }
        public string Story { get; }

        public int Weight { get; }
        public int TurnLock { get; }

        public Condition[] Conditions { get; }
        public Choice[] Choices { get; }

        public Card(string id, string story, Condition[] conditions,int weight,int turnLock, Choice[] choices)
        {
            ID = id;
            Story = story;
            Conditions = conditions;
            Weight = weight;
            TurnLock = turnLock;
            Choices = choices;
        }

        public bool TestConditions(string counter, int number)
        {
            for (int i=0; i < Conditions.Length; i++)
            {
                if (!Conditions[i].Test(counter, number))
                    return false;
            }
            return true;
        }

        public struct Condition
        {
            public enum Operator
            {
                Equal = 0,
                NotEqual = 1,
                LessThan = 2,
                LessThanOrEqual = 3,
                GreaterThanOrEqual = 4,
                GreaterThan = 5
            }

            public string Counter { get; }
            public Operator Relation { get; }
            public int Number { get; }

            public Condition(string counter, Operator relation, int number)
            {
                Counter = counter;
                Relation = relation;
                Number = number;
            }

            public bool Test(string counter, int number)
            {
                if (counter == Counter)
                {
                    return Test(number);
                }
                else
                    return false;
            }

            public bool Test(int number)
            {
                switch (Relation)
                {
                    case Operator.Equal:
                        return (number == Number);
                    case Operator.NotEqual:
                        return (number != Number);
                    case Operator.LessThan:
                        return (number < Number);
                    case Operator.LessThanOrEqual:
                        return (number <= Number);
                    case Operator.GreaterThan:
                        return (number > Number);
                    case Operator.GreaterThanOrEqual:
                        return (number >= Number);
                    default:
                        return false;
                }
            }
        }
        
        public class Choice
        {
            public string ChoiceText { get; }
            public string ConsequenceText { get; }
            public Tuple<string, int>[] Consequences { get; }

            public static Choice Null = new Choice("NULL CHOICE", "NULL CONSEQUENCE", new Tuple<string, int>[0]);

            public Choice(string text, string consequenceText, Tuple<string, int>[] consequences)
            {
                ChoiceText = text;
                ConsequenceText = consequenceText;
                Consequences = consequences;
            }
        }
    } 
}
