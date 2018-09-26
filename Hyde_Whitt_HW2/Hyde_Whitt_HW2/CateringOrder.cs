//Author: Whitt Hyde (wjh695)
//Date: 27 Sept 2018
//Assignment: Homework 2
//Description: Console Application that takes orders for a food truck, then calculate a reciept based on the order. Converted to use Object Oriented Programing Principles.

using System;
namespace Hyde_Whitt_HW2
{
    public class CateringOrder : Order
    {
        //setting some properties for the Catering class
        public string strCustomerCode { get; set; }
        public decimal decDeliveryFee { get; set; }
        public Boolean bolPreferredCustomer { get; set; }

        //constructor with a parameter for customer type
        /* public CateringOrder(CustomerType customertypeInput)
        {
            CustomerType customer_type = customertypeInput;

        }*/

        //calc total method to set delivery fee and to set a calculated total.
        public override void CalcTotals()
        {
            //sets customer delivery fee to zero if preferred
            if (bolPreferredCustomer) { decDeliveryFee = 0; }

            //calculates the total for the order
            decTotal = decSubtotal + decDeliveryFee;

        }

        //overriding the ToString Method
        public override string ToString()
        {
            return "Customer Type: " + CustomerType + "\n" + "Customer Code: " + strCustomerCode + "\n"
                + "Total Items: " + intTotalItems.ToString() + "\nTaco Subtotal: " + decTacoSubtotal.ToString("c2") + "\nSandwich Subtotal: " + decSandwichSubtotal.ToString("c2")
                + "\nSubtotal: " + decSubtotal.ToString("c2") + "\nDelivery Fee: " + decDeliveryFee.ToString("c2") + "\nGrand Total: " + decTotal.ToString("c2");
        }
    }
}
