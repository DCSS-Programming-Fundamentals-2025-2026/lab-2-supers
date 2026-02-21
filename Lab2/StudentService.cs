public class StudentService
{
    private readonly Work work;
    public StudentService(Work work)
    {
        this.work = work;
    }
    public void AddStudent(string name, int score)
    {
        if (work.Count > 200)
        {
            throw new IndexOutOfRangeException("List of the students is already filled");
        }
        else if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("You wrote a white space ");
        }
        else if (score < 0 || score > 100)
        {
            throw new ArgumentException("Score must be in range beetween 0 -- 100");
        }
        work.Add(name, score);
    }
    public void Remove(int index)
    {
        if (index < 0 || index >= work.Count)
        {
            throw new IndexOutOfRangeException("Student with that index is not exists");
        }
        work.Delete(index);
    }

    public string GetName(int index)
    {
        if (index < 0 || index >= work.Count)
        {
            throw new IndexOutOfRangeException("Student does not exists");
        }
        return work.Get(index);
    }
    public int GetAvarage()
    {
        int avarage = work.Avarage();
        if (avarage == -1)
        {
            throw new InvalidOperationException("No student had been added");
        }
        return avarage;
    }
    public void ArraySort()
    {
        work.Sort();
    }
    public void SetStudent(int index, string name, int score)
    {
        if (index < 0 || index >= work.Count)
        {
            throw new ArgumentException();
        }
        else if (score < 0 || score > 100)
        {
            throw new IndexOutOfRangeException();
        }
        work.SetAt(index, name, score);
    }
    public Student GetAt(int index)
    {
        if (index < 0 || index >= work.Count)
        {
            throw new IndexOutOfRangeException();
        }
        return work.GetAt(index);
    }
    public void SortByName()
    {
        if (work.Count == 0)
        {
            throw new ArgumentException("No student added yet");
        }
        work.SortByName();
    }
}










































