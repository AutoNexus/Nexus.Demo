using Framework.CustomAttributes;
using Framework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexus.TestProject.Steps
{
    public class LoginPageSteps
    {
        private readonly LoginPage loginPage = new LoginPage();

        [LogStep(StepType.Step)]
        public void EnterUsername(string username)
        {
            loginPage.SetUsername(username);
        }

        [LogStep(StepType.Step)]
        public void EnterPassword(string password)
        {
            loginPage.SetPassword(password);
        }

        [LogStep(StepType.Step)]
        public void LoginBtnClick()
        {
            loginPage.ClickLoginBtn();
        }

        [LogStep(StepType.Step)]
        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            LoginBtnClick();
        }
    }
}
