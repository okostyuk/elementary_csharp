namespace csharp1.generics
{
    public class MyClass<T> where T : new()
    {
        public static T FactoryMethod()
        {
            return new T();
        }
    }
}