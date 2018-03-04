using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croissantage
{
    public class Employe : EmployeObserver
    {
        public readonly string Name;
        public readonly Place PlaceOrigin;

        public Session Session;
        public Place CurrentPlace;
        public bool hasBeenAlreadyCroissanted; 

        public Employe(string name)
        {
            Name = name;
            Session = new Session();
            CurrentPlace = Place.OpenSpace;
            PlaceOrigin = Place.OpenSpace;
        }

        public Employe(string name, Place place)
        {
            Name = name;
            Session = new Session();
            CurrentPlace = place;
            PlaceOrigin = place;
        }


        public void Croissanted(Employe employe)
        {
            if (employe.Name == Name)
            {
                Console.WriteLine($"{Name} has been croissanted");
                hasBeenAlreadyCroissanted = true;
            }
        }

        public void MoveTo(Place place)
        {
            if(place == CurrentPlace)
                Console.WriteLine($"{Name} stay in {place.ToString()}");
            else
                Console.WriteLine($"{Name} moved to {place.ToString()}");

            CurrentPlace = place;

        }

        //OpenCloseSession
    }
}
