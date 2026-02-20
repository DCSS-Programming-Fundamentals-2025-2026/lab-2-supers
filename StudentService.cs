using System;
using Comparers;

public class StudentService
{
    private readonly StudentCollection _collection;

    public StudentService(StudentCollection collection)
    {
        _collection = collection;
    }

    public void AddStudent(string name, int score)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");
        if (score < 0 || score > 100)
            throw new ArgumentException("Score must be between 0 and 100.");

        _collection.Add(new Student(name, score));
    }

    public void Remove(int index)
    {
        _collection.RemoveAt(index);
    }

    public StudentCollection GetCollection()
    {
        return _collection;
    }

    public void SortDefault()
    {
        _collection.Sort();
    }

    public void SortAlternative()
    {
        _collection.Sort(new StudentScoreComparer());
    }

    public double GetAverage()
    {
        if (_collection.Count == 0) return 0;

        double sum = 0;
        var it = _collection.GetEnumerator();
        while (it.MoveNext())
        {
            sum += ((Student)it.Current).Score;
        }
        return sum / _collection.Count;
    }
}