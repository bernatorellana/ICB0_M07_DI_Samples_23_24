using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCollections.Model
{
    internal class Persona
    {
        private long id;
        private string name;
        private int age;

        public Persona(long id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public override string ToString()
        {
            return $"ID:{Id}, Name:{Name}, Age:{Age}";
        }
    }
}
