using OpenQA.Selenium;

namespace AmazonTester
{
    public class Tests
    {
        BrowserFactory browserFactory;
        IWebDriver chrome;
        IWebDriver edge;
        IWebDriver firefox;
        Amazon Amazon;

        [SetUp]
        public void Setup()
        {
            browserFactory = new BrowserFactory();
            browserFactory.InitBrowser("chrome");
            //browserFactory.InitBrowser("edge");
            //browserFactory.InitBrowser("firefox");

            chrome = browserFactory.Drivers["CHROME"];
            //edge = browserFactory.Drivers["EDGE"];
            //firefox = browserFactory.Drivers["FIREFOX"];

            Amazon = new Amazon(chrome);
        }

        [Test]
        public void Test1()
        {
            Amazon.Pages.Home.SearchBar.Text = "PC";
            Amazon.Pages.Home.SearchBar.Click();
            List<Item> items = Amazon.Pages.Search.Results.GetResultsBy(new Dictionary<string, string>() {
                {"Price_Lower_Then","1400"},
                {"Price_Higher_Then","600"}
            });
            Console.WriteLine("Results: \n");
            foreach (Item item in items)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Price+"\n");
            }
            Assert.Pass();
        }

        [TearDown] public void TearDown()
        {
            browserFactory.CloseAllDrivers();
        }
    }
}