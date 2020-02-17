using System.Collections.Generic;

namespace csharp1.generics
{
    public class MyDictionary<TKey,TValue>
    {
        public int PairsCount => count;
        
        private TKey[] keys = new TKey[16];
        private TValue[] values = new TValue[16];
        private int count = 0;
        
        public void Add(TKey key, TValue value)
        {
            keys[count] = key;
            values[count] = value;
            count++;
        }

        public TKey getKey(int index)
        {
            return keys[index];
        }

        public TValue getValue(int index)
        {
            return values[index];
        }
    }
}