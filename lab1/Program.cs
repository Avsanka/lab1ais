using System;
using System.IO;
using System.Collections.Generic;
using lab1;

namespace ConsoleApp1
{
    
    class Program
    {


        public static void writeFile(string data, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(data);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // work with file methods
        public static void writePerson(Person person, string path)
        {
            writeFile(person.Name + ", " + person.Surname + ", " + person.Sex + ", " + person.Age, path);
        }

        public static void clearFile(string path)
        {
            Console.Clear();
            string input = "";
            Console.WriteLine("are u sure? \ny - yes, n - no");
            input = Console.ReadLine();

            if (input == "y" || input == "Y")
                writeFile("", path);
        }
        public static void showFile(string path)
        {
            Console.Clear();
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line + "\n");
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        //


        // app methods

        public static void addPerson()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Name");
                string Name = Console.ReadLine();
                Console.WriteLine("\nsurname");
                string Surname = Console.ReadLine();
                Console.WriteLine("\nsex");
                bool Sex = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("\nage");
               int Age = Convert.ToInt32(Console.ReadLine());


                if (Name != "" && Surname != "" && Age >= 0)
                {
                    Person person = new Person(Name, Surname, Sex, Age);
                    writePerson(person, "myFile");
                }
                else
                    Console.WriteLine("\n wrong or empty values");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message + "\n");
            }
        }



        public static void chooseByNum(string path)
        {
            try
            {
                string output = "";
                Console.WriteLine("\nEnter the number");
                int input = Convert.ToInt32(Console.ReadLine());

                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    for (int i = -1; i < input; i++)
                    {
                        output = sr.ReadLine();
                    }
                }
                Console.Clear();
                Console.WriteLine("\n" + output + "\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void deleteByNum(string path)
        {

            try
            {
                Console.Clear();
                Console.WriteLine("enter the number to delete");
                int input = Convert.ToInt32(Console.ReadLine());
                List<string> plist = new List<string>();
                    string record = "";

                    using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                    {
                        while ((record = sr.ReadLine()) != null)
                        {
                            plist.Add(record);
                        }
                    }

                    plist.RemoveAt(input);
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        foreach (string str in plist)
                        {
                            sw.WriteLine(str);
                        }
                    }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } 
        


        //




        public static void printMenu()
        {
            Console.WriteLine("Choose an action");
            Console.WriteLine("1)add person to file");
            Console.WriteLine("2)show persons");
            Console.WriteLine("3)clear file");
            Console.WriteLine("4)choose person by number");
            Console.WriteLine("5)delete person by number");
            Console.WriteLine("esc - exit");
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            string path = "myFile";


            ConsoleKey key = ConsoleKey.Enter;

            while (key != ConsoleKey.Escape)
            {

                printMenu();

                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        addPerson();
                        break;
                    case ConsoleKey.D2:
                        showFile(path);
                        break;
                    case ConsoleKey.D3:
                        clearFile(path);
                        break;
                    case ConsoleKey.D4:
                        chooseByNum(path);
                        break;
                    case ConsoleKey.D5:
                        deleteByNum(path);
                        break;


                    default:
                        Console.Clear();
                        break;
                }
            }





        }

    }
}



