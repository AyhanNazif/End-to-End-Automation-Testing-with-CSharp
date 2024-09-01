using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        public string BaseUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
