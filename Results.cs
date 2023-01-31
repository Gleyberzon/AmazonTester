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
            string xpath = "//span[@class='a-offscreen' and parent::span[not(@data-a-strike)] ";
            foreach (string key in dict.Keys)
            {
                switch (key) {
                    case "Price_Lower_Then":
                        {
                            xpath += " and translate(text(),'$,','')<" + Int32.Parse(dict[key]);
                            break;
                        }
                    case "Price_Lower_Or_Equal_Then":
                        {
                            xpath += " and translate(text(),'$,','')<=" + Int32.Parse(dict[key]);
                            break;
                        }
                    case "Price_Higher_Then":
                        {
                            xpath += " and translate(text(),'$,','')>" + Int32.Parse(dict[key]);
                            break;
                        }
                    case "Price_Higher_Or_Equal_Then":
                        {
                            xpath += " and translate(text(),'$,','')>=" + Int32.Parse(dict[key]);
                            break;
                        }
                    case "Price_Equal_To":
                        {
                            xpath += " and translate(text(),'$,','')=" + Int32.Parse(dict[key]);
                            break;
                        }
                    case "Free_Shipping":
                        {
                            if (dict[key].Equals("True"))
                            {
                                xpath += " and ancestor::div[@data-component-type='s-search-result' and contains(.,'FREE Shipping')]";
                            }
                            if (dict[key].Equals("False"))
                            {
                                xpath += " and ancestor::div[@data-component-type='s-search-result' and not(contains(.,'FREE Shipping'))]";
                            }
                            break;
                        }
                }
            }
            xpath += "]/ancestor::div[@data-component-type='s-search-result']";


            List<IWebElement> list = this.driver.FindElements(By.XPath(xpath)).ToList<IWebElement>();
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
