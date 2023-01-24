using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTester
{
    class Amazon
    {
        private IWebDriver driver;
        private Pages pages;

        public Amazon(IWebDriver driver) {
            this.driver = driver;
        }

        public Pages Pages { 
            get { 
                if (this.pages== null)
                {
                    this.pages = new Pages(driver);
                }
                return pages; 
            } 
        }
    }
}
