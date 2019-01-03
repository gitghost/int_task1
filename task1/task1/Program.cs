using System;

namespace task1
{
    public class Program
    {
        public static void FizzBuzz()
        {
            Console.WriteLine("\t Wybrano funkcje FizzBuzz.");
            Console.Write("\t Wprowadz cyfre od 0 do 1000: \t");
            ushort digit;
            string line;
            line = Console.ReadLine();
            try
            {
                digit = ushort.Parse(line);
                
                if (digit % 2 == 0 && digit % 3 == 0)
                {
                    Console.Write("\t FizzBuzz");
                }
                else if (digit % 2 == 0 && digit % 3 != 0)
                {
                    Console.Write("\t Fizz");
                }
                else if (digit % 2 != 0 && digit % 3 == 0)
                {
                    Console.Write("\t Buzz");
                }
                else
                {
                    Console.Write("\t * dead silence *");
                }
                    Console.Write("\n\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\t Podano nieprawidłowe dane wejściowe. \n");
            }
        }

        public static void Pick()
        { Console.WriteLine("Wybierz numer od 0 do 3: "); }

        public static void Info()
        {
            Console.WriteLine();
            Console.WriteLine("1 - FizzBuzz");
            Console.WriteLine("2 - DeepDive");
            Console.WriteLine("3 - DrownItDown");
            Console.WriteLine("0 - Exit program");
        }

        static void Main()
        {                       
            Info();
            Console.WriteLine("wpisz help by pokazac menu ponownie \n");
            int temp=5;
            string line="";
            do
            {
                try
                {
                    line = Console.ReadLine();
                    if 
                        (line == "help")  Info(); 
                    else
                        temp = Int32.Parse(line); 
                    
                }
                catch
                {
                    Console.WriteLine("Podano nieprawidłowe dane wejściowe.");
                }
                finally
                {                   
                    switch (temp)
                    {
                        case 0:
                            temp = 0;
                            break;
                        case 1:
                            FizzBuzz();
                            Pick();
                            temp = 5;
                            break;
                        default:
                            Pick();
                            break;
                    }
                }

            } while (temp != 0);         
            Console.WriteLine("Program zakończono.");
            //Console.ReadKey();
        }
    }
}
