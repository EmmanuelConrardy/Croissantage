using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Croissantage.Specs.Bindings
{
    [Binding]
    public class EmployeSteps
    {
        private CroissantageService croissantageService;

        public EmployeSteps(CroissantageService customerController)
        {
            this.croissantageService = customerController;
        }

        [Given(@"An Employe (.*) at the (.*)")]
        public void GivenAnEmployeAtThe(string name, string placeName)
        {
            Employe employe = GetEmployeFromSmallRedTeam(name);

            var place = PlaceConverter.Convert(placeName);
            employe.MoveTo(place);

            Assert.AreEqual(place, employe.CurrentPlace);
        }

        private static Employe GetEmployeFromSmallRedTeam(string name)
        {
            var smallRedTeam = ScenarioContext.Current.Get<Team>("smallRedTeam");
            var employe = smallRedTeam.employes.Find(e => e.Name == name);

            if (employe == null)
                throw new ArgumentException($"{name} is missing in the Team.");

            return employe;
        }

        [Given(@"Session of (.*) is Open")]
        public void GivenSessionOfIs(string name)
        {
            Employe employe = GetEmployeFromSmallRedTeam(name);

            Assert.IsTrue(employe.Session.isOpen());
        }

        [When(@"Employes try to croissant each others")]
        public void WhenEmployesTryToCroissantEachOthers()
        {
            var smallRedTeam = ScenarioContext.Current.Get<Team>("smallRedTeam");
            croissantageService.CroissanteCareLessEmployeOf(smallRedTeam);
        }

        [Then(@"(.*) should be croissanted")]
        public void ThenShouldBeCroissanted(string name)
        {
            Employe employe = GetEmployeFromSmallRedTeam(name);
            Assert.IsTrue(employe.hasBeenAlreadyCroissanted);
        }

        [Then(@"(.*) should not be croissanted")]
        public void ThenShouldNotBeCroissanted(string name)
        {
            Employe employe = GetEmployeFromSmallRedTeam(name);
            Assert.IsFalse(employe.hasBeenAlreadyCroissanted);
        }


        [Given(@"Small red team")]
        public void GivenSmallRedTeam(Table table)
        {
            CreateCustomRedTeam(table, "smallRedTeam");
        }

        private void CreateCustomRedTeam(Table table, string key)
        {
            var factory = new TeamFactory();
            var redTeam = factory.CreateTeam("rouge");
            redTeam.RemoveAll();
            var nbEmploye = table.Rows.Count;
            var employes = table.Rows;
            for (int i = 0; i < nbEmploye; i++)
            {
                var name = employes[i][0];

                if (redTeam.employes.Exists(e => e.Name == name))
                    throw new ArgumentException($"{name} already exist.");

                var currentPlace = employes[i][1];
                Place place;

                if (Enum.TryParse(currentPlace, out place))
                    redTeam.employes.Add(new Employe(name, place));
                else
                    throw new ArgumentException($"{currentPlace} doesn't exist");
            }

            ScenarioContext.Current.Set(redTeam, key);
        }
    }
}
