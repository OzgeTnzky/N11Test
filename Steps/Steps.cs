using N11Test.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace N11Test.Steps
{
    [Binding]
    public sealed class Steps
    {
        public IWebDriver Driver { get; set; }
        public BasePage basePage;     
        private readonly ScenarioContext context;
        public Steps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
        [BeforeScenario]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-popup-blocking");
            options.AddArgument("disable-notifications");
            options.AddArgument("test-type");
            Driver = new ChromeDriver(options);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Driver.Navigate().GoToUrl("https://www.n11.com/");
            basePage = new BasePage(Driver);
        }

        [Given("\"(.*)\" arama alanına tıklanır.")]
        public void Search(string obje)
        {
            basePage.ClickElement(By.CssSelector(obje));
        }

        [Given("\"(.*)\" arama alanına \"(.*)\" yazılır.")]
        public void Object(String obje, String text)
        {
            basePage.SendKeys(By.CssSelector(obje), text);  
        }

        [Given("\"(.*)\" arama butonuna tıklanır.")]
        public void Button(string obje)
        {
            basePage.ClickElement(By.CssSelector(obje));
        }

        [Given("\"(.*)\" saniye süreyle beklenir.")]
        public void Wait(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        [Given("\"(.*)\" ana sayfaya geri gider.")]
        public void Page(string obje)
        {
            basePage.ClickElement(By.CssSelector(obje));
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
