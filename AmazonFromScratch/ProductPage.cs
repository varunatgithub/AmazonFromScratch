using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonFromScratch
{
    public class ProductPage:BasePage
    {
        protected ElementsAction _elementsAction;
        public ProductPage(IWebDriver driver):base(driver)
        {
            _elementsAction=new ElementsAction(driver);
        }

        private By searchBox = By.Id("twotabsearchtextbox");
        private By searchButton = By.Id("nav-search-submit-button");
        private By productLink = By.CssSelector(".s-main-slot .s-result-item h2 a");
        private By addToCart = By.Id("add-to-cart-button");

        public void SearchAndSelectProduct(string productName)
        {
            //driver.FindElement(searchBox).SendKeys(productName);
            _elementsAction.SendKeys(searchBox, productName);
            wait.Until(d=>d.FindElement(searchButton)).Click();
            wait.Until(d=>d.FindElement(productLink)).Click();

        }

        public void AddToCart()
        {
            ScrollToView(driver.FindElement(addToCart));
            wait.Until(d=>d.FindElement(addToCart)).Click();
        }
    }
}
