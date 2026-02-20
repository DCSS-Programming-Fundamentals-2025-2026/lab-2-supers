using System;

public class Demorunner
{
    StudentCollection collection;
    StudentService studentService;

    public void Run()
    {
        collection = new StudentCollection();
        studentService = new StudentService(collection);

        while (true)
        {
            try
            {
                Console.WriteLine("\n=== STUDENT MANAGEMENT SYSTEM ===");
                Console.WriteLine("1 -- Add Student");
                Console.WriteLine("2 -- List of the students");
                Console.WriteLine("3 -- Delete student");
                Console.WriteLine("4 -- Stats");
                Console.WriteLine("5 -- Sort students by Name");
                Console.WriteLine("6 -- Sort students by Score");
                Console.WriteLine("7 -- Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Score: ");
                        int score = int.Parse(Console.ReadLine());
                        studentService.AddStudent(name, score);
                        Console.WriteLine("Student successfully added.");
                        break;

                    case "2":
                        Console.WriteLine("\n--- Student List ---");
                        var it = studentService.GetCollection().GetEnumerator();
                        int index = 0;
                        while (it.MoveNext())
                        {
                            Console.WriteLine($"[{index}] {it.Current}");
                            index++;
                        }
                        if (index == 0) Console.WriteLine("List is empty.");
                        break;

                    case "3":
                        Console.Write("Enter index of student to delete: ");
                        int target = int.Parse(Console.ReadLine());
                        studentService.Remove(target);
                        Console.WriteLine("Student deleted.");
                        break;

                    case "4":
                        Console.WriteLine("\n--- Statistics ---");
                        Console.WriteLine($"Total Students: {studentService.GetCollection().Count}");
                        Console.WriteLine($"Average Grade: {studentService.GetAverage():F2}");
                        break;

                    case "5":
                        studentService.SortDefault();
                        Console.WriteLine("Sorted by Name.");
                        break;

                    case "6":
                        studentService.SortAlternative();
                        Console.WriteLine("Sorted by Score.");
                        break;

                    case "7":
                        Console.WriteLine("Bye..");
                        return;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}