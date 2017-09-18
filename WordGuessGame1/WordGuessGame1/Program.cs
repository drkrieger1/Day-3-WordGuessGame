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
            Console.Clear();
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
                    ViewWord(LoadFile(filePath), filePath);// View all words
                    break;
                case "2":
                    Console.Clear();
                    AddWords(filePath); //add words
                    break;
                case "3":
                    // Delete words
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
        static void ViewWord(string[] words, string filePath)
        {
            foreach (string item in words)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine(" 4: back");
            string input = Console.ReadLine();

            if (input == "4")
            {
                GameNav(filePath);
            }
        }
        //----------------------- Add Words ------------------>
        // This method adds words to the content text file.
        static void AddWords(string filePath)
        {
            Console.WriteLine(" > Type the word you want to add");

            string input = Console.ReadLine().ToLower();

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.Write(Environment.NewLine);
                sw.WriteLine(input);
            }
            Console.WriteLine($" > {input} has bin added");
            Console.WriteLine("------------------------");
            Console.WriteLine(" 4: back");
            string input2 = Console.ReadLine();

            if (input2 == "4")
            {
                GameNav(filePath);
            }
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
            Console.WriteLine($"You will have");
            Console.WriteLine(" > Can you Guess what it is?");

            string input = Console.ReadLine().ToLower();

            if (Validator(input, mysteryWord) == true)
            {
                Console.WriteLine($" > {input} is a letter in the mysteryword");
            }
            else
            {
                Console.WriteLine($" > Sorry {input} is not correct, the word was {mysteryWord}");
            }
        }
        //----------------------- Validator --------------------------->
        static bool Validator(string input, string mysteryWord)
        {
            bool isIT = false;
            if (input.ToLower().Contains(mysteryWord))
            {
                isIT = true;
            }
            return isIT;
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
