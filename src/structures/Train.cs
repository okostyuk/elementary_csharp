using System;

namespace csharp1.structures
{
    public struct Train
    {
        internal int number;
        private String destinaton;
        private DateTime departureTime;

        public Train(int number, string destinaton, DateTime departureTime)
        {
            this.number = number;
            this.destinaton = destinaton;
            this.departureTime = departureTime;
        }

        public override string ToString()
        {
            return number + "\t" + destinaton + "\t" + departureTime;
        }
    }
    
}