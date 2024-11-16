using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonFromScratch
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait=new WebDriverWait(driver,TimeSpan.FromSeconds(10));
        }
        public void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.in/");
        }

        public virtual void WaitForPageLoad()
        {
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public virtual void ScrollToView(IWebElement element)
        {
            try
            {
                if(element == null)
                    throw new ArgumentNullException(nameof(element),"Element cannot be null!");
                if(!element.Enabled || !element.Displayed)
                    throw new ElementNotInteractableException("Element is either not enabled or not displayed");

                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);",element);

                Thread.Sleep(300);
            }
            catch(JavaScriptException jsx)
            {
                throw new WebDriverException($"Failed to Scroll into view { jsx.Message }");
            }
        }
    }
}
