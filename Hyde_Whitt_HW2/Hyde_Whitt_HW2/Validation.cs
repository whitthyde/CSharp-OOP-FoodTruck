//Author: Whitt Hyde (wjh695)
//Date: 27 Sept 2018
//Assignment: Homework 2
//Description: Console Application that takes orders for a food truck, then calculate a reciept based on the order. Converted to use Object Oriented Programing Principles.

using System.Text.RegularExpressions;
using System;
using System.Linq;

namespace Hyde_Whitt_HW2
{
    public static class Validation
    {
       
        //method to check for special characters
        public static Boolean CheckCustomerCode(string strinput)
        {
            //dont know took it from StackOverflow Katie didnt teach but its legit
            var regexItem = new Regex(@"^[a-zA-Z]+$");

            //checking length of customer code
            int CodeLength = strinput.Length;

            //nested if to decide whether or not to validate the code
            if (regexItem.IsMatch(strinput))
            {
                //checks length of the statement
                if (CodeLength >= 4 && CodeLength <= 6) { return true; }
                return false;
            }
            //returns false if fails validation
            return false;

        }

        //method to check Customer Type
        public static Boolean CheckCustomerType(String strInput)
        {
            //force to upper case
            strInput = strInput.ToUpper();

            //see if value is in enum
            return Enum.IsDefined(typeof(CustomerType), strInput);
        }

        //method to check if a parameter is a positive number only no symbols. For use when user is catering
        public static decimal CheckDeliveryFee(String strInput)
        {
            //declaring a decimal   
            decimal decResult;
            try { decResult = Convert.ToDecimal(strInput); }
            catch { return -1; }
            //checking the value to make sure we get positive returns only
            if (decResult < 0) { return -1; }

            return decResult;
        }

        //method to check the number of items and if it is positive with no symbols.
        public static Int32 CheckItem(String strInput)
        {
            //declaring an int

            Int32 intResult;
            try { intResult = Convert.ToInt32(strInput); }
            catch { return -1; }
            //checking the value to make sure we get positive returns only
            if (intResult < 0) { return -1; }

            return intResult;
        }


    }
}
