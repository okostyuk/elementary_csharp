namespace csharp1.generics
{
    public class CarCollection<T> : MyList<T> where T : Car, new()
    {
        public void addCar(string name, int year)
        {
            Add(new T {Name = name, Year = year});
        }

        public T getCar(int index)
        {
            return Get(index);
        }
        
    }
    
}