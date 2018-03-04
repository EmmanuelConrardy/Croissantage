using System;

namespace Croissantage
{
    public class CroissantageService
    {
        public CroissantageService() { }

        public void CroissanteCareLessEmployeOf(Team team)
        {
            Console.WriteLine("Croissantage ?");

            foreach (Employe employe in team.employes)
            {
                var croissantage = employe.CanBeCroissanted()
                    && team.OtherEmployeInThePlaceOriginOf(employe);

                if (croissantage)
                {
                    team.CroissantageNotification(employe);
                }
            }
        }

        public void ResetCroissantage(Team team)
        {
            foreach (var employe in team.employes)
            {
                employe.hasBeenAlreadyCroissanted = false;
            }
        }
    }
}
