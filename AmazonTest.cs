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
            // Be dure that you have drivers in path C:/drivers/<driver_name>/
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
            Amazon.Pages.Home.SearchBar.Text = "Computer monitor";
            Amazon.Pages.Home.SearchBar.Click();
            List<Item> items = Amazon.Pages.Search.Results.GetResultsBy(new Dictionary<string, string>() {
                {"Price_Lower_Then","1000"},
                //{"Price_Lower_Or_Equal_Then","1000"},
                //{"Price_Higher_Then","200"},
                {"Price_Higher_Or_Equal_Then","0"}
                //{"Price_Equal_To","349"},
                //{"Free_Shipping","True"},
                //{"Free_Shipping","False"}
            });
            Console.WriteLine("Results: \n");
            foreach (Item item in items)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Price);
                Console.WriteLine(item.Link + "\n");
            }
            Assert.Pass();
        }

        [TearDown] public void TearDown()
        {
            browserFactory.CloseAllDrivers();
        }
    }
}