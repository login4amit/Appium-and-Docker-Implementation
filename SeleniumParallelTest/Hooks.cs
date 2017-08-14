using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Reflection;
using OpenQA.Selenium.Remote;

namespace SeleniumParallelTest
{
    //Enum for browserType
    public enum BrowerType
    {
        Chrome,
        Firefox,
        Appium
   
    }


    //Fixture for class
    [TestFixture]
    public class Hooks : Base
    {
        private BrowerType _browserType;
        private static int _defaultTimeOut = 480;


        public Hooks(BrowerType browser)
        {
            _browserType = browser;
        }


        [SetUp]
        public void InitializeTest()
        {
            ChooseDriverInstance(_browserType);
        }

        private void ChooseDriverInstance(BrowerType browserType)
        {
            //var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembl‌​y().Location);

            if (browserType == BrowerType.Chrome)
            {
                DesiredCapabilities desiredCapabilitesChrome = DesiredCapabilities.Chrome();
                //desiredCapabilitesChrome = new DesiredCapabilities(BrowserName, BrowserVersion, Platform.CurrentPlatform); // set the desired browser 
                desiredCapabilitesChrome.SetCapability("browser", "chrome");
                desiredCapabilitesChrome.SetCapability("platform", "LINUX"); // operating system to use
                desiredCapabilitesChrome.SetCapability("version", "");
                //desiredCapabilitesChrome.SetCapability("username", System.Configuration.ConfigurationManager.AppSettings["SAUCE_LABS_ACCOUNT_NAME"]); // supply sauce labs username
                //desiredCapabilitesChrome.SetCapability("accessKey", System.Configuration.ConfigurationManager.AppSettings["SAUCE_LABS_ACCOUNT_KEY"]);  // supply sauce labs account key
                //if (ScenarioContext.Current != null)
                //{
                //    desiredCapabilitesChrome.SetCapability("name", ScenarioContext.Current.ScenarioInfo.Title);
                //}
                //else
                {
                    desiredCapabilitesChrome.SetCapability("name", "Executing Before Feature");
                }
                Uri commandExecutorUri = new Uri("http://192.168.99.100:4446/wd/hub");
                Driver = new RemoteWebDriver(commandExecutorUri, desiredCapabilitesChrome);
                Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(_defaultTimeOut));
                Driver.Manage().Window.Maximize();
                Driver.Manage().Cookies.DeleteAllCookies(); 
            }
            else if (browserType == BrowerType.Firefox)
            {
                //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                //service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                //service.HideCommandPromptWindow = true;
                //service.SuppressInitialDiagnosticInformation = true;
                //Driver = new FirefoxDriver(service);
               // var profile = GetFirefoxProfile();

                DesiredCapabilities desiredCapabilites = DesiredCapabilities.Firefox();
                desiredCapabilites.SetCapability("platform", "LINUX"); // operating system to use
                desiredCapabilites.SetCapability("browser", "firefox");
                desiredCapabilites.SetCapability("version", "");
                //desiredCapabilites.SetCapability("username", System.Configuration.ConfigurationManager.AppSettings["SAUCE_LABS_ACCOUNT_NAME"]); // supply sauce labs username
                //desiredCapabilites.SetCapability("accessKey", System.Configuration.ConfigurationManager.AppSettings["SAUCE_LABS_ACCOUNT_KEY"]);  // supply sauce labs account key
                //desiredCapabilites.SetCapability(FirefoxDriver.ProfileCapabilityName, profile.ToBase64String());
                ////if (ScenarioContext.Current != null)
                ////{
                ////    desiredCapabilites.SetCapability("name", ScenarioContext.Current.ScenarioInfo.Title);
                ////}
                //else
                {
                    desiredCapabilites.SetCapability("name", "Executing Before Feature");
                }
                Uri commandExecutorUri = new Uri("http://192.168.99.100:4446/wd/hub");
                Driver = new RemoteWebDriver(commandExecutorUri, desiredCapabilites);
                Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMinutes(5));
                Driver.Manage().Window.Maximize();
                Driver.Manage().Cookies.DeleteAllCookies();
            }
            else if (browserType == BrowerType.Appium)
            {
                DesiredCapabilities capabilities = DesiredCapabilities.IPad();
                //Capabilities for SIMULATOR
                capabilities.SetCapability("AutoWebView", true);
                capabilities.SetCapability("platformName", "iOS");
                capabilities.SetCapability("platformVersion", "9.3");
                capabilities.SetCapability("platform", "Mac");
                capabilities.SetCapability("deviceName", "iPad Air 2");
               // capabilities.SetCapability("app", "/Users/Kulkarnam/Downloads/Cayanee.app");
                capabilities.SetCapability("app", "/Users/Kulkarnam/Downloads/codebusters-master@ab6d5afa58f/CayenApp/Appointments.app");
                capabilities.SetCapability("automationName", "XCUITest");

                //Capabilities for IPAD REAL DEVICE
                //capabilities.SetCapability("deviceName", "iPad 2");
                //capabilities.SetCapability("udid", "8d1125018597484c13f6ebc7c26c4f8713b78585");
                //capabilities.SetCapability("bundleId", "com.so-auto.laneproadp");
                //capabilities.SetCapability("app", "/Users/cdkuser/Downloads/ServicebookPro-1-8-4-7.ipa");

                ////////////////////////////////////////////////
                Uri serverUri = new Uri("http://100.126.48.124:4723/wd/hub");
                //Uri serverUri = new Uri("http://139.126.244.113:4723/wd/hub");
                driver = new IOSDriver<IWebElement>(serverUri, capabilities, TimeSpan.FromSeconds(100));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(100));

            }

        }

        [TearDown]
        public void CloseBrowser()
        {
            Driver.Quit();
        }


    }
}
