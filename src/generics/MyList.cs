namespace csharp1.generics
{
    public class MyList<T>
    {
        private T[] items = new T[16];
        private int itemsCount = 0;
        public int ItemsCount => itemsCount;

        public void Add(T item)
        {
            items[itemsCount++] = item;
        }

        public T Get(int index)
        {
            return items[index];
        }
    }
}