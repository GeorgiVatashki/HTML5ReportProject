using OpenQA.Selenium;
using System;
using System.Net;

namespace TelerikHTML5ReportViewerTests
{
    public class ReportViewerPage : BasePage
    {
        public ReportViewerPage(IWebDriver driver) : base(driver)
        {
        }
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
            Driver.Navigate().GoToUrl(URL.reportViewerLocalhostURL);
            Driver.Manage().Window.Maximize();
        }

        internal void TogglePrintPreview()
        {
            IWebElement printPreviewButton = Driver.FindElements(By.XPath("//*[@class='t-font-icon k-icon t-i-file']"))[1];
            printPreviewButton.Click();
            
        }

        internal void ToggleParametersButton()
        {
            IWebElement parametersButton = Driver.FindElements(By.XPath("//*[@class='t-font-icon k-icon t-i-filter']"))[0];
            parametersButton.Click();
        }

        internal void HTMLReportViwerButton()
        {
            IWebElement ExpandReportButton = Driver.FindElement(By.XPath("//body//img[1]"));
            ExpandReportButton.Click();
        }

        internal bool IsLoaded
        {
            get 
            {
                try
                {
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
            ReportingRESTButton.Click();
        }

        internal void ReportButton()
        {
            ReportDesignersButton.Click();
        }

        internal void FullScreen()
        {            
            FullScreenButton.Click();
        }

        internal void Refresh()
        {
            IWebElement refresh = Driver.FindElements(By.XPath("//*[@class='t-font-icon k-icon t-i-refresh-a']"))[1];
            refresh.Click();
        }
    }
}
