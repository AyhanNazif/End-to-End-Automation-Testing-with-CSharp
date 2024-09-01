using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Tests
{
    public class FoodyTests : BaseTest
    {
        public string? title;
        public string? description;

        [Test, Order(1)]
        public void AddFoodWithInvalidDataTest()
        {
            addFoodPage.Open();
            addFoodPage.FoodNameField.Clear();
            addFoodPage.FoodDescriptionField.Clear();
            addFoodPage.AddFoodButton.Click();

            Assert.That(driver.Url.Equals(addFoodPage.Url), "Wrong URL");
            Assert.That(addFoodPage.ErrorMessage.Text, Is.EqualTo("Unable to add this food revue!"), "Food is added correctly!");
        }

        [Test, Order(2)]
        public void AddFoodWithValidDataTest()
        {
            title = GetRandomFoodTitle();
            description = GetRandomFoodDescription();

            addFoodPage.Open();
            addFoodPage.FoodNameField.Clear();
            addFoodPage.FoodNameField.SendKeys(title);
            addFoodPage.FoodDescriptionField.Clear();
            addFoodPage.FoodDescriptionField.SendKeys(description);
            addFoodPage.AddFoodButton.Click();
            action.ScrollToElement(homePage.LastCreatedFoodTitle).Perform();

            Assert.That(driver.Url.Equals(homePage.Url), "Wrong URL");
            Assert.That(homePage.LastCreatedFoodTitle.Text, Is.EqualTo(title), "Food is not added!");
        }

        [Test, Order(3)]
        public void EditLastCreatedFoodTest()
        {
            string updatedTitle = "Changed " + title;
            string updatedDescription = "Changed " + description;

            action.ScrollToElement(homePage.LastCreatedFoodEditButton).Perform();
            homePage.LastCreatedFoodEditButton.Click();
            editFoodPage.FoodNameField.Clear();
            editFoodPage.FoodNameField.SendKeys(updatedTitle);
            editFoodPage.FoodDescriptionField.Clear();
            editFoodPage.FoodDescriptionField.SendKeys(updatedDescription);
            editFoodPage.AddFoodButton.Click();
            action.ScrollToElement(homePage.LastCreatedFoodTitle).Perform();

            Assert.That(driver.Url.Equals(homePage.Url), "Wrong URL");
            Assert.That(homePage.LastCreatedFoodTitle.Text, Is.Not.EqualTo(updatedTitle), "Title updated correctly!");
            Console.WriteLine("title change won't be possible due to incomplete functionality.");
        }

        [Test, Order(4)]
        public void SearchForFoodTitleTest()
        {
            homePage.SearchField.Clear();
            homePage.SearchField.SendKeys(title);
            homePage.SearchButton.Click();
            action.ScrollToElement(homePage.LastCreatedFoodTitle).Perform();

            Assert.That(homePage.AllFoods.Count, Is.EqualTo(1), "Founded more than 1 food!");
            Assert.That(homePage.LastCreatedFoodTitle.Text, Is.EqualTo(title), "Founded food title is not same with searched food!");
        }

        [Test, Order(5)]
        public void DeleteLastCreatedFoodTest()
        {
            var countAllFoodsBeforeDelete = homePage.AllFoods.Count();
            Assert.That(countAllFoodsBeforeDelete, Is.GreaterThanOrEqualTo(1), "There is no food yet!");

            action.ScrollToElement(homePage.LastCreatedFoodDeleteButton).Perform();
            homePage.LastCreatedFoodDeleteButton.Click();
            action.ScrollToElement(homePage.LastCreatedFoodTitle).Perform();

            Assert.That(homePage.AllFoods.Count, Is.LessThan(countAllFoodsBeforeDelete), "The count of food is not decreased!");
            Assert.That(homePage.LastCreatedFoodTitle.Text, Is.Not.EqualTo(title), "The food is not deleted!");
        }

        [Test, Order(6)]
        public void SearchForDeletedFoodTest()
        {
            homePage.SearchField.Clear();
            homePage.SearchField.SendKeys(title);
            homePage.SearchButton.Click();
            action.ScrollToElement(homePage.LastCreatedFoodTitle).Perform();
            var notFoundedFood = homePage.LastCreatedFoodTitle.Text;

            Assert.That(notFoundedFood, Is.EqualTo("There are no foods :("), "Founded food after is deleted!");
            Assert.IsTrue(homePage.AddFoodButton.Displayed, "There is no exist button Add Food!");
        }
    }
}
