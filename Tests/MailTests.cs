using Lesson_10_Design_Patterns.PageObjects;
using Lesson_10_Design_Patterns.BusinesObject;
using NUnit.Framework;
using Lesson_10_Design_Patterns.Utils;

namespace Lesson_10_Design_Patterns.Tests
{
    public class MailTests : BaseTest
    {
        private HomePage homePage;
        private LoginPage loginPage;
        private MailPage mailPage;
        private readonly User user = new User("vadim.kuryan.vka", "Vka_6463296");
        private readonly Mail mail = new Mail("dragnir@tut.by", "TestSubject", "TestBody");

        [Test]
        public void SendDraftedMailTest()
        {
            homePage = new HomePage();
            homePage.GoToLogin();
            loginPage = new LoginPage();
            loginPage.LogInAsUser(user);
            loginPage.SignIn();
            mailPage = new MailPage();
            mailPage.WriteNewMail(mail);
            mailPage.SaveMailAsDraft();
            mailPage.GoToDraftFolder();
            Assert.IsTrue(mailPage.dratedMail.WebElementExist());
            mailPage.dratedMail.Click();
            Assert.IsTrue(mailPage.savedMail.WebElementExist());
            mailPage.sendMail.Click();
            mailPage.sendFolder.Click();
            Assert.IsTrue(mailPage.savedMail.WebElementExist());
        }

        [Test]
        public void WrongPasswordTest()
        {
            homePage = new HomePage();
            homePage.GoToLogin();
            loginPage = new LoginPage();
            loginPage.SetLogin(user.DataUser[0]);
            loginPage.SetPassword(PasswordGenerator.CreatePassword(15));
            loginPage.SignIn();
            Assert.IsTrue(loginPage.errorMesage.WebElementExist());
        }

        [Test]
        public void SendMailTest()
        {
            homePage = new HomePage();
            homePage.GoToLogin();
            loginPage = new LoginPage();
            loginPage.LogInAsUser(user);
            loginPage.SignIn();
            mailPage = new MailPage();
            mailPage.WriteNewMail(mail);
            mailPage.sendMail.ActionClick();
            mailPage.sendFolder.ActionClick();
            Assert.IsTrue(mailPage.savedMail.WebElementExist());
        }
    }
}
