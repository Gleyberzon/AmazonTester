using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTester
{
    class Search
    {
        private Results results;
        private IWebDriver driver;
        public Search(IWebDriver driver) { 
            this.driver = driver;
        }
        public Results Results {
            get { 
                if (this.results==null)
                {
                    this.results = new Results(driver);
                }
                return results; 
            } 
        }
    }
}
