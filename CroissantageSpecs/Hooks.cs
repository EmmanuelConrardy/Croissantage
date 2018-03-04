using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Croissantage.Specs
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private CroissantageService _croissantageService;

        [BeforeScenario]
        public void BeforeScenario()
        {
            //var smallRedTeam = ScenarioContext.Current.Get<Team>("smallRedTeam");
        }

        [AfterScenario]
        public void AfterScenario(CroissantageService CroissantageService)
        {
            var smallRedTeam = ScenarioContext.Current.Get<Team>("smallRedTeam");
            CroissantageService.ResetCroissantage(smallRedTeam);
        }
    }
}
