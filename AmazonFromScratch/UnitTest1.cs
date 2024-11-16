using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AmazonFromScratch
{
    public class Tests
    {
        private IWebDriver _driver;
        private ProductPage _productPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _productPage=new ProductPage(_driver);

        }
        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }

        [Test]
        public void AddProductToCart()
        {
            //Thread.Sleep(10000);

                
            _productPage.NavigateToHomePage();
            _productPage.WaitForPageLoad();
            _productPage.SearchAndSelectProduct("Samsung");
            _productPage.WaitForPageLoad();
            List<string> allWindows = _driver.WindowHandles.ToList();

            _driver.SwitchTo().Window(allWindows.Last());
            _productPage.AddToCart();
        }
    }
}