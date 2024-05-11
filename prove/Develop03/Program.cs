using System;
 using System.Collections.Generic;
 using System.IO;
 using System.Linq;

 class Word
 {
     public string Text { get; }
     public bool Hidden { get; private set; }

     public Word(string text)
     {
         Text = text;
         Hidden = false;
     }

     public void Hide()
     {
         Hidden = true;
     }

     public override string ToString()
     {
         return Hidden ? "______" : Text;
     }
 }

 class Reference
 {
     public string ReferenceText { get; }

     public Reference(string referenceText)
     {
         ReferenceText = referenceText;
     }

     public Reference(string book, int chapter, int verse)
     {
         ReferenceText = $"{book} {chapter}:{verse}";
     }

     public Reference(string book, int chapter, int startVerse, int endVerse)
     {
         ReferenceText = $"{book} {chapter}:{startVerse}-{endVerse}";
     }
     public override string ToString()
     {
         return ReferenceText;
     }
 }

 class Scripture
 {
     private readonly Reference reference;
     private readonly List<Word> words;

     public Scripture(Reference reference, string filePath)
     {
         this.reference = reference;
         words = new List<Word>();

         string[] lines = File.ReadAllLines(filePath);
         foreach (string line in lines)
         {
             words.AddRange(line.Split().Select(word => new Word(word)));
         }
     }

     public void HideRandomWord()
     {
         var wordsToHide = words.Where(word => !word.Hidden).ToList();
         if (wordsToHide.Count > 0)
         {
             var random = new Random();
             var wordToHide = wordsToHide[random.Next(wordsToHide.Count)];
             wordToHide.Hide();
         }
     }

     public bool IsAllHidden()
     {
         return words.All(word => word.Hidden);
     }

     public void Display()
     {
         Console.WriteLine(reference);
         foreach (var word in words)
         {
             Console.Write(word + " ");
         }
         Console.WriteLine();
     }

     public void Run()
     {
         Display();
         while (!IsAllHidden())
         {
             Console.Write("\nPress Enter to continue or type 'quit' to exit: ");
             string userInput = Console.ReadLine();
             if (userInput.ToLower() == "quit")
             {
                 break;
             }
             HideRandomWord();
             Console.Clear();
             Display();
         }
     }
 }

 class Program
 {
     static void Main()
     {
         Reference singleVerseReference = new Reference("John", 3, 16);
         Reference verseRangeReference = new Reference("Proverbs", 3, 5, 6);
         string filePath = "scripture.txt";
         Scripture scripture = new Scripture(singleVerseReference, filePath);
         scripture.Run();
     }
}