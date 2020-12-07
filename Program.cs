﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp9
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<string> Questions = new List<string>() { "Ołówek", "Pojemnik na kanapkę", "Podręcznik", "Pióro", "Piórnik", "Zeszyt", "Długopis", "Linijka", "Marker", "Teczka", "Gumka do wycierania", "Plecak", "Nożyczki", "Bidon", "Zeszyt do słówek", "Słownik" };
            List<string> Answers = new List<string>() { "der bleistift","die brotdose","das buch / die bücher", "die feder"," die fiedermappe","das heft","der kuli / der kugelschreiber","das lineal", "der marker", "die postmappe", "der radiergummi", "der rucksack / die rucksäcke","die schere","die trinkflasche", "das vokabelheft", "das wörterbuch, wörterbücher"};
            List<string> userAnswers = new List<string>();
            List<string> Wrongs = new List<string>();
            int corrects=0;
            int wrongs=0;
            Console.WriteLine("Starting application. Do you want to proceed? Press Y to start and N to exit.");
            string started = Console.ReadLine();
            while(started.Length > 1 || started.Length == 1 && started.ToUpper() != "Y" || started.Length == 1 && started.ToUpper() != "N")
            {
                if (started.ToUpper() == "Y")
                {
                    Console.WriteLine($"You will have {Questions.Count} questions. Answer with article. all answers should be in lower case and if there's possible multiple answer, answer by 'answer1 / answer2'. Click any key to proceed.");
                    Console.ReadKey();
                    Console.WriteLine();
                    foreach (string question in Questions)
                    {
                        Console.WriteLine($"Question: {question}");
                        userAnswers.Add(Console.ReadLine());
                        Console.WriteLine();
                    }
                    foreach(string answer in userAnswers)
                    {
                        if(!Answers.Contains(answer))
                        {
                            wrongs++;
                            Wrongs.Add(answer);
                        }
                        else
                        {
                            corrects++;
                        }
                        
                    }
                    Program program = new Program();
                    int percent = program.percent(corrects, Questions.Count);
                    Console.WriteLine();
                    Console.WriteLine($"You've answered wrong on {wrongs} and right on {corrects} questions. Percent of correct questions is {percent}%. Here are the correct answers to the questions: ");
                    foreach(string wrong in Wrongs)
                    {
                        int answersIndex = userAnswers.FindIndex(x => x == wrong);
                        string question = Questions[answersIndex];
                        string correct = Answers[answersIndex];
                        Console.WriteLine($"Question: {question} \n Your answer: {wrong} \n Correct answer: {correct}");
                        Console.WriteLine();
                    }
                    Console.WriteLine("Finishing....");
                    Console.ReadKey();
                  //  Console.WriteLine("Starting...");
                    Environment.Exit(-1);
                }
                else if (started.ToUpper() == "N")
                {
                    Console.WriteLine("Exiting...");
                    Environment.Exit(-1);
                }
                Console.WriteLine("Press Y to start and N to exit.");
                started = Console.ReadLine();
            }
         
        }
        int percent(int a, int b)
        {
            return (a / b) * 100; ;
        }
    }
}
