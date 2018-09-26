//Author: Whitt Hyde (wjh695)
//Date: 27 Sept 2018
//Assignment: Homework 2
//Description: Console Application that takes orders for a food truck, then calculate a reciept based on the order. Converted to use Object Oriented Programing Principles.

using System;
namespace Hyde_Whitt_HW2
{
    public class ConsumerOrder : Order
    {
        //creating properties for the class
        public string strCustomerName { get; set; }
        public decimal decSalesTax { get; set; }

        //constructor with a parameter for customertype
        /* public ConsumerOrder (CustomerType customertypeInput)
        {
            CustomerType customer_type = customertypeInput;

        } */

        //method to calculate the totals for sales tax and the total
        public override void CalcTotals()
        {
            decSalesTax = decTaxRate * decSubtotal;
            decTotal = decSubtotal + decSalesTax;
        }

        //overriding the ToString Method for this class
        public override string ToString()
        {
            return "Customer Type: " + CustomerType + "\n" + "Customer name: " + strCustomerName + "\n"
                + "Total Items: " + intTotalItems.ToString() + "\nTaco Subtotal: " + decTacoSubtotal.ToString("c2") + "\nSandwich Subtotal: " + decSandwichSubtotal.ToString("c2")
                + "\nSubtotal: " + decSubtotal.ToString("c2") + "\nSales Tax: " + decSalesTax.ToString("c2") + "\nGrand Total: " + decTotal.ToString("c2");
        }
    }
}
