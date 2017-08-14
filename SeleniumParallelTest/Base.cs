using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Support.UI;

namespace SeleniumParallelTest
{
    public class Base
    {

        public IWebDriver Driver { get; set; }

        public AppiumDriver<IWebElement> driver { get; set; }

    }
}
