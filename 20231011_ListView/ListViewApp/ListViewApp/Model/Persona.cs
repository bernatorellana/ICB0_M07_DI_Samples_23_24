using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewApp.Model
{
    public class Persona : INotifyPropertyChanged
    {

        private static OC<Persona> _personaList ;

        public static OC<Persona> getPersones()
        {
            if(_personaList==null)
            {
                _personaList = new OC<Persona>();
                Persona p0 = new Persona(1, "Joan Busquets", 32);
                Persona p1 = new Persona(2, "Maria Gutiérrez", 36);
                Persona p2 = new Persona(3, "Pepe Saez", 34, p1);
                Persona p3 = new Persona(4, "Joao Figueira", 75, p2);
                Persona p4 = new Persona(5, "Ester Minator", 64);
                Persona p5 = new Persona(6, "Pere Pau", 83, p1);

                p0.Telefons.Add("656565656");
                p0.Telefons.Add("656565654");
                p0.Telefons.Add("656565653");
                p1.Telefons.Add("666565653");
                p2.Telefons.Add("666565656");
                p2.Telefons.Add("666565654");

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



        #region Propietats 

        private long id;
        private string name;
        private int age;
        private OC<String> telefons;
        private Persona cap;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public Persona(long id, string name, int age, Persona cap=null)
        {
            Id = id;
            Name = name;
            Age = age;
            this.cap = cap;
            telefons = new OC<string>();
         }

        public Persona Cap { get => cap; set => cap = value; }

        public OC<String> Telefons { get => telefons; }

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        /*
         // Versió de notificació manual dels canvis a les propietats
         // Ho automatitzarem usant el Nugget "Fody.INotifyPropertyChanged"

             public string Name { get => name; set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
         */
        public int Age { get => age; set => age = value; }

        public String UrlPhoto { get
            {
                return $"ms-appx:///Assets/f{Id}.png";
            }
        }

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
