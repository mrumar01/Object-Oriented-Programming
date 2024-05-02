using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CMP1903_A1_2324
{
    internal class Die
    {

        private int _generatedRandomNumber; // The generaterdRandomNumber is used to store the value of the current die roll
        private Random random; // The random object is used to generate random numbers


        //Property
        public Die()
        {
            random = new Random();
            Roll(); // This calls the Roll method to generate a random number for the die
        }



        // Property to hold the current die value and returns the value of the current die roll
        public int CurrentDieValue
        {
            get { return _generatedRandomNumber; }
        }


        // This creates a random number from 1 to 6 for the die roll
        public int Roll()

        {
            // This try-catch block is used to handle any exceptions that may occur when generating the random number
            try
            {
                _generatedRandomNumber = random.Next(1, 7); // Generates a random number between 1 and 6, where 1 is the minimum and 7 is the maximum since its exclusive
                return _generatedRandomNumber; // This returns the rolled value of the die
            }

            // This catch block is used when an attempt is made to generate a random number, this block detects errors associated with a reference becoming null, indicating that the die object or a linked object was unexpectedly null.
            catch (NullReferenceException err)
            {
                Console.WriteLine("An NullReferenceException error occurred: '{0}'", err.Message);
                return 1;
            }
            // This catch block is used If the created random number is not within the intended range, meaning that the random number generation process generated a value that is not between 1 and 6, inclusive, this block catches problems.

            catch (ArgumentOutOfRangeException err)
            {
                Console.WriteLine("An ArgumentOutOfRangeException error occurred: '{0}'", err.Message);
                return 2;
            }
        }

    }
}