using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI

{

    using System.Text;
    using System.Globalization;
    internal class House
    {
        private string link;
        private decimal price;
        private string address;
        private string size;
        

        public House(string link, string price, string address )
        {
            decimal number;


            if (!price.Equals("check")) {


                string exampleTrimmed = String.Concat(price.Where(c => !Char.IsWhiteSpace(c)));
                // Console.WriteLine("EXAMPLE TRIMMED: " + exampleTrimmed);
                decimal d = decimal.Parse(exampleTrimmed, new NumberFormatInfo() { NumberDecimalSeparator = "," });
                Console.WriteLine("DECIMAL: " + d);
                this.price = d;







            }
            else
            {
                this.price = 0;
            }
            
            this.size = size;
            this.link = link;
            
            this.address = address;

        }
        public decimal getPrice()
        {
            if (this.price == 0)
            {
                return 0;
            }
            else
            {
                return this.price;
            }
            
        }
        public string getLink()
        {
            return this.link;
        }
        public string getAddress()
        {
            return this.address;
        }
        public string getSize()
        {
           return this.size;
        }

        public string getText()
        {
            string txt = "Asunto-> hinta:   " + this.price + " , osoite: " + this.address + " size; " + this.size;
            return txt;
        }
    }
}
