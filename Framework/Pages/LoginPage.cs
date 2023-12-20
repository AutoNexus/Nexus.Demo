using Nexus.Selenium.Elements.Interfaces;
using Nexus.Selenium.Forms;
using OpenQA.Selenium;

namespace Framework.Pages
{
    public class LoginPage : Form
    {

        public LoginPage()
            : base(By.ClassName("orangehrm-login-layout"), "Login Page")
        {
        }

        private ITextBox UsernameTB => ElementFactory.GetTextBox(By.Name("username"), "Username Textbox");

        private ITextBox PassowrdTB => ElementFactory.GetTextBox(By.Name("password"), "Password Textbox");

        private IButton LoginBtn => ElementFactory.GetButton(By.XPath("//*[@type='submit']"), "Login Button");

        public LoginPage SetUsername(string username)
        {
            UsernameTB.ClearAndType(username);
            return this;
        }

        public LoginPage SetPassword(string password)
        {
            PassowrdTB.ClearAndType(password);
            return this;
        }

        public LoginPage ClickLoginBtn()
        {
            LoginBtn.Click();
            return this;
        }
    }
}
