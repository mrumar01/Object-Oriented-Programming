using CMP1903_A1_2324;
using System;

namespace OOP_Assessment_2
{
    internal class ThreeOrMore
    {

        /// <summary>
        /// Creates five die private variables which are used in the ThreeorMore game.
        /// </summary>
        private Die _dieOne;
        private Die _dieTwo;
        private Die _dieThree;
        private Die _dieFour;
        private Die _dieFive;

        public ThreeOrMore()
        {
            /// <summary>
            /// Initialises a new instance of the ThreeorMore class and creates five dice objects which are stored in the private variables created above.
            /// ExecuteGameLogic is being used here to create the gameLogic so that the class logic runs.
            /// </summary>


            _dieOne = new Die();
            _dieTwo = new Die();
            _dieThree = new Die();
            _dieFour = new Die();
            _dieFive = new Die();

            ExecuteGameLogic();
        }



        /// <summary>
        /// ExecuteGameLogic method handles the game logic for the Three or More game.
        /// It runs inside a while loop until the game is over, determined by the gameOver bool.
        /// Inside the loop, it rolls five dices and calculates the roll total.
        /// The rolled dice values and total are displayed to the console.
        /// It checks for winning conditions, such as five-of-a-kind, four-of-a-kind, three-of-a-kind, and two-of-a-kind.
        /// If a two-of-a-kind is detected, it prompts the player to reroll all dice or continue with the current values.
        /// The player is prompted whether to continue playing after each turn.
        /// The game ends if the player decides not to continue or if the score reaches 20 or more.
        /// The final score is displayed at the end.
        /// </summary>

        public int ExecuteGameLogic()
        {
            int _score = 0;
            bool gameOver = false;

            Console.WriteLine("You are currently playing Three or More!");


            // Game loop
            while (!gameOver)
            {
                // Rolls the five dices
                int rollTotal = _dieOne.Roll() + _dieTwo.Roll() + _dieThree.Roll() + _dieFour.Roll() + _dieFive.Roll();

                // Prints the rollTotal values to the console, with an added highlight to the score to make it easier to see. 
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"You rolled: {_dieOne.CurrentDieValue}, {_dieTwo.CurrentDieValue}, {_dieThree.CurrentDieValue}, {_dieFour.CurrentDieValue}, {_dieFive.CurrentDieValue}");
                Console.WriteLine($"Roll total: {rollTotal}");
                Console.ResetColor();

                // Created an if statments to check for different parts of the game, and if each "section" has been either met or not.
                // Checks for the CheckWinCondition, where, I pass the rollTotal of the die values above and assign a points interger to the CheckWinCondition.
                // Score variable gets updated to the new points variable, which then is displayed in the console.
                if (CheckWinCondition(rollTotal, out int points))
                {
                    _score += points;
                    Console.WriteLine($"Congratulations! You scored {points} points!");
                    Console.WriteLine($"Total score: {_score}");
                }

                // If the players score reaches or is equal to 20 points, the game congratulates them and sets the gameOver state to true, so the game can end since the player won. 
                if (_score >= 20)
                {
                    Console.WriteLine("You reached a total score of 20 or more! You win!");
                    gameOver = true;
                }

                // Prompt the player to continue
                // Here, the PromptToContinue is being used to check if the player wants to continue or not, if they do, the gameOVer sets to true and reruns the game.
                if (!PromptToContinue())
                {
                    gameOver = true;
                    break;
                }


                // Final score is displayed for the ThreeOrMore game, where I write to the console and the _score is the total score.
                Console.WriteLine($"Your final score for ThreeOrMore is: {_score}");
                Console.WriteLine();
            }

            return _score;


        }

        // Created the PromptToContinue method to prompt the player to either continue or quit the game.
        private bool PromptToContinue()
        {
               // Using a while loop to for constant error handling, if the user inputs other than a yes or a no, it will keep prompting the user to select either one.
               // Inputs to the console if you want to continue or not.
               // Setting a sring to store a respone type, which reads the console for input and also puts it all in lowercase.
               // if the respone is yes, then we return true so the game continues. If the respone is no, we return false, causing the game to end. If anything else is inputed, it prompts the user to choose either yes or a no.
            while (true)
            {
                Console.Write("Do you want to continue playing? (yes/no): ");
                string response = Console.ReadLine().ToLower();
                if (response == "yes")
                {
                    return true;
                }
                else if (response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }
        }

        // Main method to check for the win condition. rollTotal is being passed as an integer, and a points int is also being passed. 
        private bool CheckWinCondition(int rollTotal, out int points)
        {

            // Points variable is being initalised.
            points = 0;

            // Integer array is being created for the diceValues, where we create a new int array and get the five current die values. Afterwards, they are being sorted from smallest to largest.
            int[] diceValues = new int[] { _dieOne.CurrentDieValue, _dieTwo.CurrentDieValue, _dieThree.CurrentDieValue, _dieFour.CurrentDieValue, _dieFive.CurrentDieValue };
            Array.Sort(diceValues);

            // Using an if statment to check if a five-of-a-kind is being achieved. I get the diceValues with each array indexs of 0 and 4. If they equal, we get a five-of-a-kind
            // If we do get a five-of-a-kind, 12 points are getting stored and is given to the player.
            // After, I return true, which confirms the five-of-a-kind
            if (diceValues[0] == diceValues[4])
            {
                points = 12;
                Console.WriteLine("You rolled a five-of-a-kind! Congratulations!");
                return true;
            }

            // Using an if statment to check if a four-of-a-kind is being achieved. I get the diceValues with each array indexs of 0 equals to 3 and or indexs of 1 and 4 equals, we get a four-of-a-kind
            // If we do get a four-of-a-kind, 6 points are getting stored and is given to the player.
            // After, I return true, which confirms the four-of-a-kind
            if (diceValues[0] == diceValues[3] || diceValues[1] == diceValues[4])
            {
                points = 6;
                Console.WriteLine("You rolled a four-of-a-kind! Congratulations!");
                return true;
            }

            // Checks if there is a three-of-a-kind combination among the rolled dice values.
            // Iterates through the sorted array of dice values and compares each element with the next two elements.
            // If three consecutive elements are equal, assigns 3 points to the player and displays a message.
            // Returns true if a three-of-a-kind is found, indicating a successful roll, otherwise returns false.

            for (int i = 0; i < 3; i++)
            {
                if (diceValues[i] == diceValues[i + 1] && diceValues[i] == diceValues[i + 2])
                {
                    points = 3;
                    Console.WriteLine("You rolled a three-of-a-kind! Congratulations!");
                    return true;
                }
            }

            // Checks if there is a two-of-a-kind achieved using the rolled dice values.
            // Iterates through the sorted array of dice values and compares each element with the next one.
            // The player is prompted to either roll again with all the dice or keep rolling if two consecutive elements are equal.
            // If the player chooses to reroll, all dice are rolled again and the method returns false.
            // If the player chooses to keep the two-of-a-kind, it continues the game and returns true.

            for (int i = 0; i < diceValues.Length - 1; i++)
            {
                if (diceValues[i] == diceValues[i + 1])
                {

                    // Added so you get one point if you get a two-of-a-kind. Couldn't find any other way to prevent the game running for a very long time. 
                    points = 1;
                    Console.Write("You rolled a two-of-a-kind! Do you want to reroll all dice (yes): ");
                    return true;

                    string response = Console.ReadLine().ToLower();
                    if (response == "yes")
                    {
                        RollAllDice();
                        return false; // Return false to exit the method after rerolling all dice
                    }
                    else
                    {
                        Console.WriteLine("You decided to keep the two-of-a-kind. Continuing with the game...");
                        return true; // Return true to indicate that the player decided to keep the two-of-a-kind
                    }
                }
            }

            return false;
        }
        // A rollAllDice method was implemented so that if the player chooses to rethrow all the dices, this gets used to roll the five dices.
        private void RollAllDice()
        {
            _dieOne.Roll();
            _dieTwo.Roll();
            _dieThree.Roll();
            _dieFour.Roll();
            _dieFive.Roll();
        }
    }
}
