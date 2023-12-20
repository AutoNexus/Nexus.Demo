using Framework.CustomAttributes;
using Framework.Pages;

namespace Nexus.TestProject.Steps
{
    public class PimPageSteps
    {
        private readonly PimPage pimPage = new PimPage();

        [LogStep(StepType.Step)]
        public void SetEmploymentStatus(string status)
        {
            pimPage.SetEmploymentStatus(status);
        }

        [LogStep(StepType.Assertion)]
        public void SelectSpecificEmployees(string status)
        {
            pimPage.SelectEmployeeNotContainingStatus(status, out var count);
            Assert.Zero(count, "Employee count should be zero");
        }

        [LogStep(StepType.Step)]
        public void AddNewEmployee(string firstname, string middlename, string lastname)
        {
            pimPage.ClickAddEmployee();
            pimPage.FillAndSaveEmployeeDetails(firstname, middlename, lastname);
        }

        [LogStep(StepType.Step)]
        public void NavigateToEmployeeListPage()
        {
            pimPage.ClickEmployeeListButton();
        }

        [LogStep(StepType.Assertion)]
        public void VerifyEmployeeAdded(string employeename)
        {
            pimPage.EnterEmployeeName(employeename);
            pimPage.ClickSearchButton();
            pimPage.IsEmployeeCreatedPresent(employeename, out var isEmployeeIdPresent);
            Assert.IsTrue(isEmployeeIdPresent, "Employee Name should be present");
        }
    }
}
