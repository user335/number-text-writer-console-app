using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Greetings ladies and gentlemen.");
            Console.ReadKey();
            Console.WriteLine("It has come to our attention that some people doubt my powers.");
            Console.ReadKey();
            Console.WriteLine("I have many powers. To prove it I shall demonstrate one of them at random.");
            Console.ReadKey();
            Console.WriteLine("Selecting random power...");
            Console.ReadKey();
            Console.WriteLine("Random power selected: Write a number to a text file");

            string location = @"C:\Users\Public\Log.txt";
            bool accepted = false;
            while (!accepted)
            {
                Console.WriteLine("Now give me an INTEGER and I shall write it to a text file");
                var answer1 = Console.ReadLine();
                if (answer1 == "" || answer1 == " ")
                {
                    Console.WriteLine("No, that won't prove my powers, try again");
                }
                else
                {
                    try
                    {
                        int answer1int = Convert.ToInt32(answer1);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("I could not figure out what INTEGER that was supposed to be");
                        continue;
                    }
                    try
                    {
                        using (StreamWriter file = new StreamWriter(location, true))
                        {
                            file.WriteLine(answer1);
                        }
                        accepted = true;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        Console.WriteLine("Could not find directory at " + location);
                        Console.WriteLine("Would you like to specify a new directory? y/n");
                        var answer2 = Console.ReadLine();
                        if (answer2.ToLower() == "y")
                        {
                            Console.WriteLine("Ok, please give me a good full working directory to prove my powers of txt document creation in");
                            location = Console.ReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception was " + ex);
                        Console.WriteLine("Current working directory is " + location);
                        Console.WriteLine("Would you like to specify a new directory? y/n");
                        var answer2 = Console.ReadLine();
                        if (answer2.ToLower() == "y")
                        {
                            Console.WriteLine("Ok, please give me a good full working directory to prove my powers of txt document creation in");
                            location = Console.ReadLine();
                        }
                    }
                }
            }
            Console.WriteLine("It is done! See for yourself");
            string text = System.IO.File.ReadLines(location).Last();
            Console.WriteLine(location + " contents of last line in doc = " + text);
            Console.WriteLine("Your answer exists at " + location + ". Goodbye, human.");
            Console.WriteLine("MY POWERS ARE PROVEN");
            Console.ReadKey();
        }
    }
}
