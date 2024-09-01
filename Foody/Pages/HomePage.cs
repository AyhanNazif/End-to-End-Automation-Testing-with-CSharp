using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public string Url => BaseUrl;

        public IWebElement SearchField => driver.FindElement(By.Name("keyword"));
        public IWebElement SearchButton => driver.FindElement(By.CssSelector(".btn-primary"));
        public IReadOnlyCollection<IWebElement> AllFoods => driver.FindElements(By.Id("scroll"));
        public IWebElement LastCreatedFoodTitle => AllFoods.Last().FindElement(By.CssSelector(".p-5 > h2"));
        public IWebElement LastCreatedFoodEditButton => AllFoods.Last().FindElement(By.LinkText("EDIT"));
        public IWebElement LastCreatedFoodDeleteButton => AllFoods.Last().FindElement(By.LinkText("DELETE"));
        public IWebElement AddFoodButton => driver.FindElement(By.CssSelector(".p-5 > a[href='/Food/Add']"));

    }
}
