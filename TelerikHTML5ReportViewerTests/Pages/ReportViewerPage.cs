using NLog;
using OpenQA.Selenium;
using System;
using System.Net;

namespace TelerikHTML5ReportViewerTests
{
    public class ReportViewerPage : BasePage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public ReportViewerPage(IWebDriver driver) : base(driver){}
        public string CurrentImage => MainPrintPreviewImage.GetAttribute("style");
        public IWebElement MainPrintPreviewImage => Driver.FindElement(By.XPath("//*[@data-id='SampleReport_1']"));
        public string CurrentToggleImage => MainTogglePreviewImage.GetAttribute("style");
        public string CurrentFullImage => MainFullScreenImage.GetAttribute("style");
        public IWebElement MainTogglePreviewImage => Driver.FindElement(By.XPath("//*[@class='trv-pages-area k-widget k-pane k-scrollable scrollable interactive']"));
        public IWebElement MainFullScreenImage => Driver.FindElement(By.XPath("//*[@style='height: 667.746px; width: 1657px;']"));
        public IWebElement ExpectedHTML5String => Driver.FindElement(By.XPath("//*[contains(text(),'The HTML5 Report Viewer provides: ')]"));
        public IWebElement ReportingRESTButton => Driver.FindElement(By.XPath("//body//img[2]"));
        public IWebElement ReportDesignersButton => Driver.FindElement(By.XPath("//body//img[3]"));
        public IWebElement FullScreenButton => Driver.FindElement(By.XPath("//*[@class='t-font-icon k-icon t-i-zoom']"));
        public IWebElement ExpectedReportingRestString => Driver.FindElement(By.XPath("//*[contains(text(),'Telerik Reporting REST service ')]"));
        public IWebElement ExpectedReportDesignersString => Driver.FindElement(By.XPath("//*[contains(text(),'authoring environments include features such as WYSIWYG report design surface, enhanced support for')]"));

        internal void GoTo()
        {
            Logger.Trace("Attempting to load the Base Page.");
            Driver.Navigate().GoToUrl(URL.reportViewerLocalhostURL);
            Reporter.LogTestStepForBugLogger(AventStack.ExtentReports.Status.Info, $"Check if the Base page loaded successfully =>{ URL.reportViewerLocalhostURL}");            
            Driver.Manage().Window.Maximize();
            Logger.Info("The Base Page should be maximized");
        }

        internal void TogglePrintPreview()
        {
            IWebElement printPreviewButton = Driver.FindElements(By.XPath("//*[@class='t-font-icon k-icon t-i-file']"))[1];
            Logger.Trace("Attempting to perform a click.");
            printPreviewButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the Toggle Print Preview Button .");            
        }

        internal void ToggleParametersButton()
        {
            IWebElement parametersButton = Driver.FindElements(By.XPath("//*[@class='t-font-icon k-icon t-i-filter']"))[0];
            Logger.Trace("Attempting to perform a click.");
            parametersButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Click Toggle Parameters Area button.");            
        }

        internal void HTMLReportViwerButton()
        {
            IWebElement ExpandReportButton = Driver.FindElement(By.XPath("//body//img[1]"));
            Logger.Trace("Attempting to perform a click.");
            ExpandReportButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Click HTML5 Report Viwer Button in order to expand and validate the text.");            
        }

        internal bool IsLoaded
        {
            get 
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(AventStack.ExtentReports.Status.Info, "Check if the Expected HTML5 String loaded successfully.");                    
                    return ExpectedHTML5String.Displayed;
                    
                }
                catch (NoSuchElementException)
                {
                    return false; 
                }
            }            
            
        }

        internal void TelerikReportingRESTButton()
        {
            Logger.Trace("Attempting to perform a click.");
            ReportingRESTButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the Telerik Reporting REST Button in order to expand and validate the text.");            
        }

        internal void ReportButton()
        {
            Logger.Trace("Attempting to perform a click.");
            ReportDesignersButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the Report Designers Button in order to expand and validate the text.");            
        }

        internal void FullScreen()
        {
            Logger.Trace("Attempting to perform a click.");
            FullScreenButton.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the Toggle Full Page button.");            
        }

        internal void Refresh()
        {
            IWebElement refresh = Driver.FindElements(By.XPath("//*[@class='t-font-icon k-icon t-i-refresh-a']"))[1];
            Logger.Trace("Attempting to perform a click.");
            refresh.Click();
            Reporter.LogPassingTestStepToBugLogger("Click the Refresh button.");            
        }
    }
}
