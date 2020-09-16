using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TelerikHTML5ReportViewerTests
{


    //INFO///
    /// <summary>
    /// In order to run all of these tests first you have to open (expand) the ExpectedHTML5String Project and to select TelerikHTML5ReportViewerPage.html file.
    /// Finally through the main menu select Debug- Start Without Debugging option. This will load the Report Page. Now you are able to run all tests against that page.
    /// The Results are in C:\temp
    /// </summary>

    [TestClass]
    [TestCategory("ReportViewerPage")]
    public class ReportViewerTest : BaseTest
    {
        [TestMethod]
        [TestProperty("Author", "GeorgiVatashki")]
        [Description("Validate that the localhostReportViewer page opens successfully.")]
        public void TCID1_LoadBasePage()
        {
            ReportViewerPage reportPage = new ReportViewerPage(driver);
            reportPage.GoTo();
            Assert.AreEqual("Telerik HTML5 Report Viewer", driver.Title);

        }

        [TestMethod]
        [TestProperty("Author", "GeorgiVatashki")]
        [Description("Validate that the Print preview button works.")]
        public void TCID2_PrintPreviewButton()
        {
            ReportViewerPage reportPage = new ReportViewerPage(driver);
            reportPage.GoTo();
            reportPage.TogglePrintPreview();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@data-id='SampleReport_1']")));
            Assert.AreEqual("position: absolute; overflow: hidden; left: 38px; top: 174px; width: 740px; height: 100px;", reportPage.CurrentImage);

        }

        [TestMethod]
        [TestProperty("Author", "GeorgiVatashki")]
        [Description("Validate that the Data field on the right side dissapears.")]
        public void TCID3_ToggleParametersAreaButton()
        {
            ReportViewerPage reportPage = new ReportViewerPage(driver);
            reportPage.GoTo();
            reportPage.ToggleParametersButton();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@class='trv-pages-area k-widget k-pane k-scrollable scrollable interactive']")));
            Assert.AreEqual("position: absolute; top: 0px; width: 1901px; height: 876.594px; left: 0px;", reportPage.CurrentToggleImage);
        }

        [TestMethod]
        [TestProperty("Author", "GeorgiVatashki")]
        [Description("Validate that the HTMLReportViwer extension works.")]
        public void TCID4_HTMLReportViwerButton()
        {
            ReportViewerPage reportPage = new ReportViewerPage(driver);
            reportPage.GoTo();
            reportPage.HTMLReportViwerButton();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(text(),'The HTML5 Report Viewer provides: ')]")));
            Assert.IsTrue(reportPage.IsLoaded, "The HTMLReportViwer extension did not open successfully.");
        }

        
        [TestMethod]
        [TestProperty("Author", "GeorgiVatashki")]
        [Description("Validate that the Telerik Reporting REST service extension works.")]
        public void TCID5_TelerikReportingRESTButton()
        {
            ReportViewerPage reportPage = new ReportViewerPage(driver);
            reportPage.GoTo();
            reportPage.TelerikReportingRESTButton();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(text(),'Telerik Reporting REST service ')]")));
            Assert.AreEqual("The Telerik Reporting REST service provides a simple Application Programming Interface (API) to a report", reportPage.ExpectedReportingRestString.Text);
        }

        [TestMethod]
        [TestProperty("Author", "GeorgiVatashki")]
        [Description("Validate that the Report Designers extension works.")]
        public void TCID6_ReportDesignerButton()
        {
            ReportViewerPage reportPage = new ReportViewerPage(driver);
            reportPage.GoTo();
            reportPage.ReportButton();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@data-id='htmlTextBoxReportDesigners_1']")));
            Assert.AreEqual("authoring environments include features such as WYSIWYG report design surface, enhanced support for", reportPage.ExpectedReportDesignersString.Text);
        }

        [TestMethod]
        [TestProperty("Author", "GeorgiVatashki")]
        [Description("Validate that the Full Page button works.")]
        public void TCID7_FullPageButton()
        {
            ReportViewerPage reportPage = new ReportViewerPage(driver);
            reportPage.GoTo();
            reportPage.FullScreen();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@style='height: 667.746px; width: 1657px;']")));
            Assert.AreEqual("height: 667.746px; width: 1657px;", reportPage.CurrentFullImage);
        }

        [TestMethod]
        [TestProperty("Author", "GeorgiVatashki")]
        [Description("Validate that the Refresh button works.")]
        public void TCID8_RefreshButton()
        {
            ReportViewerPage reportPage = new ReportViewerPage(driver);
            reportPage.GoTo();
            reportPage.HTMLReportViwerButton();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(text(),'The HTML5 Report Viewer provides: ')]")));
            Assert.IsTrue(reportPage.IsLoaded, "The HTMLReportViwer extension did not open successfully.");
            reportPage.Refresh();            
            Assert.IsTrue(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@style='height: 297px; width: 737px;']"))).Displayed);          

        }  
    }
}


