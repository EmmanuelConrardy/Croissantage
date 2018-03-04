
namespace Croissantage
{
    public static class EmployeExtension
    {
        public static bool CanBeCroissanted(this Employe employe)
        {
            return employe.CurrentPlace != employe.PlaceOrigin 
                && employe.Session.isOpen()
                && employe.hasBeenAlreadyCroissanted == false;
        }
    }
}
