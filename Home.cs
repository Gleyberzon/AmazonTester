using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTester
{
    class Home
    {
        private SearchBar searchBar;
        private IWebDriver driver;
        public Home(IWebDriver driver) {
            this.driver = driver;
            driver.Url = "https://www.amazon.com/";
        }

        public SearchBar SearchBar {
            get { 
                if (this.searchBar== null) {
                    this.searchBar = new SearchBar(driver);
                }
                return searchBar; 
            } 
        }
    }
}
