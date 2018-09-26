//Author: Whitt Hyde (wjh695)
//Date: 27 Sept 2018
//Assignment: Homework 2
//Description: Console Application that takes orders for a food truck, then calculate a reciept based on the order. Converted to use Object Oriented Programing Principles.

using System.Text.RegularExpressions;
using System;
using System.Linq;

namespace Hyde_Whitt_HW2
{
    public enum CustomerType { CONSUMER, CATERING };
    class MainClass
    {
        public static void Main(string[] args)
        {
            //declaring constants
            const decimal decPriceTaco = 2.00m;
            const decimal decPriceSand = 7.00m;

            //declaring variables for input
            string strCustomerCodeInput;
            string strTacos;
            Int32 intTacos;
            string strSand;
            Int32 intSandwiches;
            Int32 intCountItems;

        
            //declaring Boolean variable for customer type and positive number validation
            Boolean bolCustomerType;

            //Get customer type from the user with a while post validation loop
            do
            {
                //Ask for the Customer Type
                Console.WriteLine("Which type of order would you like to process <CONSUMER or CATERING>?");
                strCustomerCodeInput = Console.ReadLine().ToUpper();

                //calling validation method to validate the users input on type of customer
                bolCustomerType = Validation.CheckCustomerType(strCustomerCodeInput);

                //prints error message if the customer enters incorrect value for type of customer
                if (bolCustomerType == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid customer type. Please enter either 'Consumer' or 'Catering'. ");
                    Console.WriteLine("");
                }
            } while (bolCustomerType == false);

            //get customer input for number of tacos/sandwiches while validating that they ordered at least one item
            do
            {
                // start the order process
                intCountItems = 0;

                //taco order loop
                do
                {
                    //asks user for input
                    Console.WriteLine("How Many Tacos would you like?:");
                    strTacos = Console.ReadLine();

                    //call check positive to make sure order amount is a correct format
                    intTacos = Validation.CheckItem(strTacos);

                    //taco error message
                    if (intTacos == -1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Invalid Taco Order Amount. Please Order in whole number intervals with no special symbols.");
                        Console.WriteLine("");
                    }

                    //keep order count to make sure they order at least one item
                    else if (intTacos != -1) { intCountItems = intCountItems + intTacos; }

                    //inserts blank line for readability
                    Console.WriteLine("");

                } while (intTacos == -1);

                //Sandwich order loop
                do
                {
                    //asks user for input
                    Console.WriteLine("How Many Sandwiches would you like?:");
                    strSand = Console.ReadLine();

                    //call check positive to make sure order amount is a correct format
                    intSandwiches = Validation.CheckItem(strSand);

                    //Sandwich error message
                    if (intSandwiches == -1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Invalid Sandwich Order Amount. Please Order in whole number intervals with no special symbols.");
                        Console.WriteLine("");
                    }

                    //keep order count to make sure they order at least one item
                    else if (intSandwiches != -1) { intCountItems = intCountItems + intSandwiches; }

                    //inserts blank line for readability
                    Console.WriteLine("");

                } while (intSandwiches == -1);

                if (intCountItems < 1)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid order amount. Customers must order at least one item.");
                    Console.WriteLine("");
                }

            } while (intCountItems < 1);

            if (strCustomerCodeInput == "CATERING")
            { CheckoutCatering(intTacos, intSandwiches); }
            else if (strCustomerCodeInput == "CONSUMER")
            { CheckoutConsumer(intTacos, intSandwiches); }

            //code to keep code running until we press a key
            Console.WriteLine("");
            Console.WriteLine("Please hit any key to end the order.");
            Console.ReadLine();

            //method for creating a catering order
            void CheckoutCatering(Int32 intTacosNum, Int32 intSandwichesNum)
            {
                //creates a new instance of the object CateringOrder
                CateringOrder CaterOrder1 = new CateringOrder();

                //declares variables for input
                string strCustomerCode;
                string strDeliveryFee;
                string strPreferred;
                decimal decDeliveryFee1;
                Boolean bolCustomerCode;

                do
                {
                    Console.WriteLine("Please enter the Customer Code (Letters Only - 4 to 6 characters):");
                    strCustomerCode = Console.ReadLine().ToUpper();

                    //calls the validation method to check the customer code
                    bolCustomerCode = Validation.CheckCustomerCode(strCustomerCode);

                    //print error message if needed
                    if (bolCustomerCode == false) { Console.WriteLine("Invalid Customer Code. Please enter a Code 4 to 6 Letters Only."); }

                    //assigns the Customer Code to the object property.
                    CaterOrder1.strCustomerCode = strCustomerCode;

                    //inserts blank line for readability
                    Console.WriteLine("");

                } while (bolCustomerCode == false);

                //loop to get delivery fee and validate it
                do
                {
                    Console.WriteLine("Please enter the delivery fee:");
                    strDeliveryFee = Console.ReadLine();

                    decDeliveryFee1 = Validation.CheckDeliveryFee(strDeliveryFee);

                    //print error message if needed
                    if (decDeliveryFee1 == -1) { Console.WriteLine("Invalid Delivery Fee. Please enter a positive value."); }

                    CaterOrder1.decDeliveryFee = decDeliveryFee1;

                    //inserts blank line for readability
                    Console.WriteLine("");

                } while (decDeliveryFee1 == -1);

                //asks the user if this customer is preferred
                Console.WriteLine("Is this a preferred customer? <'Y or y' for yes, any other key for No> :");
                strPreferred = Console.ReadLine();

                //sets delivery fee to zero if the customer is a preferred customer
                if (strPreferred == "Y" || strPreferred == "y") { CaterOrder1.bolPreferredCustomer = true; }
                else { CaterOrder1.bolPreferredCustomer = false; }

                //populates the inputs of the object instance
                CaterOrder1.CustomerType = CustomerType.CATERING;
                CaterOrder1.intNumberOfTacos = intTacosNum;
                CaterOrder1.intNumberOfSandwiches = intSandwichesNum;
                CaterOrder1.intTotalItems = intTacosNum + intSandwichesNum;
                CaterOrder1.decTacoSubtotal = intTacosNum * decPriceTaco;
                CaterOrder1.decSandwichSubtotal = intSandwichesNum * decPriceSand;
                CaterOrder1.decSubtotal = CaterOrder1.decTacoSubtotal + CaterOrder1.decSandwichSubtotal;

                //call method to calculate the totals
                CaterOrder1.CalcTotals();

                //display the totals and receipt
                Console.WriteLine(CaterOrder1.ToString());

            }

            //method for consumer checkouts
            void CheckoutConsumer(Int32 intTacosNum, Int32 intSandwichesNum)
            {
                //declaring some variables
                string strNameInput;

                //creates a new instance of the object ConsumerOrder
                ConsumerOrder ConsumerOrder1 = new ConsumerOrder();

                //asks the user to enter the name of the customer
                Console.WriteLine("What is the customer's name:");
                strNameInput = Console.ReadLine();

                //populating the input properties on the ConsumerOrder Class
                ConsumerOrder1.CustomerType = CustomerType.CONSUMER;
                ConsumerOrder1.strCustomerName = strNameInput;
                ConsumerOrder1.intNumberOfTacos = intTacosNum;
                ConsumerOrder1.intNumberOfSandwiches = intSandwichesNum;
                ConsumerOrder1.intTotalItems = intTacosNum + intSandwichesNum;
                ConsumerOrder1.decTacoSubtotal = intTacosNum * decPriceTaco;
                ConsumerOrder1.decSandwichSubtotal = intSandwichesNum * decPriceSand;
                ConsumerOrder1.decSubtotal = ConsumerOrder1.decTacoSubtotal + ConsumerOrder1.decSandwichSubtotal;

                //call method to calculate the totals
                ConsumerOrder1.CalcTotals();

                //display the totals and receipt
                Console.WriteLine(ConsumerOrder1.ToString());
            }
        }


    }
}
