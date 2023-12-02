using System;

namespace OnlineStore
{
    public class Good
    {
        public string Name { get; private set; }

        public Good(string name)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException(name);
            
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}