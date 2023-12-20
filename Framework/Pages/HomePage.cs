using Nexus.Selenium.Elements.Interfaces;
using Nexus.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public class HomePage : Form
    {
        public HomePage()
    : base(By.ClassName("orangehrm-login-layout"), "Login Page")
        {
        }

        private IButton PIMButton => ElementFactory.GetButton(By.XPath("//*[@class='oxd-main-menu-item-wrapper']/a[contains(@href,'Pim')]"), "PIM Dashboard Button");

        public HomePage ClickPIMDashboardButton()
        {
            PIMButton.Click();
            return this;
        }
    }
}
