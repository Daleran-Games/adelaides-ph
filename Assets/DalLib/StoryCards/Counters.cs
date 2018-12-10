using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DaleranGames.StoryCards
{
    [Serializable]
    public class Counters
    {

        private Dictionary<string, int> counters;
        private Dictionary<string, MinMaxFilter> filters;

        public Counters()
        {
            counters = new Dictionary<string, int>();
            filters = new Dictionary<string, MinMaxFilter>();
        }

        public Counters(IEnumerable<KeyValuePair<string, Counters.MinMaxFilter>> filters, IEnumerable<KeyValuePair<string, int>> initial)
        {
            counters = new Dictionary<string, int>();
            filters = new Dictionary<string, MinMaxFilter>();

            AddFilter(filters);
            Add(initial);
        }

        public int this[string id]
        {
            get
            {
                int result;
                if (counters.TryGetValue(id, out result))
                    return result;
                else
                    return 0;
            }
            set
            {
                counters[id] = TryFilter(id, value);
            }
        }

        public void Add(string id, int amount)
        {
            counters[id] = TryFilter(id, this[id] += amount);
        }

        public void Add(IEnumerable<KeyValuePair<string, int>> counters)
        {
            foreach (KeyValuePair<string, int> kvp in counters)
            {
                Add(kvp.Key, kvp.Value);
            }
        }

        public void AddFilter(string id, MinMaxFilter filter)
        {
            filters[id] = filter;
        }

        public void AddFilter(IEnumerable<KeyValuePair<string,MinMaxFilter>> filters)
        {
            foreach (KeyValuePair<string, MinMaxFilter> kvp in filters)
            {
                AddFilter(kvp.Key, kvp.Value);
            }
        }

        private int TryFilter(string id, int newValue)
        {
            MinMaxFilter filter;
            if (filters.TryGetValue(id, out filter))
                return filter.Apply(newValue);
            else
                return newValue;
        }

        public bool TestCard (Card card)
        {
            foreach (KeyValuePair<string,int> kvp in counters)
            {
                if (!card.TestConditions(kvp.Key, kvp.Value))
                    return false;
            }

            return true;
        }

        public class MinMaxFilter
        {
            int min;
            int max;

            public MinMaxFilter(int min, int max)
            {
                this.min = min;
                this.max = max;
            }

            public int Apply(int original)
            {
                if (original > max)
                    return max;
                else if (original < min)
                    return min;

                return original;
            }
        }
    }

}