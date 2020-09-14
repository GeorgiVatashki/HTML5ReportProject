using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using AutomationResources;


namespace TelerikHTML5ReportViewerTests
{
    public class BaseTest
    {
        public IWebDriver driver;

        [TestInitialize]
        public void SetupBeforeEveryTest()
        {
            WebDriverFactory factory = new WebDriverFactory();
            driver = factory.Create(BrowserType.Chrome); 
        }

        [TestCleanup]
        public void CleanupAfterAfterEveryTest()
        {            
            //driver.Close();
            //driver.Quit();
        }
    }
}
