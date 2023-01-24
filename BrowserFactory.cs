using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTester
{
    class BrowserFactory
    {
        private Dictionary<string, IWebDriver> drivers;

        public BrowserFactory()
        {
            drivers = new Dictionary<string, IWebDriver>();
        }

        public Dictionary<string, IWebDriver> Drivers
        {
            get
            {
                return drivers;
            }
            private set
            {
                Drivers = value;
            }
        }

        public void InitBrowser(string browserName)
        {
            if (!drivers.ContainsKey(browserName.ToUpper()))
            {
                IWebDriver driver;
                switch (browserName.ToUpper())
                {
                    case "FIREFOX":
                        driver = new EdgeDriver("C:\\Drivers\\firefox");
                        drivers.Add(browserName.ToUpper(), driver);
                        break;

                    case "EDGE":
                        driver = new EdgeDriver("C:\\Drivers\\edge");
                        drivers.Add(browserName.ToUpper(), driver);
                        break;

                    case "CHROME":
                    default:
                        driver = new ChromeDriver("C:\\Drivers\\chrome");
                        drivers.Add(browserName.ToUpper(), driver);
                        break;
                }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
        }

        public void LoadApplication(IWebDriver driver, string url)
        {
            driver.Url = url;
        }

        public void CloseAllDrivers()
        {
            if (drivers != null)
            {
                foreach (var key in drivers.Keys)
                {
                    drivers[key].Close();
                    drivers[key].Quit();
                }
            }
        }
    }
}
