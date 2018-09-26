//Author: Whitt Hyde (wjh695)
//Date: 27 Sept 2018
//Assignment: Homework 2
//Description: Console Application that takes orders for a food truck, then calculate a reciept based on the order. Converted to use Object Oriented Programing Principles.

using System;
namespace Hyde_Whitt_HW2
{
    public abstract class Order
    {
        //declaring constants
        public const decimal decPriceTaco = 2.00m;
        public const decimal decPriceSand = 7.00m;
        public const decimal decTaxRate = 0.0825m;

        //creating the properties for the class
        public CustomerType CustomerType { get; set; }
        public Int32 intNumberOfSandwiches { get; set; }
        public Int32 intNumberOfTacos { get; set; }
        public decimal decTacoSubtotal { get; set; }
        public decimal decSandwichSubtotal { get; set; }
        public decimal decSubtotal { get; set; }
        public decimal decTotal { get; set; }
        public Int32 intTotalItems { get; set; }

        //blank constructor
        public Order() {}


        //constructor for the class with customer type parameter
        public Order (CustomerType customertypeInput)
        {
            CustomerType customer_type = customertypeInput;

        }

        //method for calculating the total is abstract
        //blank because subclass contains the implementations
        public abstract void CalcTotals();
    }
}
