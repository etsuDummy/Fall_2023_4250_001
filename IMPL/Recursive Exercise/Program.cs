/**
 * Program.cs
 * Team BOB
 * Michael Ng, Jacob Klucher
 * Date Created: 2/21/2023
 * Last Modified: 2/21/2023
 */

using System;

int input1 = 0;
int input2 = 0;
int totalInput;

//Ensure that the input is correct.
bool firstNumberCorrect = false;
bool secondNumberCorrect = false;

//Call on the GetUserInput Method
GetUserInput();



/*
 * Takes input from the user and validates it.
 * If the user gets an input wrong, they will have to try again.
 */
void GetUserInput()
{
    while (!firstNumberCorrect || !secondNumberCorrect)
    {
        Console.WriteLine("Please insert first number: ");


        try
        {
            input1 = Convert.ToInt32(Console.ReadLine());
            firstNumberCorrect = true;
        }

        catch (Exception e)
        {
            Console.WriteLine("Please try again.");
            firstNumberCorrect = false;
            secondNumberCorrect = false;
        }



        Console.WriteLine("Please insert second number: ");


        try
        {
            input2 = Convert.ToInt32(Console.ReadLine());
            secondNumberCorrect = true;
        }

        catch (Exception e)
        {
            Console.WriteLine("Please try again.");
            firstNumberCorrect = false;
            secondNumberCorrect = false;
        }

    }

    totalInput = input1 + input2;
    Console.WriteLine(input1 + " + " + input2 + " = " + totalInput);
    Recursion(totalInput);
}

/*
 * Takes the (added) user input and 
 * separates the lesat significant number from the large input and 
 * adds them together.
 * 
 * This method continues until the resulting number has less than or equals to 2 digits left.
 */
void Recursion(int input1)
{
    string leastSignificantNumber = totalInput.ToString();
    int leastSignificantNumberInt = totalInput.ToString().Length;
    int theLeastSignificantNumber = Convert.ToInt32(leastSignificantNumber.Substring(leastSignificantNumberInt-1));
    int theOtherNumbers = Convert.ToInt32(leastSignificantNumber.Substring(0, leastSignificantNumberInt - 1));
    int theResultingNumber = theOtherNumbers + theLeastSignificantNumber;

    Console.WriteLine(theOtherNumbers + " + " + theLeastSignificantNumber + " = " + theResultingNumber);

    int digits = theResultingNumber.ToString().Length;

    //When there are 2 digits left.
    if (!(digits <= 2))
    {
        Recursion(theResultingNumber);
    }
    else 
    {
        Console.WriteLine("There are only 2 digits left. The End.");
    }
    
}








