using Foody.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Foody.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        public LoginPage loginPage;
        public AddFoodPage addFoodPage;
        public HomePage homePage;
        public EditFoodPage editFoodPage;
        protected Actions action;

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();

            action = new Actions(driver);
            loginPage = new LoginPage(driver);
            addFoodPage = new AddFoodPage(driver);
            homePage = new HomePage(driver);
            editFoodPage = new EditFoodPage(driver);

            loginPage.Open();
            loginPage.PerformLogin("Guardian1", "123456");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public string GetRandomFoodTitle()
        {
            Random random = new Random();
            return "Random Title" + random.Next(100, 999);
        }

        public string GetRandomFoodDescription()
        {
            Random random = new Random();
            return "Random Description" + random.Next(100, 999);
        }
    }
}