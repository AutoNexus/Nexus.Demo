using Nexus.TestProject.Steps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;


namespace Nexus.TestProject.Tests
{
    [AllureNUnit]
    [AllureSuite("Demo Tests")]
    [TestFixture]
    public class SecondTest : BaseWebTest
    {
        private readonly LoginPageSteps loginPageSteps = new LoginPageSteps();
        private readonly HomePageSteps homePageSteps = new HomePageSteps();
        private readonly PimPageSteps pimPageSteps = new PimPageSteps();

        [SetUp]
        public void Setup()
        {
            GoToPageStartPage();
            SetScreenExpansionMaximize();
            loginPageSteps.Login("Admin", "admin123");
        }

        [Test(Description = "Delete Specific Employment Status Employees under PIM menu")]
        public void DeleteEmployeeForSpecificStatus()
        {
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.SelectSpecificEmployees("Full-Time Permanent");
        }

        [Test(Description = "Delete Specific Employment Status Employees under PIM menu")]
        public void DeleteEmployeeForSpecificStatus1()
        {
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.SelectSpecificEmployees("Full-Time Permanent");
        }

        [Test(Description = "Delete Specific Employment Status Employees under PIM menu")]
        public void DeleteEmployeeForSpecificStatus2()
        {
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.SelectSpecificEmployees("Full-Time Permanent");
        }

        [Test(Description = "Delete Specific Employment Status Employees under PIM menu")]
        public void DeleteEmployeeForSpecificStatus3()
        {
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.SelectSpecificEmployees("Full-Time Permanent");
        }

        [Test(Description = "Add new Employee uner PIM Menu")]
        public void AddNewEmployee()
        {
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.AddNewEmployee("Jhon", "Walter", "White");
            pimPageSteps.NavigateToEmployeeListPage();
            pimPageSteps.VerifyEmployeeAdded("Jhon");
        }
    }
}
