using CMP1903_A1_2324;
using System;

namespace OOP_Assessment_2
{
    internal class SevensOut
    {

        /// <summary>
        /// Creates the first and second die private variables which are used in the Sevens Out game.
        /// </summary>
        private Die _dieOne;
        private Die _dieTwo;



        public SevensOut()
        {

            /// <summary>
            /// Initialises a new instance of the SevensOut class and creates two dice objects which are stored in the private variables created above.
            /// ExecuteGameLogic is being used here to create the gameLogic so that the class logic runs.
            /// </summary>

            _dieOne = new Die();
            _dieTwo = new Die();

            ExecuteGameLogic();
        }


        /// <summary>
        /// ExecuteGameLogic handles the whole of sevensOut logic, including tracking the score & deciding when the game should end using the gameOver bool.
        /// The logic starts inside a while loop with the gameOver bool being used.
        /// Creates an int rollTotal to store the rolled die values.
        /// The total die values are being writtin to the console using Console.Writeline
        /// Created a if-else where I check if the total rolled die values equal to 7, if they do, we end the game. If not, we continue to the else where we update the score and display the current score to the console. 
        /// If a double is detected within the if statment, we check the current die values and if they match, we get the score and double it by multiplying by 2. Which afterwards prompts the user that they scored a double and shows the current score.
        /// Created a string that stores a respone, then inside the do, im prompting the user to either continue playing or not. While is being used to check that the respone either equals a yes or a no. If its yes, it sets the gameOver to true to restart the game.
        /// Final score is displayed at the end.
        /// </summary>
        public int ExecuteGameLogic()
        {
            int _score = 0;
            bool gameOver = false;

            // Game loop
            while (!gameOver)
            {
                // Rolls the two dices and prints to the console.
                int rollTotal = _dieOne.Roll() + _dieTwo.Roll();
                Console.ForegroundColor = ConsoleColor.Yellow; // Sets the colour to yellow for the roll total.
                Console.WriteLine($"You rolled: {_dieOne.CurrentDieValue} + {_dieTwo.CurrentDieValue} = {rollTotal}");
                Console.ResetColor(); // Resets the colour to default, so it doesn't cause issues with any other parts of the code
                // Checks if the roll total is 7, if it is, prompts the user that the game has ended and they lost. 
                if (rollTotal == 7)
                {
                    Console.WriteLine("You rolled a 7! You lose!");
                    gameOver = true;
                }
                else
                {
                    // Updates the current score which also gets displayed to the console.
                    _score += rollTotal;
                    Console.WriteLine($"Your score is {_score}");

                    // Checks for doubles, if found, multiplies the score by 2 to double it.
                    if (_dieOne.CurrentDieValue == _dieTwo.CurrentDieValue)
                    {
                        _score *= 2;
                        Console.WriteLine($"Doubles! Your score is doubled! Current score: {_score}");
                        Console.WriteLine();
                    }
                }

                // Prompts the player if they want to continue the game, they have an option to continue (yes) or exit (no)
                // Using a do-while for error handling and making sure that when any other unwanted input is enterted, it keeps prompting the user to choose one option.
                string response;
                do
                {
                    Console.Write("Do you want to continue playing? (yes/no): ");
                    response = Console.ReadLine().ToLower();
                } while (response != "yes" && response != "no");

                // Check if the player wants to continue
                if (response != "yes")
                {
                    gameOver = true;
                }



                // Displays the final score at the end.
                Console.WriteLine($"Your final score for the sevensOut is: {_score}");
                Console.WriteLine();
            }

            return _score;

        }

    }
}
