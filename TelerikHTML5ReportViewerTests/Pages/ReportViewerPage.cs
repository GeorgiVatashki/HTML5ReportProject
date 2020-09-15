﻿using NLog;
using OpenQA.Selenium;
using System;
using System.Net;

namespace TelerikHTML5ReportViewerTests
{
    public class ReportViewerPage : BasePage
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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
            Logger.Info($"Open URL =>{URL.reportViewerLocalhostURL}");
            Driver.Manage().Window.Maximize();

        }

        internal void TogglePrintPreview()
        {
            IWebElement printPreviewButton = Driver.FindElements(By.XPath("//*[@class='t-font-icon k-icon t-i-file']"))[1];
            printPreviewButton.Click();
            Logger.Info("Click Print Preview button ");
        }

        internal void ToggleParametersButton()
        {
            IWebElement parametersButton = Driver.FindElements(By.XPath("//*[@class='t-font-icon k-icon t-i-filter']"))[0];
            parametersButton.Click();
            Logger.Info("Click Toggle Parameters Area button ");
        }

        internal void HTMLReportViwerButton()
        {
            IWebElement ExpandReportButton = Driver.FindElement(By.XPath("//body//img[1]"));
            ExpandReportButton.Click();
            Logger.Info("Click HTML5 Report Viwer Button in order to expand and validate the text");
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
            Logger.Info("Click the Telerik Reporting REST Button in order to expand and validate the text");
        }

        internal void ReportButton()
        {
            ReportDesignersButton.Click();
            Logger.Info("Click the Report Designers Button in order to expand and validate the text");
        }

        internal void FullScreen()
        {            
            FullScreenButton.Click();
            Logger.Info("Click the Toggle Full Page button");
        }

        internal void Refresh()
        {
            IWebElement refresh = Driver.FindElements(By.XPath("//*[@class='t-font-icon k-icon t-i-refresh-a']"))[1];
            refresh.Click();
            Logger.Info("Click the Refresh button");
        }
    }
}
