using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using AutomationResources;
using NLog;
using System;

namespace TelerikHTML5ReportViewerTests
{

    [TestCategory("CreatingReports")]
    [TestClass]
    public class BaseTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();        
        public TestContext TestContext { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }

        protected IWebDriver driver;

        [TestInitialize]
        public void SetupBeforeEverySingleTest()
        {            
            Logger.Debug("The Test Started");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            WebDriverFactory factory = new WebDriverFactory();
            driver = factory.Create(BrowserType.Chrome);
            ScreenshotTaker = new ScreenshotTaker(driver, TestContext);
        }

        [TestCleanup]
        public void TearDownForEverySingleTest()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.TestName);
                Logger.Debug("The Test Stopped");                
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (driver == null)
                return;
            driver.Quit();
            driver = null;
            Logger.Trace("Browser stopped successfully.");
        }
    }
}
