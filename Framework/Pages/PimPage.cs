using Allure.Commons;
using Framework.Extensions;
using Nexus.Selenium.Elements.Interfaces;
using Nexus.Selenium.Forms;
using OpenQA.Selenium;
using System.Data.SqlTypes;
using System.Reflection.PortableExecutable;

namespace Framework.Pages
{
    public class PimPage : Form
    {
        public PimPage()
    : base(By.ClassName("orangehrm-login-layout"), "PIM Page")
        {
        }

        private IComboBox EmploymentStatusDropDown => ElementFactory.GetComboBox(By.XPath("//*[contains(text(),'Employment Status')]/following::div[@class='oxd-select-text--after']"), "Employment Status");
        private IButton EmploymentStatusOption(string status) => ElementFactory.GetButton(By.XPath($"//*[@role='listbox']/div/span[text()[contains(.,'{status}')]]"), "Employment Status");
        public IButton DeleteSelectedButton => ElementFactory.GetButton(By.XPath("//*[text()[contains(.,'Delete Selected')]]/i"), "Delete Selected");
        public IButton DeleteConfirmationButton => ElementFactory.GetButton(By.XPath("//*[text()[contains(.,'Yes, Delete')]]"), "Delete Confirmation");
        public IButton AddEmployeeButton => ElementFactory.GetButton(By.XPath("//button[text()[contains(.,'Add')]]"), "Add Employee Button");
        public ITextBox FirstNameTextBox => ElementFactory.GetTextBox(By.Name("firstName"), "First Name textbox");
        public ITextBox MiddleNameTextBox => ElementFactory.GetTextBox(By.Name("middleName"), "Middle Name textbox");
        public ITextBox LastNameTextBox => ElementFactory.GetTextBox(By.Name("lastName"), "Last Name textbox");
        public ITextBox EmployeeIDTextBox => ElementFactory.GetTextBox(By.XPath("//*[text()[contains(.,'Employee Id')]]/parent::div/following-sibling::div/input"), "Employee ID textbox");
        public IButton SaveEmployeeDetailsButton => ElementFactory.GetButton(By.XPath("//Button[text()[contains(.,'Save')]]"), "Save Employee Details Btn");
        public IButton EmployeeListButton => ElementFactory.GetButton(By.XPath("//*[text()[contains(.,'Employee List')]]"), "Employee List Button");
        public IButton SearchButton => ElementFactory.GetButton(By.XPath("//button[text()[contains(.,'Search')]]"), "Search Button");
        public ITextBox EmployeeNameTextbox => ElementFactory.GetTextBox(By.XPath("//*[text()[contains(.,'Employee Name')]]/parent::div/following-sibling::div/descendant::input"), "Employee Name textbox");

        public PimPage WaitForLoader()
        {
            IButton loader = ElementFactory.GetButton(By.XPath("//div[@class='oxd-loading-spinner-container']"), "Loader Table");
            loader.State.WaitForNotDisplayed();
            return this;
        }
        public PimPage SetEmploymentStatus(string status)
        {
            EmploymentStatusDropDown.ClickAndWait();
            EmploymentStatusOption(status).Click();
            return this;
        }

        public PimPage SelectEmployeeNotContainingStatus(string status, out int finalCount)
        {
            WaitForLoader();
            GetCountOfEmployeeNotContainingStatus(status, out int initialCount);

            if (initialCount > 0)
            {
                for(int i = 0; i < initialCount; i++)
                {
                    var element = ElementFactory.GetNotEmptyElementList<ICheckBox>(By.XPath($"//*[@class='oxd-table orangehrm-employee-list']/div[contains(@class,'body')]/descendant::div[contains(@class,'table-row')]/div[6][div[not(contains(.,'{status}'))]]/preceding-sibling::div/descendant::span[contains(@class,'checkbox-input')]"), "Checkboxes");
                    if (element.Count() > 0)
                    {
                        foreach (var ele in element)
                        {
                            ele.Click();
                        }
                    }
                }
            }
            GetCountOfEmployeeNotContainingStatus(status, out finalCount);
            return this;
        }

        public PimPage GetCountOfEmployeeNotContainingStatus(string status, out int count)
        {
            IButton loader = ElementFactory.GetButton(By.XPath("//div[@class='oxd-loading-spinner-container']"), "Loader Table");
            loader.State.WaitForNotDisplayed();
            var element = ElementFactory.FindElements<ICheckBox>(By.XPath($"//*[@class='oxd-table orangehrm-employee-list']/div[contains(@class,'body')]/descendant::div[contains(@class,'table-row')]/div[6][div[not(contains(.,'{status}'))]]/preceding-sibling::div/descendant::span[contains(@class,'checkbox-input')]"));
            count = element.Count();
            return this;
        }

        public PimPage ClickAddEmployee()
        {
            AddEmployeeButton.Click();
            WaitForLoader();
            return this;
        }

        public PimPage FillAndSaveEmployeeDetails(string firstname, string middlename, string lastname)
        {
            FirstNameTextBox.ClearAndType(firstname);
            LastNameTextBox.ClearAndType(lastname);
            MiddleNameTextBox.ClearAndType(middlename);
            SaveEmployeeDetailsButton.Click();
            WaitForLoader();
            return this;
        }

        public PimPage ClickEmployeeListButton()
        {
            EmployeeListButton.Click();
            WaitForLoader();
            return this;
        }

        public PimPage EnterEmployeeName(string name)
        {
            EmployeeNameTextbox.Type(name);
            return this;
        }

        public PimPage ClickSearchButton()
        {
            SearchButton.Click();
            WaitForLoader();
            return this;
        }

        public PimPage IsEmployeeCreatedPresent(string employeename,out bool isPresent)
        {
            var element = ElementFactory.GetNotEmptyElementList<IButton>(By.XPath($"//*[@class='oxd-table orangehrm-employee-list']/div[contains(@class,'body')]/descendant::div[contains(@class,'table-row')]/div[div[(contains(.,'{employeename}'))]]"), "Employee Id");
            if(element.Count > 0)
            {
                isPresent = true;
            }
            else
            {
                isPresent = false;
            }
            return this;
        }
    }
}
