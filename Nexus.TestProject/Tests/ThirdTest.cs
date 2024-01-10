using Nexus.TestProject.Steps;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;


namespace Nexus.TestProject.Tests
{
    [AllureNUnit]
    [AllureSuite("Demo Tests")]
   // [TestFixture]
    public class FourthTest : BaseWebTest
    {
        private readonly LoginPageSteps loginPageSteps = new LoginPageSteps();
        private readonly HomePageSteps homePageSteps = new HomePageSteps();
        private readonly PimPageSteps pimPageSteps = new PimPageSteps();

        public void Login()
        {
            loginPageSteps.Login("Admin", "admin123");
        }

        [Retry(2)]
        [Test(Description = "Delete Specific Employment Status Employees under PIM menu")]
        public void DeleteEmployeeForSpecificStatus()
        {
            Login();
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.SelectSpecificEmployees("Full-Time Permanent");
        }

        [Retry(2)]
        [Test(Description = "Add new Employee uner PIM Menu")]
        public void AddNewEmployee()
        {
            Login();
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.AddNewEmployee("Jhon", "Walter", "White");
            pimPageSteps.NavigateToEmployeeListPage();
            pimPageSteps.VerifyEmployeeAdded("Jhon");
        }

        [Retry(2)]
        [Test(Description = "Delete Specific Employment Status Employees under PIM menu")]
        public void DeleteEmployeeForSpecificStatus_Copy1()
        {
            Login();
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.SelectSpecificEmployees("Full-Time Permanent");
        }

        [Retry(2)]
        [Test(Description = "Add new Employee uner PIM Menu")]
        public void AddNewEmployee_Copy1()
        {
            Login();
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.AddNewEmployee("Jhon", "Walter", "White");
            pimPageSteps.NavigateToEmployeeListPage();
            pimPageSteps.VerifyEmployeeAdded("Jhon");
        }

        [Retry(2)]
        [Test(Description = "Delete Specific Employment Status Employees under PIM menu")]
        public void DeleteEmployeeForSpecificStatus_Copy2()
        {
            Login();
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.SelectSpecificEmployees("Full-Time Permanent");
        }

        [Retry(2)]
        [Test(Description = "Add new Employee uner PIM Menu")]
        public void AddNewEmployee_Copy2()
        {
            Login();
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.AddNewEmployee("Jhon", "Walter", "White");
            pimPageSteps.NavigateToEmployeeListPage();
            pimPageSteps.VerifyEmployeeAdded("Jhon");
        }

        [Retry(2)]
        [Test(Description = "Delete Specific Employment Status Employees under PIM menu")]
        public void DeleteEmployeeForSpecificStatus_Copy3()
        {
            Login();
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.SelectSpecificEmployees("Full-Time Permanent");
        }

        [Retry(2)]
        [Test(Description = "Add new Employee uner PIM Menu")]
        public void AddNewEmployee_Copy3()
        {
            Login();
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.AddNewEmployee("Jhon", "Walter", "White");
            pimPageSteps.NavigateToEmployeeListPage();
            pimPageSteps.VerifyEmployeeAdded("Jhon");
        }

        [Retry(2)]
        [Test(Description = "Delete Specific Employment Status Employees under PIM menu")]
        public void DeleteEmployeeForSpecificStatus_Copy4()
        {
            Login();
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.SelectSpecificEmployees("Full-Time Permanent");
        }

        [Retry(2)]
        [Test(Description = "Add new Employee uner PIM Menu")]
        public void AddNewEmployee_Copy4()
        {
            Login();
            homePageSteps.NavigateToPIMPage();
            pimPageSteps.AddNewEmployee("Jhon", "Walter", "White");
            pimPageSteps.NavigateToEmployeeListPage();
            pimPageSteps.VerifyEmployeeAdded("Jhon");
        }
    }
}
