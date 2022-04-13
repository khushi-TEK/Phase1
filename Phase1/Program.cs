using System;

namespace Phase1
{
    internal class Program
    {
        static void Main()
        {
start:            Console.Write("\nEnter\n (1) To add Teacher info\n (2) To Remove Teacher Info\n (3) Display all Info:\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            TeacherInfo Teacher = new TeacherInfo();
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Teacher ID:");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Teacher Name:");
                    string Name = Console.ReadLine();
                    Console.Write("Enter Teacher Class and Section:");
                    string CandS = Console.ReadLine();
                    var flag = Teacher.AddT(new TeacherCreds { ID = ID, Name = Name, CandS = CandS }, true);
                    if (flag)
                    {
                        Console.WriteLine("\nInfo Added Succesfully");
                    }
                    break;

                case 2:
                    Console.Write("Enter Teacher ID to Remove:");
                    int ID1 = Convert.ToInt32(Console.ReadLine());
                    var flag1 = Teacher.RemoveInfo(ID1);
                    if (flag1)
                    {
                        Console.WriteLine("\nInfo Removed Successfully");
                    }
                    break;

                case 3:
                    Teacher.PrintAllInfo();

                    break;

                default:
                    Console.WriteLine("\nInvalid Choice");
                    break;
            }
            Console.WriteLine("\nDo You Want to Continue:(yes/no)?");
            string response = Console.ReadLine();
            if (response.ToLowerInvariant() == "yes")
            {
                goto start;
            }

            Console.ReadLine();
        }
    }
}
