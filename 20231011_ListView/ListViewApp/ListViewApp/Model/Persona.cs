using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewApp.Model
{
    internal class Persona
    {

        private static List<Persona> _personaList ;

        public static List<Persona> getPersones()
        {
            if(_personaList==null)
            {
                _personaList = new List<Persona>();
                Persona p0 = new Persona(1, "Joan Busquets", 32);
                Persona p1 = new Persona(2, "Maria Gutiérrez", 36);
                Persona p2 = new Persona(3, "Pepe Saez", 34);
                Persona p3 = new Persona(4, "Joao Figueira", 75);
                Persona p4 = new Persona(5, "Ester Minator", 64);
                Persona p5 = new Persona(6, "Pere Pau", 83);
                // Creació d'una llista de persones
                _personaList.Add(p0);
                _personaList.Add(p1);
                _personaList.Add(p2);
                _personaList.Add(p3);
                _personaList.Add(p4);
                _personaList.Add(p5);
            }
            return _personaList;
        }










        //**********************************************
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

        public override bool Equals(object obj)
        {
            return obj is Persona persona &&
                   Id == persona.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"ID:{Id}, Name:{Name}, Age:{Age}";
        }
    }
}
