using Framework.CustomAttributes;
using Framework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.TestProject.Steps
{
    public class HomePageSteps
    {
        private readonly HomePage homePage = new HomePage();

        [LogStep(StepType.Step)]
        public void NavigateToPIMPage()
        {
            homePage.ClickPIMDashboardButton();
        }
    }
}
