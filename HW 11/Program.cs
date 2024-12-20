using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string wordToGuess = "слово"; 
        int maxMistakes = 6; 

        char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
        HashSet<char> guessedLetters = new HashSet<char>();
        int mistakes = 0;

        Console.WriteLine("Congratulations! Try to guess the encrypted word!");
        Console.WriteLine($"The number of letters in a word: {wordToGuess.Length}");
        Console.WriteLine($"The number of possible incorrect attempts: {maxMistakes}");
        Console.WriteLine();

        while (mistakes < maxMistakes && new string(guessedWord) != wordToGuess)
        {
            Console.WriteLine($"Encrypted word: {new string(guessedWord)}");
            Console.Write("Enter your letter: ");
            string input = Console.ReadLine().ToLower();

            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                Console.WriteLine("Please enter one letter.");
                continue;
            }

            char guessedLetter = input[0];

            if (guessedLetters.Contains(guessedLetter))
            {
                Console.WriteLine("You already guessed this letter. Try another one.");
                continue;
            }

            guessedLetters.Add(guessedLetter);

            if (wordToGuess.Contains(guessedLetter))
            {
                Console.WriteLine("Such a letter is in the word!");
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guessedLetter)
                    {
                        guessedWord[i] = guessedLetter;
                        Console.Write($"Letter position: {i + 1} ");
                    }
                }
                Console.WriteLine();
            }
            else
            {
                mistakes++;
                Console.WriteLine($"There is no such letter! Remaining attempts: {maxMistakes - mistakes}");
            }
            Console.WriteLine();
        }

        if (new string(guessedWord) == wordToGuess)
        {
            Console.WriteLine("Congratulations, you guessed the word!");
            Console.WriteLine($"Encrypted word: {wordToGuess}");
        }
        else
        {
            Console.WriteLine("Unfortunately, you lost.");
            Console.WriteLine($"The encrypted word was: {wordToGuess}");
        }

        Console.WriteLine("Thanks for playing.");
    }
}
