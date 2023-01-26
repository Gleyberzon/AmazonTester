using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTester
{
    class Item
    {
        private string title;
        private string price;
        private string link;
        public Item(string title, string price, string link)
        {
            this.title = title;
            this.price = price;
            this.link = link;
        }
        public string Title { 
            get{
                return this.title;
            } 
        }
        public string Price { 
            get {
                return this.price;
            }
        }

        public string Link
        {
            get
            {
                return this.link;
            }
        }
    }
}
