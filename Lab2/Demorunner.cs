class Demorunner
{
    Work work;
    StudentService studentService;
    public void Run()
    {
        work = new Work();
        studentService = new StudentService(work);
        while (true)
        {
            try
            {
                Console.WriteLine("Add Student -- 1");
                Console.WriteLine("List of the students -- 2");
                Console.WriteLine(" Delete student -- 3(RemoveAt)");
                Console.WriteLine("Avarage semester score -- 4");
                Console.WriteLine("Change the student by the certain index -- 5 (SetAt)");
                Console.WriteLine("Sort student by grades -- 6 (IComparable)");
                Console.WriteLine("Exit -- 0");
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        Console.WriteLine("Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Score:");
                        int score = int.Parse(Console.ReadLine());
                        studentService.AddStudent(name, score);
                        Console.WriteLine("Student is succesfully added");
                        break;
                    case "2":
                        studentService.ShowList();
                        break;
                    case "3":
                        studentService.ShowList();
                        Console.WriteLine("Number of wanted student --");
                        int target = int.Parse(Console.ReadLine());
                        studentService.Remove(target);
                        break;
                    case "4":
                        int avarage = studentService.GetAvarage();
                        Console.WriteLine($" Avarage grade is : {avarage} ");
                        break;
                    case "0":
                        Console.WriteLine("Bye..");
                        return;
                    case "6":
                        studentService.ArraySort();
                        break;
                    case "5":
                        int index = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name:");
                        string name1 = Console.ReadLine();
                        Console.WriteLine("Score:");
                        int score1 = int.Parse(Console.ReadLine());
                        studentService.SetStudent(index, name1,score1);
                        break;
                    default:
                        Console.WriteLine("Uncknown command");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Write any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}















