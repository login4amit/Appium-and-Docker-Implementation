using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumParallelTest
{
    [TestFixture]
    [Parallelizable]
    public class FirefoxTesting : Hooks
    {
        public FirefoxTesting()
            : base(BrowerType.Firefox)
        {

        }

        [Test]
        public void FirefoxServiceEdgeLoginTest()
        {
            Driver.Navigate().GoToUrl("https://staging.servicebookpro.com/?cid=428");
            System.Threading.Thread.Sleep(5000);
            Driver.FindElement(By.Id("ctl00_ctl00_Main_Main_txtUsername")).SendKeys("adp_csr");
            Driver.FindElement(By.Id("ctl00_ctl00_Main_Main_txtPassword")).SendKeys("6u$iN9acQ%");
            Driver.FindElement(By.Id("ctl00_ctl00_Main_Main_btnLogin")).Click();
            System.Threading.Thread.Sleep(5000);
            Assert.That(Driver.PageSource.Contains("ADP CSR"), Is.EqualTo(true), "Login failed");
            Driver.FindElement(By.XPath("//a[contains(@id,'Main_AppMast_lnkLogOut')]/img")).Click();
            System.Threading.Thread.Sleep(5000);
            Driver.Quit();

        }
    }


    [TestFixture]
    [Parallelizable]
    public class ChromeTesting : Hooks
    {
        public ChromeTesting()
            : base(BrowerType.Chrome)
        {
        }

        [Test]
        public void ChromeServiceEdgeLoginTest()
        {
            Driver.Navigate().GoToUrl("https://staging.servicebookpro.com/?cid=428");
            System.Threading.Thread.Sleep(5000);
            Driver.FindElement(By.Id("ctl00_ctl00_Main_Main_txtUsername")).SendKeys("adp_csr");
            Driver.FindElement(By.Id("ctl00_ctl00_Main_Main_txtPassword")).SendKeys("6u$iN9acQ%");
            Driver.FindElement(By.Id("ctl00_ctl00_Main_Main_btnLogin")).Click();
            System.Threading.Thread.Sleep(5000);
            Assert.That(Driver.PageSource.Contains("ADP CSR"), Is.EqualTo(true), "Login failed");
            Driver.FindElement(By.XPath("//a[contains(@id,'Main_AppMast_lnkLogOut')]/img")).Click();
            System.Threading.Thread.Sleep(5000);
            Driver.Quit();
        }
    }

    [TestFixture]
    [Parallelizable]
    public class AppiumTesting : Hooks
    {
        public AppiumTesting()
            : base(BrowerType.Appium)
        {
        }

        [Test]
        public void AppiumCayanAppLoginTest()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            driver.FindElementByXPath("//XCUIElementTypeButton[@name=\"OK\"]").Click();
            Thread.Sleep(2000);
            driver.FindElementByXPath("//XCUIElementTypeAlert[@name=\"Locate your DMS\"]/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeCollectionView/XCUIElementTypeCell/XCUIElementTypeTextField").Clear();
            driver.FindElementByXPath("//XCUIElementTypeAlert[@name=\"Locate your DMS\"]/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeCollectionView/XCUIElementTypeCell/XCUIElementTypeTextField").SendKeys("http://172.29.211.148/of/admin/se.php");
            Thread.Sleep(2000);
            driver.FindElementByXPath("//XCUIElementTypeButton[@name=\"OK\"]").Click();


            driver.FindElement(By.XPath("//XCUIElementTypeOther[@name=\"ServiceEdge\"]/XCUIElementTypeOther[1]/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeOther[1]/XCUIElementTypeOther[2]/XCUIElementTypeTextField")).Click();

            //Enter credentials
            driver.FindElement(By.XPath("//XCUIElementTypeOther[@name=\"ServiceEdge\"]/XCUIElementTypeOther[1]/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeOther[1]/XCUIElementTypeOther[2]/XCUIElementTypeTextField")).SendKeys("adp");
            driver.FindElement(By.XPath("//XCUIElementTypeOther[@name=\"ServiceEdge\"]/XCUIElementTypeOther[1]/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther[2]/XCUIElementTypeSecureTextField")).SendKeys("rTHrBmp3");

            Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//UIAApplication[1]/UIAWindow[1]/UIAScrollView[1]/UIAWebView[1]/UIASecureTextField[1]")).SendKeys(Keys.Return);
            driver.FindElement(By.XPath("//XCUIElementTypeButton[@name=\"Login\"]")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//XCUIElementTypeButton[@name=\"Done\"]")).Click();

        }
    }
}
