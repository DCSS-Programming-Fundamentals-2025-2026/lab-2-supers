public class Student
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
}