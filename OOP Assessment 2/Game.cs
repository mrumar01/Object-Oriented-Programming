using CMP1903_A1_2324;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace OOP_Assessment_2
{

    /// <summary>
    /// Entry point for the whole game.
    /// Allows the user to choose what to play and to review testing and or quit.
    /// Testing method has been implemented to choose a testing game
    /// </summary>

    internal class Game
    {
        // Main entry point for the game
        static void Main(string[] args)
        {
         
            // running a while loop for coninues input until given.
            while (true)
            {
            menuOptions();
            }
        }



        // Menu method that holds the menu selection options.
        static void menuOptions()
        {
            Console.Clear();
            Console.WriteLine("Hello, choose an option below to get started!");
            Console.WriteLine("1. Instantiate Sevens Out game");
            Console.WriteLine("2. Instantiate Three Or More game");
            Console.WriteLine("3. View statistics data, (not implemented)");
            Console.WriteLine("4. Perform tests in Testing class");
            Console.WriteLine("5. Exit");

            // Gets the users choice by reading the console for a value of (1-5)
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            // Call corresponding method based on user's choice
            switch (choice)
            {
                case 1:
                    InstantiateSevensOutGame();
                    break;
                case 2:
                    InstantiateThreeOrMoreGame();
                    break;
                case 3:
                    ViewStatisticsData();
                    break;
                case 4:
                    RunTesting();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }

        // Define methods for each menu option
        static void InstantiateSevensOutGame()
        {
            Console.WriteLine("Starting Sevens Out game...");
            SevensOut sevensOut = new SevensOut();

        }

        static void InstantiateThreeOrMoreGame()
        {

            Console.WriteLine("Starting ThreeOrMore game...");
            ThreeOrMore threeOrMore = new ThreeOrMore();

        }

        static void ViewStatisticsData()
        {
            // not implemented...
        }

        // created a sperate method so the user can select to either run the sevens out or the three or more in the testing.
        static void RunTesting()
        {
            int choice;
            do
            {
                Console.WriteLine("Choose what to test:");
                Console.WriteLine("1. Sevens Out");
                Console.WriteLine("2. Three Or More");
                Console.WriteLine("3. Back to main menu");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            // Perform tests for Sevens Out
                            Testing.TestSevensOut();
                            break;
                        case 2:
                            // Perform tests for Three Or More
                            Testing.TestThreeOrMore();
                            break;
                        case 3:
                            // Back to main menu
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            } while (choice != 3);
        }

    }
}

