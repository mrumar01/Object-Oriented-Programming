using System.Diagnostics;

namespace OOP_Assessment_2
{

    /// <summary>
    /// This class contains methods for executing tests on the TestSevensOut or TestThreeOrMore.
    /// TestSevensOut creates a SevensOut object, using debug.assert checks that the final score equals to 7.
    /// TestThreeOrMore creates a ThreeOrMore object, using debug.assert checks the games final score is equal or greater than 20
    /// </summary>

    internal class Testing
    {
        public static void PerformTests()
        {
            // Method to perform tests on both Sevens Out and Three Or More games
            TestSevensOut();
            TestThreeOrMore();
        }

        public static void TestSevensOut()
        {
            // Method to test the Sevens Out game logic
            // Writes to the console to show that it's going to preform the test

            Console.WriteLine("Performing tests for Sevens Out...");

            // Creates a sevensOut object
            SevensOut sevensOut = new SevensOut();

            // Test Sevens Out game logic 
            int totalRoll = 7;

            // Gets the results of the game logic
            int finalScore = sevensOut.ExecuteGameLogic();

            // Checks if the final score equals 7
            Debug.Assert(finalScore == totalRoll, $"Sevens Out game did not stop when the total roll equaled {totalRoll}.");

            // prints to the console that the test was completed
            Console.WriteLine("Sevens Out tests completed.");
        }



        public static void TestThreeOrMore()
        {
            // Method to test the Three Or More game logic
            // Writes to the console to show that it's going to preform the test

            Console.WriteLine("Performing tests for Three Or More...");

            // Creates a ThreeOrMore game object
            ThreeOrMore threeOrMore = new ThreeOrMore();


            // Test Three Or More game logic
            // Ensure that the game recognises when the total score is greater than or equal to 20
            int targetScore = 20;

            // Gets the final score from the game logic
            int finalScore = threeOrMore.ExecuteGameLogic();

            // Checks if the final score is greater than or equal to the target score
            Debug.Assert(finalScore >= targetScore, $"Three Or More game did not recognize when the total score ({finalScore}) was greater than or equal to {targetScore}.");

            // prints to the console that the test was 
            Console.WriteLine("Three Or More tests completed.");
        }


    }
}
