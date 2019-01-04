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
                    Console.Write("\t ,,FizzBuzz,,");               //w zadaniu jest dolny i górny cudzysłów
                }                                                   //z tego co widzę konsola ich nie rozróżnia
                else if (digit % 2 == 0 && digit % 3 != 0)          //są przecinki i apostrofy #u_mnie_działa
                {
                    Console.Write("\t ,,Fizz''");
                }
                else if (digit % 2 != 0 && digit % 3 == 0)
                {
                    Console.Write("\t ''Buzz''");
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
            Console.WriteLine("\t Ile folderów chcesz utworzyć?");
            Console.Write("\t Wprowadz cyfre od 1 do 5: \t");
            ushort digit = 0;
            string line, path = "";
            line = Console.ReadLine();

            DirectoryInfo di;
            try
            {
                digit = ushort.Parse(line);
                if (digit == 0) { Console.WriteLine("\t Folderu nie utworzono."); }
                if (digit > 5) {digit = 0; }

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
                di = new DirectoryInfo(path);
                di.Create();
            }
           
            catch (FormatException)  {Console.WriteLine("\t Podano nieprawidłowe dane wejściowe.");}
            catch (Exception){Console.WriteLine("\t Podano nieprawidłową cyfrę."); }


            Console.Write("\n");
        } //tworzenie struktury folderów

        public static void DrownItDown()
        {
            Console.WriteLine("\t Wybrano funkcje DrownItDown.");
            ushort digit = 0;
            ushort depth = 0;
            string line;
            string[] subdigits;
            int subdir;
            int count = 0;
            string yesno="n";

            FileStream fs;
            
            DirectoryInfo di = new DirectoryInfo("./");           
            DirectoryInfo[] folders = di.GetDirectories();

            if (folders.Length==0)
            {
                Console.WriteLine("\t *BRAK FOLDERÓW*   Użyj funkcji DeepDive.\n");
            }
            else
            {               
                Console.WriteLine("\t Aktualna struktura folderów: \n");
                foreach (DirectoryInfo folder in folders)                       
                {
                    count++;   //liczę głębokość folderu
                    Console.Write("\t " +count+". "+ folder.Name);
                    subdir = Submarine(folder);
                    Console.WriteLine("  podfolderów: " + (subdir - 1));
                }
                Console.Write("\n\t Wybierz folder i głębokość oddzielone spacjami:  ");
                line = Console.ReadLine();

                subdigits = line.Split(" ",2, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    digit = ushort.Parse(subdigits[0]);
                    depth = ushort.Parse(subdigits[1]);

                    if (digit == 0) { Console.WriteLine("\t Numer Folderu nie może być zerem."); }
                    else if (depth == 0) { Console.WriteLine("\t Głębokość nie może być zerem"); }
                    else
                    {
                        line=folders[digit-1].Name;
                        if (depth > 1) { line +=GetPath(folders[digit-1], depth-1); } //nurkowanie  po ścieżkę pliku

                        Console.WriteLine();
                        FileInfo fi = new FileInfo(line+"\\PLIK");                      
                        try
                        {
                            if (fi.Exists == true)
                            {
                                bool error = false;
                                do
                                {                                   
                                    Console.Write("\t Podany plik istnieje. Czy chcesz go nadpisać? [T]/[N]   ");
                                    try
                                    {
                                        yesno = Console.ReadLine();
                                        if (yesno=="t" || yesno == "T")
                                        {
                                            fi.Delete();            //usunięcie i stworzenie nowego to chyba nie to samo co nadpisanie
                                            fs = fi.Create();       
                                            fs.Close();
                                            
                                            Console.WriteLine("\t Nadpisano plik.");
                                            error = false;
                                        }
                                        else if (yesno == "n" || yesno == "N")
                                        {Console.WriteLine("\t Pliku nie nadpisano."); error = false;}
                                        else
                                        {Console.WriteLine("\t Podano nieprawidłowe dane wejściowe.");error = true; }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("\t "+e.Message);
                                        error = true;
                                    }
                                } while (error == true);                               
                            }
                            else
                            {
                                fs=fi.Create();
                                fs.Close();
                                Console.WriteLine("\t Utworzono nowy plik.");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\t Błąd podczas operacji na pliku");
                            Console.WriteLine("\t" +e.Message);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\t Podano nieprawidłowe dane wejściowe.");
                }
                Console.Write("\n");
            }
        } // tworzenie pliku na zadanej głębokości

        static int Submarine(DirectoryInfo root)   
        {
            int temp = 1;
            DirectoryInfo di = root;
            DirectoryInfo[] folders = di.GetDirectories();
            if (folders.Length != 0)
            {
                //Console.WriteLine(folders[0].Name);
                return temp += Submarine(folders[0]);
            }
            else
            { return 1; }
        } //glębokość folderów

        static string GetPath(DirectoryInfo root,int depth)
        {
            int temp = depth-1;
            string path = "/";
            DirectoryInfo di = root;
            DirectoryInfo[] folders = di.GetDirectories();
            try
            {
                path = "\\" + folders[0].Name;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("\t Przekroczono głębokość wybranego folderu.");
                throw e;
            }
            if (temp!=0)
            {                             
                return path +=GetPath(folders[0],temp);
            }
            else
            {
                return path+"\\";
            }
        } // ścieżka do subfolderów

        public static void Pick()
        { Console.Write("Wybierz numer od 0 do 3:  "); } //wybierz numer

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
            Console.WriteLine("wpisz info by pokazac menu ponownie. \n");
            Pick();
            int temp=5;
            string line="";
            do
            {
                try
                {
                    line = Console.ReadLine();
                    if (line == "info") Info();
                    else if (line == " " || line == "")temp = 5; //na wypadek "przypadkowych" błędów użytkownika
                    else
                        temp = Int32.Parse(line); 
                }
                catch
                {
                    Console.WriteLine("Podano nieprawidłowe dane wejściowe.");
                    temp = 5;
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
        } // główna pętla programu
    }
}
