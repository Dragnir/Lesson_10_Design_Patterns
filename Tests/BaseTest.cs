using Lesson_10_Design_Patterns.WebDriver;
using NUnit.Framework;

namespace Lesson_10_Design_Patterns.Tests
{
    public class BaseTest
    {
        protected static Browser Browser;

        [SetUp]
        public virtual void InitTest()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [TearDown]
        public virtual void CleanTest()
        {
            Browser.Quit();
        }
    }
}
