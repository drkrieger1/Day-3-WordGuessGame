using System;
using System.IO;

namespace WordGuessGame1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\shop2\Desktop\guessingGame\gameText.txt";
            GameNav(filePath);
            Console.Read();
        }
        //------------------ Game Nav ---------------->
        //This method runs the game navigation menu.
        static void GameNav(string filePath)
        {
            Console.WriteLine("Word Guessing game menu:");
            Console.WriteLine("please select a number from the following");
            string[] menuOptions = { " 1: New Game", " 2: Exit Game", " 3: Game Options" };
            foreach (string item in menuOptions)
            {
                Console.WriteLine(item);
            }
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    NewGame(LoadFile(filePath)); //New Game 
                    break;
                case "2":
                    Console.WriteLine("ExitGame"); //Exit
                    ExitGame();
                    break;
                case "3":
                    Options(filePath); //Options menu 
                    break;

                default:
                    Console.WriteLine("wrong selection");
                    GameNav(filePath);
                    break;

            }

        }
        //---------------------- Option menu ------------->
        static void Options(string filePath)
        {
            Console.Clear();
            Console.WriteLine("Game Options");
            string[] editGame = { " 1: View all words", " 2: Add word", " 3: Delete Word", " 4: Back" };
            foreach (string item in editGame)
            {
                Console.WriteLine(item);
            }
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    ViewWord(LoadFile(filePath));// View all words
                    break;
                case "2":
                    // Add Words
                    break;
                case "3":
                    // Delete 
                    break;
                case "4":
                    Console.Clear();
                    GameNav(filePath);
                    break;

                default:
                    Console.WriteLine("wrong selection");
                    Options(filePath);
                    break;

            }
        }
        //--------------------- View Words --------------->
        //This method displays the words  from the content text file.
        static void ViewWord(string[] words)
        {
            foreach (string item in words)
            {
                Console.WriteLine(item);
            }
        }
        //----------------------- Add Words ------------------>
        // This method adds words to the content text file.
        static void AddWords()
        {
            //To Do
        }
        //------------------------ Delete ----------------------->
        // This method Removes words frome the content text file.
        static void Delete()
        {
            //To Do
        }
        //----------------------- Exit Game ---------------------->
        //This method will let the user exit out of the game.
        static void ExitGame()
        {
            Environment.Exit(0);
        }
        //------------------------ New Game ----------------------->
        //This method lets the user starts a new game. random word is made here. 
        //It is a logic staging area. 
        static void NewGame(string[] words)
        {
            Random num = new Random();
            int index = num.Next(0, words.Length);

            Console.WriteLine("Enter your user name:");
            string userName = Console.ReadLine();



            Play(userName, words[index]);
        }
        //---------------------- Play Game ------------------------->
        //This method wil let the user kick off and start playing the game. 
        static void Play(string userName, string mysteryWord)
        {
            Console.Clear();
            int hint = mysteryWord.Length;
            Console.WriteLine($" > Okay {userName} ");
            Console.WriteLine($" > The Mystery Word is {hint} letters long! ");
            Console.WriteLine(" > Can you Guess what it is?");

            string input = Console.ReadLine().ToLower();
            if (input == mysteryWord)
            {
                Console.WriteLine($" > {input} is correct!!!");
            }
            else
            {
                Console.WriteLine($" > Sorry {input} is not correct, the word was {mysteryWord}");
            }
        }
        //----------------------- Load Text File ---------------------->
        //This method will load the default game text file.
        static string[] LoadFile(string filePath)
        {
            string[] words;

            //try
            //{   
            using (StreamReader sr = File.OpenText(filePath)) // iknow this is wrong
            {
                words = File.ReadAllLines(filePath);

            }
            //}
            //catch(DirectoryNotFoundException)
            //{
            //    Console.WriteLine("ERROR: DIRECTORY DOES NOT EXIST");
            //}
            return words;

        }
        static void SavedGame()
        {

        }
    }
}
