using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Final
{
    class Cart
    {
        List<string> books = new List<string>();

        public double calcPrice(ListBox items)//calculate the total price of the cart
        {
            double price = 0;
            double total = 0;
            bool okay = false;
            foreach (var book in items.Items)
            {
                string line = book.ToString();
                int index = line.LastIndexOf("$");
                int index2 = line.LastIndexOf("-ISBN");
                int dist = index2 - index - 1;
                line = line.Substring(index + 1, dist);
                okay = Double.TryParse(line, out price);
                if (okay)
                {
                    total += price;
                    price = 0;
                }
                else
                {
                    MessageBox.Show("Error with list display. Make sure price is the last item.");
                }
            }
            total = Math.Round(total, 2);
            return total;
        }
    }
    
}
