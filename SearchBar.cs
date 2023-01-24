using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTester
{
    class SearchBar
    {
        private IWebDriver driver;
        private IWebElement search_bar;
        private IWebElement search_button;
        private string text;
        public SearchBar(IWebDriver driver) {
            this.driver = driver;
            this.search_bar = this.driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']"));
            this.search_button = this.driver.FindElement(By.XPath("//input[@id='nav-search-submit-button']"));
        }

        public string Text
        {
            set{ 
                this.text = value;
                this.search_bar.SendKeys(value);
            }
        }
        public void Click()
        {
            this.search_button.Click();
        }
    }
}
