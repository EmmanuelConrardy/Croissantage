using System;

namespace Croissantage
{
    public class RedTeam : Team
    {
        public RedTeam() : base("rouge") {
            Console.WriteLine("Create Team Rouge");

            employes.Add(new Employe("Bruno"));
            employes.Add(new Employe("Alexie"));
            employes.Add(new Employe("Amel"));
            employes.Add(new Employe("Aziz"));
            employes.Add(new Employe("Emmanuel"));
            employes.Add(new Employe("Daisy"));
            employes.Add(new Employe("Cecile"));
            employes.Add(new Employe("Stephanie"));
            employes.Add(new Employe("Baptiste", Place.SecondFloor));            
        }
    }
}
