using Lesson_10_Design_Patterns.BusinesObject;
using OpenQA.Selenium;

namespace Lesson_10_Design_Patterns.PageObjects
{
    public class LoginPage : BasePage
    {
        private static readonly By LoginLnl = By.ClassName("passp-add-account-page-title");

        public LoginPage() : base(LoginLnl, "Log in with Yandex ID to access Yandex.Mail") {}

        private readonly BaseElement loginField = new BaseElement(By.CssSelector("[name = 'login']"));
        private readonly BaseElement setPassword = new BaseElement(By.CssSelector("[id = 'passp:sign-in']"));
        private readonly BaseElement signIn = new BaseElement(By.CssSelector("[id = 'passp:sign-in']"));
        public BaseElement passwordField = new BaseElement(By.XPath("//*[@id='passp-field-passwd']"));
        public BaseElement errorMesage = new BaseElement(By.XPath("//*[text()='Incorrect password']"));

        public void SetLogin(string loginName)
        {
            loginField.JsHighlightElement();
            loginField.SendKeys(loginName);
        }

        public void SetPassword(string password)
        {
            setPassword.Click();
            passwordField.WaitForIsVisible();
            passwordField.SendKeys(password);
        }

        public void LogInAsUser(User user)
        {
            SetLogin(user.DataUser[0]);
            setPassword.Click();
            passwordField.WaitForIsVisible();
            passwordField.SendKeys(user.DataUser[1]);
        }

        public void SignIn()
        {
            signIn.JsHighlightElement();
            signIn.Click();
        }
    }
}
