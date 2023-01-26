using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTester
{
    class Results
    {
        private IWebDriver driver;
        private IWebElement items;

        public Results(IWebDriver driver)
        {
            this.driver = driver;
            this.items = driver.FindElement(By.CssSelector(".s-result-list"));
        }

        public List<Item> GetResultsBy(Dictionary<string,string> dict) 
        {
            if (dict == null || dict.Count == 0)
                return null;
            string xpath = "/";
            foreach (string key in dict.Keys)
            {
                switch (key) {
                    case "Price_Lower_Then":
                        {
                            xpath += "/./*//span[@class='a-offscreen' and parent::*[not(@data-a-strike='True')] and translate(text(),'$,','')<" + Int32.Parse(dict[key]) + "]/ancestor::div[@data-component-type='s-search-result']";
                            break;
                        }
                    case "Price_Lower_Or_Equal_Then":
                        {
                            xpath += "/./*//span[@class='a-offscreen' and parent::*[not(@data-a-strike='True')] and translate(text(),'$,','')<=" + Int32.Parse(dict[key]) + "]/ancestor::div[@data-component-type='s-search-result']";
                            break;
                        }
                    case "Price_Higher_Then":
                        {
                            xpath += "/./*//span[@class='a-offscreen' and parent::*[not(@data-a-strike='True')] and translate(text(),'$,','')>" + Int32.Parse(dict[key]) + "]/ancestor::div[@data-component-type='s-search-result']";
                            break;
                        }
                    case "Price_Higher_Or_Equal_Then":
                        {
                            xpath += "/./*//span[@class='a-offscreen' and parent::*[not(@data-a-strike='True')] and translate(text(),'$,','')>=" + Int32.Parse(dict[key]) + "]/ancestor::div[@data-component-type='s-search-result']";
                            break;
                        }
                    case "Price_Equal_To":
                        {
                            xpath += "/./*//span[@class='a-offscreen' and parent::*[not(@data-a-strike='True')] and translate(text(),'$,','')=" + Int32.Parse(dict[key]) + "]/ancestor::div[@data-component-type='s-search-result']";
                            break;
                        }
                    case "Free_Shipping":
                        {
                            if (dict[key].Equals("True"))
                            {
                                xpath += "/./*//*[contains(text(),'FREE Shipping')]/ancestor::div[@data-component-type='s-search-result']";
                            }
                            if (dict[key].Equals("False"))
                            {
                                xpath += "/./*//*[not(contains(text(),'FREE Shipping'))]/ancestor::div[@data-component-type='s-search-result']";
                            }
                            break;
                        }
                }
            }

            List<IWebElement> list = this.items.FindElements(By.XPath(xpath)).ToList<IWebElement>();
            List<Item> items = new List<Item>();
            foreach (IWebElement el in list)
            {
                string title = el.FindElement(By.CssSelector(".a-size-medium.a-color-base.a-text-normal")).Text;
                string price = el.FindElement(By.CssSelector(".a-price-whole")).Text +'.'+ el.FindElement(By.CssSelector(".a-price-fraction")).Text+'$';
                string link = el.FindElement(By.XPath(".//a[@class='a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']")).GetAttribute("href");
                items.Add(new Item(title, price, link));
            }
            return items;
        }
    }
}
