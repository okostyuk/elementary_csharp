using System;
using System.Collections;

namespace csharp1.generics
{
    public class ArrayList : IList
    {
        public IEnumerator GetEnumerator()
        {
            var target = new object[_count];
            CopyTo(target, 0);
            return new MyEnumerator(target);
        }

        public void CopyTo(Array array, int index)
        {
            Array.Copy(_items, index, array, 0, _count);
        }

        private object[] _items = new object[16];
        private int _count = 0;

        public int Add(object? value)
        {
            if (_count == _items.Length - 1)
            {
                var newItems = new object[_items.Length * 2];
                Array.Copy(_items, 0, newItems, 0, _count);
                _items = newItems;
            }

            Insert(_count, value);
            return _count - 1;
        }

        public void Clear()
        {
            Array.Clear(_items, 0, _count);
            _count = 0;
        }

        public bool Contains(object? value)
        {
            return IndexOf(value) >= 0;
        }

        public int IndexOf(object? value)
        {
            for(var i=0; i<_count; i++)
            {
                var item = _items[i];
                if (item != null && item.Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, object? value)
        {
            _items[index] = value;
            _count++;
        }

        public void Remove(object? value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            Array.Copy(_items, index, _items, index-1, _count-index);
            _count--;
        }


        public object? this[int index]
        {
            get => _items[index];
            set => throw new NotImplementedException();
        }
        
        public int Count { get => _count; }
        public bool IsFixedSize => false;
        public bool IsReadOnly => false;
        public bool IsSynchronized => false;
        public object SyncRoot => this;

        class MyEnumerator : IEnumerator
        {
            private int pos = 0;
            private object[] _items;

            public MyEnumerator(object[] items)
            {
                _items = items;
            }

            public bool MoveNext()
            {
                if (pos < (_items.Length - 1))
                {
                    pos++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                pos = 0;
            }

            public object? Current => _items[pos];
        }
    }
}