using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTester
{
    class Pages
    {
        private Home home;
        private Search search;
        private IWebDriver driver;
        public Pages(IWebDriver driver)
        {
            this.driver = driver;
        }
        public Home Home {
            get {
                if (this.home == null)
                {
                    this.home = new Home(driver);
                }
                return home; 
            } 
        }

        public Search Search { 
            get {
                if (this.search == null) 
                {
                    this.search = new Search(driver);
                }
                return search; 
            } 
        }
    }
}
