using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Croissantage
{
    public abstract class Team
    {
        public readonly string Name;
        public List<Employe> employes = new List<Employe>();

        public Team(string name)
        {
            Name = name;
        }

        public void Add(Employe employe)
        {
            employes.Add(employe);
        }

        public void Remove(Employe employe)
        {
            employes.Remove(employe);
        }

        public void RemoveAll()
        {
            employes.RemoveAll(e => true);
        }

        public void CroissantageNotification(Employe employe)
        {
            foreach(var e in employes)
            {
                e.Croissanted(employe);
            }
        }

        public bool OtherEmployeInThePlaceOriginOf(Employe employe)
        {
            return employes.Any(e => e.Name != employe.Name && e.CurrentPlace == employe.PlaceOrigin);
        }
    }
}
