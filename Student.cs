using System;

public class Student : IComparable
{
    public string Name { get; set; }
    public int Score { get; set; }

    public Student(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public override string ToString()
    {
        return $"Name: {Name} | Score: {Score}";
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        if (obj is Student otherStudent)
        {
            return string.Compare(this.Name, otherStudent.Name, StringComparison.OrdinalIgnoreCase);
        }
        else
        {
            throw new ArgumentException("Object is not a Student");
        }
    }
}