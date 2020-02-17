namespace csharp1.generics
{
    public static class GetArrayExtension
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] result = new T[list.ItemsCount];
            for (int i=0; i<result.Length; i++)
            {
                result[i] = list.Get(i);
            }

            return result;
        }
    }
}