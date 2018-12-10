using System.Collections;
using System.Collections.Generic;
using System;


namespace DaleranGames
{
    [Serializable]
    public class WeightedList<T> : IList<T> where T : IWeightedItem
    {
        private List<T> list;
        private static System.Random rand = new System.Random();

        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public int Count { get { return list.Count; } }
        public bool IsReadOnly { get { return false; } }

        public WeightedList()
        {
            list = new List<T>();
        }

        public WeightedList(int capacity)
        {
            list = new List<T>(capacity);
        }

        private int CalculateTotalWeight()
        {
            int total = 0;
            for (int i=0; i<list.Count;i++)
            {
                total += list[i].Weight;
            }
            return total;
        }

        public T GetRandom()
        {
            int totalWeight = CalculateTotalWeight();
            int randomInt = rand.Next(0, totalWeight);

            T selected = default(T);
            for (int i=0;i<list.Count;i++)
            {
                if (randomInt < list[i].Weight)
                {
                    selected = list[i];
                    break;
                }
                randomInt = randomInt - list[i].Weight;
            }
            return selected;
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
