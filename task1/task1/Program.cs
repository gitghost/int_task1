using System;
using System.IO;

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
                    Console.Write("\t FizzBuzz");               //w zadaniu jest dolny i górny cudzysłów
                }                                               //
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
        } //podzielność przed 2 i 3

        public static void DeepDive()
        {
            Console.WriteLine("\t Wybrano funkcje DeepDive.");
            Console.Write("\t Wprowadz cyfre od 1 do 5: \t");
            ushort digit = 0;
            string line, path = "";
            line = Console.ReadLine();

            DirectoryInfo di;
            try
            {
                digit = ushort.Parse(line);
                if (digit == 0) { Console.WriteLine("\t Folderu nie utworzono. \n"); }
                if (digit > 5) { Console.WriteLine("\t Podano za wysoką cyfrę."); digit = 0; }
            }
            catch (Exception)
            {
                Console.WriteLine("\t Podano nieprawidłowe dane wejściowe.");
            }
            finally
            {
                Guid ga = Guid.NewGuid();
                Guid[] gga = new Guid[digit];           //tworze tablice guidów  ->
                for (int i = 0; i < digit; i++)
                {
                    gga[i] = Guid.NewGuid();            //wypełniam w forze
                }
                for (int i = 0; i < digit; i++)
                {
                    path += gga[i].ToString() + "/";      // -> tworze z nich ścieżkę
                }
                try
                {
                    di = new DirectoryInfo(path);
                    di.Create();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("\t Nieprawidłowa ścieżka folderu.");//<- zbędne?
                }
            }
            Console.Write("\n");
        } //tworzenie struktury folderów

        public static void DrownItDown()
        {
            Console.WriteLine("\t Wybrano funkcje DrownItDown.");
            Console.Write("\t Wprowadz cyfre od 1 do 5: \t");
            ushort digit = 0;
            string line, path = "";
            line = Console.ReadLine();
            int temp;       // PATRZ NA INTA

            DirectoryInfo di = new DirectoryInfo("./");
            
            DirectoryInfo[] folders = di.GetDirectories();
            foreach (DirectoryInfo folder in folders)
            {
                Console.WriteLine(folder.Name);
                temp=Submarine(folder);
                Console.WriteLine("DEPTH: "+temp);      //TEN INT
            }
            
            //path = di.ToString();
            //Submarine(di);

            //Console.WriteLine("GLEBOKOSC?? ";
            try
            {
                digit = ushort.Parse(line);
                if (digit == 0) { Console.WriteLine("\t Liczba nie może być zerem."); }
                if (digit > 5) { Console.WriteLine("\t Podano za wysoką cyfrę."); digit = 0; }
            }
            catch (Exception)
            {
                Console.WriteLine("\t Podano nieprawidłowe dane wejściowe.");
            }
        }

        static int Submarine(DirectoryInfo root)   //będziemy nurkować -.-'
        {
            int temp = 0;
            DirectoryInfo di = root;
            DirectoryInfo[] folders = di.GetDirectories();
            if (folders.Length != 0)
            {
                temp++;
                Console.WriteLine(folders[0].Name);
                return temp += Submarine(folders[0]);
            }
            else
            { return 1; }

        }

        public static void Pick()
        { Console.WriteLine("Wybierz numer od 0 do 3: "); } //wybierz numer

        public static void Info()
        {
            Console.WriteLine();
            Console.WriteLine("1 - FizzBuzz");
            Console.WriteLine("2 - DeepDive");
            Console.WriteLine("3 - DrownItDown");
            Console.WriteLine("0 - Exit program");
        } //wyświetlanie menu programu


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
                    if (line == "help") Info();
                    else if (line == " " || line == "")temp = 5; //na wypadek "przypadkowych" błędów użytkownika
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
                            break;
                        case 2:
                            DeepDive();
                            Pick();
                            break;
                        case 3:
                            DrownItDown();
                            Pick();
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
