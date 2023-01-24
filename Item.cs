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
        public Item(string title, string price)
        {
            this.title = title;
            this.price = price;
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
    }
}
