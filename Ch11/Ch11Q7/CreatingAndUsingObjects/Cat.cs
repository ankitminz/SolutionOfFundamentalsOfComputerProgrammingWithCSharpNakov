using System;

namespace Ch11Q7.CreatingAndUsingObjects
{
    public class Cat
    {
        private string name;
        private string color;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        public Cat()
        {
            this.name = "Unnamed";
            this.color = "Unknown";
        }

        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        public void SayMiau()
        {
            Console.WriteLine($"Cat {name} said Miauuuuuuuu...");
        }
    }
}
