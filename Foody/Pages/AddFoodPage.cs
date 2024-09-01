using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Pages
{
    public class AddFoodPage : BasePage
    {
        public AddFoodPage(IWebDriver driver) : base(driver) { }

        public string Url => BaseUrl + "Food/Add";
        public IWebElement FoodNameField => driver.FindElement(By.Id("name"));
        public IWebElement FoodDescriptionField => driver.FindElement(By.Id("description"));
        public IWebElement FoodPictureField => driver.FindElement(By.Id("url"));
        public IWebElement AddFoodButton => driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement ErrorMessage => driver.FindElement(By.CssSelector(".validation-summary-errors > ul > li"));

        public void Open()
        {
            driver.Navigate().GoToUrl(Url);
        }

    }
}
