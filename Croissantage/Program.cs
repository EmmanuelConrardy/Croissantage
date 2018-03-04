using System;

namespace Croissantage
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamFactory factory = new TeamFactory();
            var croissantageService = new CroissantageService();

            var redTeam = factory.CreateTeam("rouge");

            do
            {
                EmployeMoveToOtherPlaces(redTeam);

                croissantageService.CroissanteCareLessEmployeOf(redTeam);

                croissantageService.ResetCroissantage(redTeam);

                Console.WriteLine("Again ?");
                Console.WriteLine("Any key to continue, q to quit");
                Console.WriteLine("------------------------------------------------------");

            } while (Console.Read() != 'q');
        }

       

        

        private static void EmployeMoveToOtherPlaces(Team rouge)
        {
            Console.WriteLine("Journey start people will move");

            var numberOfPlace = Enum.GetNames(typeof(Place)).Length;
            var rand = new Random();

            foreach (Employe employe in rouge.employes)
            {
                var place = (Place)rand.Next(numberOfPlace);
                employe.MoveTo(place);
            }
        }
    }
}
