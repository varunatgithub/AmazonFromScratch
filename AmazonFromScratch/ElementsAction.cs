using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonFromScratch
{
    public class ElementsAction
    {
        protected IWebDriver driver;

        public ElementsAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Click(By locator)
        {
            driver.FindElement(locator).Click();
        }
        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void Click(string selector)
        {
            driver.FindElement(By.CssSelector(selector)).Click();
        }

        public void SendKeys(By by,string text,bool clearFirst=true)
        {
            var element = driver.FindElement(by);
            if(clearFirst)
            {
                element.Clear();
            }
            element.SendKeys(text);
        }
    }
}
