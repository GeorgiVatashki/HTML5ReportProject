using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NLog;

namespace TelerikHTML5ReportViewerTests
{
    
    public class BaseTest
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

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
            driver.Close();
            driver.Quit();
            Logger.Info("Close current test");
        }
    }
}
