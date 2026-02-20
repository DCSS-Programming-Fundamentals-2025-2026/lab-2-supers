public class Student:IComparable
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
        return $" Name of the Student : {Name} | Year score : {Score}";
    }
    public int CompareTo(object other)
    {
        Student student= other as Student;
        if (student == null)
        {
            throw new ArgumentException();
        }
        int scoreResult =this.Score.CompareTo(student.Score);
        return scoreResult;
    }
}
    